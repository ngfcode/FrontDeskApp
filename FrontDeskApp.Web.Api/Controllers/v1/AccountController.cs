using Ardalis.GuardClauses;
using FrontDeskApp.Application.Accounts;
using FrontDeskApp.Application.Accounts.Commands.ActivateEmail;
using FrontDeskApp.Application.Accounts.Commands.ChangePassword;
using FrontDeskApp.Application.Accounts.Commands.ForgotPassword;
using FrontDeskApp.Application.Accounts.Commands.Login;
using FrontDeskApp.Application.Accounts.Commands.Logoff;
using FrontDeskApp.Application.Accounts.Commands.RefreshToken;
using FrontDeskApp.Application.Accounts.Commands.Register;
using FrontDeskApp.Application.Accounts.Commands.ResendEmailToken;
using FrontDeskApp.Application.Accounts.Commands.ResetPassword;
using FrontDeskApp.Application.Accounts.Commands.Revoke;
using FrontDeskApp.Application.Accounts.Commands.RevokeAll;
using FrontDeskApp.Web.Api.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrontDeskApp.Web.Api.Controllers.v1;

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Authentication")]
public class AccountController : BaseController
{
	private readonly IConfiguration _configuration;

	public AccountController(
		IConfiguration configuration)
	{
		_configuration = Guard.Against.Null(configuration, nameof(configuration));
	}

	[HttpPost("Login")]
	[AllowAnonymous]
	[ServiceFilter(typeof(LogActionFilterService))]
	public async Task<IActionResult> LoginAsync(
		[FromBody] AccountDto.LoginDto request,
		CancellationToken cancellationToken = default)
	{
		var cmd = new LoginCommand()
		{
			Dto = request
		};
		var result = await Mediator.Send(cmd, cancellationToken);
		if (result.NoErrors)
		{
			return Ok(result);
		}

		return BadRequest(result);
	}

	[HttpPatch("Logoff")]
	[AllowAnonymous]
	public async Task<IActionResult> LogoffAsync(
		CancellationToken cancellationToken = default)
	{
		await Mediator.Send(new LogoffCommand(), cancellationToken);
		return Ok();
	}

	[HttpPost("RefreshToken")]
	[AllowAnonymous]
	public async Task<IActionResult> RefreshTokenAsync(
		[FromBody] AccountDto.TokenDto request,
		CancellationToken cancellationToken = default)
	{
		var cmd = new RefreshTokenCommand()
		{
			Dto = request
		};
		var result = await Mediator.Send(cmd, cancellationToken);
		if (result.NoErrors)
		{
			return Ok(result);
		}

		return BadRequest(result);
	}

	[HttpPost("Revoke")]
	public async Task<IActionResult> RevokeAsync(
		[FromBody] string userName,
		CancellationToken cancellationToken = default)
	{
		var cmd = new RevokeCommand()
		{
			UserName = userName
		};
		var result = await Mediator.Send(cmd, cancellationToken);
		if (result.IsSuccessful)
		{
			return Ok(result);
		}

		return BadRequest(result);
	}

	[HttpPost("RevokeAll")]
	public async Task<IActionResult> RevokeAllAsync(
		CancellationToken cancellationToken = default)
	{
		var cmd = new RevokeAllCommand();
		var result = await Mediator.Send(cmd, cancellationToken);

		return Ok(result);
	}

	[HttpPatch("ChangePassword")]
	public async Task<IActionResult> ChangePasswordAsync(
			[FromBody] AccountDto.ChangePasswordDto request,
			CancellationToken cancellationToken = default)
	{
		var cmd = new ChangePasswordCommand()
		{
			Dto = request
		};
		var result = await Mediator.Send(cmd, cancellationToken);
		if (result.NoErrors)
		{
			return Ok(result);
		}

		return BadRequest(result);
	}

	[HttpPatch("ForgotPassword")]
	[AllowAnonymous]
	public async Task<IActionResult> ForgotPasswordAsync(
		[FromBody] string email,
		CancellationToken cancellationToken = default)
	{
		var cmd = new ForgotPasswordCommand()
		{
			Email = email
		};
		var result = await Mediator.Send(cmd, cancellationToken);
		if (result.NoErrors)
		{
			return Ok(result);
		}

		return BadRequest(result);
	}

	[HttpPatch("ResetPassword")]
	[AllowAnonymous]
	public async Task<IActionResult> ResetPasswordAsync(
		[FromBody] AccountDto.ResetPasswordDto request,
		CancellationToken cancellationToken = default)
	{
		var cmd = new ResetPasswordCommand()
		{
			Dto = request
		};
		var result = await Mediator.Send(cmd, cancellationToken);
		if (result.NoErrors)
		{
			return Ok(result);
		}

		return BadRequest();
	}

	/// <summary>
	/// Creates a user account, an email notification will be sent to the given email if successful.
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[HttpPost("Register")]
	[AllowAnonymous]
	public async Task<IActionResult> RegisterAsync(
		[FromBody] AccountDto.RegisterDto request,
		CancellationToken cancellationToken = default)
	{
		var cmd = new RegisterCommand()
		{
			Dto = request
		};
		var result = await Mediator.Send(cmd, cancellationToken);
		if (result.NoErrors)
		{
			return Ok(result);
		}

		return BadRequest(result);
	}

	[HttpPatch("ActivateEmail")]
	[AllowAnonymous]
	public async Task<IActionResult> ActivateEmailAsync(
			string email,
			string token)
	{
		ActivateEmailCommand command = new ActivateEmailCommand()
		{
			Email = email,
			Token = token
		};
		var result = await Mediator.Send(command);

		return Ok(result);
	}

	[HttpGet("ResendEmailToken")]
	[AllowAnonymous]
	public async Task<IActionResult> ResendEmailActivationAsync(
		string email)
	{
		ResendEmailTokenCommand command = new ResendEmailTokenCommand()
		{
			Email = email
		};
		var result = await Mediator.Send(command);

		return Ok(result);
	}
}
