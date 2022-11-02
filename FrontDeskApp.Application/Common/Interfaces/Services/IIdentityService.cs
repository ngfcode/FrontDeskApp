using FrontDeskApp.Application.Accounts;
using FrontDeskApp.Application.Common.Results;

namespace FrontDeskApp.Application.Common.Interfaces.Services;

/// <summary>
/// An interface that defines different methods for handling the identity and authorization service,
/// that can be implemented in different ways such as ASP.NET Core Identiy or IdentityServer.
/// </summary>
public interface IIdentityService
{
	Task<DtoResult<AccountDto.LoginResponseDto>> LoginAsync(
		AccountDto.LoginDto dto,
		CancellationToken cancellationToken = default);
	Task LogoffAsync(
		CancellationToken cancellationToken = default);

	Task<DtoResult<AccountDto.TokenResponseDto>> RefreshTokenAsync(
		AccountDto.TokenDto dto,
		CancellationToken cancellationToken = default);
	Task<Result> RevokeAsync(
		string userName,
		CancellationToken cancellationToken = default);
	Task RevokeAllAsync(
		CancellationToken cancellationToken = default);

	Task<DtoResult<AccountDto.Dto>> ChangePasswordAsync(
		AccountDto.ChangePasswordDto dto,
		CancellationToken cancellationToken = default);
	Task<DtoResult<AccountDto.ActivateEmailResponseDto>> ForgotPasswordAsync(
		string email,
		CancellationToken cancellationToken = default);
	Task<DtoResult<AccountDto.Dto>> ResetPasswordAsync(
		AccountDto.ResetPasswordDto dto,
		CancellationToken cancellationToken = default);

	Task<DtoResult<AccountDto.ActivateEmailResponseDto>> ActivateEmailAsync(
		string email, string token,
		CancellationToken cancellationToken = default);
	Task<DtoResult<AccountDto.ActivateEmailResponseDto>> ResendEmailConfirmationAsync(
		string email,
		CancellationToken cancellationToken = default);

	Task<T> GetByUserNameAsync<T>(
		string userName,
		CancellationToken cancellationToken = default)
		where T : class;
	Task<AccountDto.LoginResponseDto> GetByUserNameAsync(
		string userName,
		CancellationToken cancellationToken = default);

	Task<QueryResult<AccountDto.QueryDto>> ListUsersAsync(
		AccountDto.SearchCriteria searchCriteria,
		CancellationToken cancellationToken = default);

	Task<DtoResult<AccountDto.RegisterResponseDto>> CreateUserAsync(
		AccountDto.RegisterDto dto,
		CancellationToken cancellationToken = default);
}
