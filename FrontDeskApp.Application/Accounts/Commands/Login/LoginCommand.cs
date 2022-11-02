using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.Accounts.Commands.Login;

/// <summary>
/// The command object that handles the login request.
/// </summary>
[ExcludeFromCodeCoverage]
public sealed class LoginCommand : IRequest<DtoResult<AccountDto.LoginResponseDto>>
{
	public AccountDto.LoginDto Dto { get; set; }
}

internal sealed class LoginAccountCommandHandler : IRequestHandler<LoginCommand, DtoResult<AccountDto.LoginResponseDto>>
{
	private readonly IIdentityService _service;

	public LoginAccountCommandHandler(
		IIdentityService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}

	public async Task<DtoResult<AccountDto.LoginResponseDto>> Handle(
		LoginCommand request,
		CancellationToken cancellationToken)
	{
		var valOutput = (new LoginCommandValidator()).Validate(request);
		if (valOutput.IsValid)
		{
			return await _service.LoginAsync(request.Dto, cancellationToken);
		}

		var result = new DtoResult<AccountDto.LoginResponseDto>(
			valOutput.Errors
				.Select(_ => _.ErrorMessage).ToList());

		return result;
	}
}
