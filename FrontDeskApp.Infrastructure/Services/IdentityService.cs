using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Accounts;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using FrontDeskApp.Infrastructure.Configurations;
using FrontDeskApp.Infrastructure.Identity;
using FrontDeskApp.Shared.Constants;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FrontDeskApp.Infrastructure.Services;

internal class IdentityService : IIdentityService
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly SignInManager<ApplicationUser> _signInManager;
	private readonly RoleManager<ApplicationRole> _roleManager;
	private readonly IEmailService _emailService;
	private readonly EmailConfig _emailConfig;
	private readonly JwtConfig _jwtConfig;
	private readonly TokenValidationParameters _tokenValidationParams;
	private readonly IMapper _mapper;

	public IdentityService(
		UserManager<ApplicationUser> userManager,
		SignInManager<ApplicationUser> signInManager,
		RoleManager<ApplicationRole> roleManager,
		IEmailService emailService,
		EmailConfig emailConfig,
		JwtConfig jwtConfig,
		TokenValidationParameters tokenValidationParams,
		IMapper mapper)
	{
		_userManager = Guard.Against.Null(userManager, nameof(userManager));
		_signInManager = Guard.Against.Null(signInManager, nameof(signInManager));
		_roleManager = Guard.Against.Null(roleManager, nameof(roleManager));
		_emailService = Guard.Against.Null(emailService, nameof(emailService));
		_emailConfig = Guard.Against.Null(emailConfig, nameof(emailConfig));
		_jwtConfig = Guard.Against.Null(jwtConfig, nameof(jwtConfig));
		_tokenValidationParams = Guard.Against.Null(tokenValidationParams, nameof(tokenValidationParams));
		_mapper = Guard.Against.Null(mapper, nameof(mapper));
	}

	public async Task<DtoResult<AccountDto.LoginResponseDto>> LoginAsync(
		AccountDto.LoginDto dto,
		CancellationToken cancellationToken = default)
	{
		var result = new DtoResult<AccountDto.LoginResponseDto>();

		var user = await GetByUserNameAsync<ApplicationUser>(dto.UserName);
		if (user is object)
		{

			if (await _userManager.IsEmailConfirmedAsync(user))
			{

				if (user.IsActivated)
				{

					var signInResult = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password,
						dto.RememberMe, true);
					if (signInResult.Succeeded)
					{

						result.Dto = _mapper.Map<AccountDto.LoginResponseDto>(user);
						result.Dto.Roles = await _userManager.GetRolesAsync(user);

						var authClaims = new List<Claim>
						{
							new Claim(nameof(ICurrentUserService.UserId), result.Dto.Id.ToString()),
							new Claim(ClaimTypes.Name, result.Dto.UserName),
							new Claim(ClaimTypes.Email, result.Dto.Email),
							new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
						};

						foreach (var userRole in result.Dto.Roles)
							authClaims.Add(new Claim(ClaimTypes.Role, userRole));

						var token = CreateToken(authClaims);

						result.Dto.Token = new JwtSecurityTokenHandler().WriteToken(token);
						result.Dto.Expiration = token.ValidTo;
						result.Dto.RefreshToken = GenerateRefreshToken();

						// Update user
						user.RefreshToken = result.Dto.RefreshToken;
						user.RefreshTokenExpiryDate = DateTime.UtcNow.AddDays(_jwtConfig.RefreshTokenLifeTimeInDays);
						await _userManager.UpdateAsync(user);

						return result;

					}

					if (signInResult.IsLockedOut)
					{

						result.AddErrorMessage(
							string.Format(
								ErrorMessages.AccountIsLocked,
								DefaultValues.LockoutTimeSpanInMinutes));
						return result;

					}

					result.AddErrorMessage(ErrorMessages.UsernamePasswordInvalid);
					return result;

				}

				result.AddErrorMessage(ErrorMessages.AccountNotYetActivated);
				return result;

			}

			result.AddErrorMessage(ErrorMessages.EmailNotYetValidated);
			return result;

		}

		result.AddErrorMessage(ErrorMessages.UsernamePasswordInvalid);
		return result;
	}

	public async Task LogoffAsync(
		CancellationToken cancellationToken = default)
	{
		await _signInManager.SignOutAsync();
	}

	public async Task<DtoResult<AccountDto.TokenResponseDto>> RefreshTokenAsync(
		AccountDto.TokenDto dto,
		CancellationToken cancellationToken = default)
	{
		var result = new DtoResult<AccountDto.TokenResponseDto>();

		var principal = GetPrincipalFromExpiredToken(dto.Token);
		if (principal is null)
		{

			result.AddErrorMessage("Invalid access token or refresh token.");
			return result;

		}

		var userName = principal.Identity.Name;
		var user = await _userManager.FindByNameAsync(userName);
		if (user is null || user.RefreshToken != dto.RefreshToken || user.RefreshTokenExpiryDate <= DateTime.UtcNow)
		{

			result.AddErrorMessage("Invalid access token or refresh token.");
			return result;

		}

		// Updates the token
		var newAccessToken = CreateToken(principal.Claims.ToList());
		var newRefreshToken = GenerateRefreshToken();

		user.RefreshToken = newRefreshToken;
		user.RefreshTokenExpiryDate = DateTime.UtcNow.AddDays(_jwtConfig.RefreshTokenLifeTimeInDays);
		await _userManager.UpdateAsync(user);

		var jwtTokenHandler = new JwtSecurityTokenHandler();
		result.Dto.Token = jwtTokenHandler.WriteToken(newAccessToken);
		result.Dto.Expiration = newAccessToken.ValidTo;
		result.Dto.RefreshToken = newRefreshToken;

		return result;
	}

	public async Task<Result> RevokeAsync(
		string userName,
		CancellationToken cancellationToken = default)
	{
		var user = await _userManager.Users
			.FirstOrDefaultAsync(_ => _.UserName == userName, cancellationToken);
		if (user is null)
		{
			return Result.Failure("User Name not found.");
		}

		user.RefreshToken = null;
		await _userManager.UpdateAsync(user);

		return Result.Success();
	}

	public async Task RevokeAllAsync(
		CancellationToken cancellationToken = default)
	{
		var users = await _userManager.Users
			.Where(_ => _.IsActivated).ToListAsync(cancellationToken);
		foreach (var user in users)
		{

			user.RefreshToken = null;
			await _userManager.UpdateAsync(user);

		}
	}

	public async Task<DtoResult<AccountDto.Dto>> ChangePasswordAsync(
		AccountDto.ChangePasswordDto dto,
		CancellationToken cancellationToken = default)
	{
		var result = new DtoResult<AccountDto.Dto>();

		var user = await _userManager.FindByIdAsync(dto.Id.ToString());
		if (user is object)
		{

			var chgPwdResult = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
			if (chgPwdResult.Succeeded)
			{

				result.Dto = _mapper.Map<AccountDto.Dto>(user);
				return result;

			}

			chgPwdResult.Errors.ToList()
				.ForEach(_ => result.AddErrorMessage(_.Description));
			return result;

		}

		result.AddErrorMessage(ErrorMessages.UsernamePasswordInvalid);

		return result;
	}

	public async Task<DtoResult<AccountDto.ActivateEmailResponseDto>> ForgotPasswordAsync(
		string email,
		CancellationToken cancellationToken = default)
	{
		var result = new DtoResult<AccountDto.ActivateEmailResponseDto>();

		var user = await _userManager.FindByEmailAsync(email);
		if (user is object && await _userManager.IsEmailConfirmedAsync(user))
		{

			var token = await _userManager.GeneratePasswordResetTokenAsync(user);
			result.Dto = new AccountDto.ActivateEmailResponseDto()
			{
				EmailConfirmationToken = token
			};

			// Sends an email
			var msg = new MailMessage()
			{
				From = new MailAddress(_emailConfig.FromEmail, _emailConfig.FromName),
				Subject = "Boilerplate Clean Architecture - Password Reset",
				IsBodyHtml = true,
				Body = $"Please confirm your account by clicking the link: {token}"

			};

			msg.To.Add(new MailAddress(user.Email, user.Email));

			await _emailService.SendAsync(msg, cancellationToken);

		}

		return result;
	}

	public async Task<DtoResult<AccountDto.Dto>> ResetPasswordAsync(
		AccountDto.ResetPasswordDto dto,
		CancellationToken cancellationToken = default)
	{
		var result = new DtoResult<AccountDto.Dto>();

		var user = await _userManager.FindByEmailAsync(dto.Email);
		if (user is object)
		{

			var resetPwdResult = await _userManager.ResetPasswordAsync(user, dto.EmailConfirmationToken, dto.Password);
			if (!resetPwdResult.Succeeded)
			{

				result.AddErrorMessage(ErrorMessages.ResetPasswordError);
				return result;

			}

			return result;

		}

		result.AddErrorMessage(ErrorMessages.ResetPasswordError);
		return result;
	}

	public async Task<DtoResult<AccountDto.ActivateEmailResponseDto>> ActivateEmailAsync(
		string email,
		string token,
		CancellationToken cancellationToken = default)
	{
		var result = new DtoResult<AccountDto.ActivateEmailResponseDto>();

		var user = await _userManager.FindByEmailAsync(email);
		if (user is object)
		{

			var confirmResult = await _userManager.ConfirmEmailAsync(user, token);
			if (confirmResult.Succeeded)
			{

				user.IsActivated = true;
				await _userManager.UpdateAsync(user);

				return result;

			}
		}

		result.AddErrorMessage(ErrorMessages.ConfirmEmail);
		return result;
	}

	public async Task<DtoResult<AccountDto.ActivateEmailResponseDto>> ResendEmailConfirmationAsync(
		string email,
		CancellationToken cancellationToken = default)
	{
		var result = new DtoResult<AccountDto.ActivateEmailResponseDto>();

		var user = await _userManager.FindByEmailAsync(email);
		if (user is object)
		{

			result.Dto = new()
			{
				EmailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user)
			};
			return result;

		}

		result.AddErrorMessage(ErrorMessages.EmailNotFound);
		return result;
	}

	public async Task<ApplicationUser> GetByUserNameAsync<ApplicationUser>(
		string userName,
		CancellationToken cancellationToken = default)
		where ApplicationUser : class
	{
		var user = await _userManager.Users
			.FirstOrDefaultAsync(_ => _.UserName == userName, cancellationToken);

		return user as ApplicationUser;
	}

	public async Task<AccountDto.LoginResponseDto> GetByUserNameAsync(
		string userName,
		CancellationToken cancellationToken = default)
	{
		var user = await _userManager.Users
			.FirstOrDefaultAsync(_ => _.UserName == userName, cancellationToken);
		if (user is object)
		{
			return _mapper.Map<AccountDto.LoginResponseDto>(user);
		}

		return null;
	}

	public async Task<DtoResult<AccountDto.RegisterResponseDto>> CreateUserAsync(
		AccountDto.RegisterDto dto,
		CancellationToken cancellationToken = default)
	{
		var result = new DtoResult<AccountDto.RegisterResponseDto>();

		var user = await _userManager.FindByNameAsync(dto.UserName);
		if (user is null)
		{

			user = _mapper.Map<ApplicationUser>(dto);
			var userResult = await _userManager.CreateAsync(user, dto.Password);
			if (userResult.Succeeded)
			{

				result.Dto = _mapper.Map<AccountDto.RegisterResponseDto>(user);
				result.Dto.EmailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
				return result;

			}

			result.AddErrorMessage(ErrorMessages.RegistrationFailed);
			return result;

		}

		result.AddErrorMessage(ErrorMessages.AccountAlreadyExists);
		return result;
	}

	public async Task<QueryResult<AccountDto.QueryDto>> ListUsersAsync(
		AccountDto.SearchCriteria searchCriteria,
		CancellationToken cancellationToken = default)
	{
		var totalRecords = 0;

		// TODO: Has to change the username filter based on the actual value
		var query = _userManager.Users
			.Where(_ => _.UserName != "admin@localhost.com");

		#region Sets criteria
		//if (!string.IsNullOrWhiteSpace(searchCriteria.Email))
		//{
		//	query = query.Where(_ => _.Email.Contains(searchCriteria.Email));
		//}

		if (searchCriteria.IsActive is object)
		{
			query = query.Where(_ => _.IsActivated == searchCriteria.IsActive);
		}

		if (searchCriteria.IsLocked.Value == true)
		{
		}
		#endregion

		if (searchCriteria.IsPagingEnabled)
		{

			totalRecords = await query.CountAsync(cancellationToken);

			query = query.Skip(searchCriteria.CurrentPage * searchCriteria.PageSize)
				.Take(searchCriteria.PageSize);

		}

		var users = await query.ToListAsync(cancellationToken);

		var result = new QueryResult<AccountDto.QueryDto>(
			_mapper.Map<List<AccountDto.QueryDto>>(users),
			totalRecords > 0 ? totalRecords : users.Count,
			searchCriteria.CurrentPage,
			searchCriteria.PageSize);

		result.TotalRecords = totalRecords;

		return result;
	}

	private JwtSecurityToken CreateToken(
		List<Claim> claims)
	{
		var authSigningKey = new SymmetricSecurityKey(
			Encoding.UTF8.GetBytes(_jwtConfig.Secret));

		return new JwtSecurityToken(
			issuer: _jwtConfig.ValidIssuer,
			audience: _jwtConfig.ValidAudience,
			expires: DateTime.UtcNow.Add(_jwtConfig.TokenLifeTime),
			claims: claims,
			signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
	}

	private static string GenerateRefreshToken()
	{
		var randomNumber = new byte[64];
		using var rng = RandomNumberGenerator.Create();
		rng.GetBytes(randomNumber);

		return Convert.ToBase64String(randomNumber);
	}

	private ClaimsPrincipal GetPrincipalFromExpiredToken(
		string token)
	{
		var tokenHandler = new JwtSecurityTokenHandler();

		try
		{
			var principal = tokenHandler.ValidateToken(token, _tokenValidationParams, out var securityToken);
			if (IsJwtWithValidSecurityAlgorithm(securityToken))
			{
				return principal;
			}

			return null;
		}

		catch
		{
			return null;
		}
	}

	private bool IsJwtWithValidSecurityAlgorithm(
		SecurityToken securityToken)
	{
		return (securityToken is JwtSecurityToken jwtSecurityToken) &&
			jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
	}
}
