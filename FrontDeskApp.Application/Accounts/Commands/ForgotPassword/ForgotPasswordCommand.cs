using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.Accounts.Commands.ForgotPassword;

/// <summary>
/// The command that handles the forgot password request.
/// </summary>
[ExcludeFromCodeCoverage]
public sealed class ForgotPasswordCommand : IRequest<DtoResult<AccountDto.ActivateEmailResponseDto>>
{
	public string Email { get; set; }
}

internal sealed class ForgotPasswordCommandHandler :
	IRequestHandler<ForgotPasswordCommand, DtoResult<AccountDto.ActivateEmailResponseDto>>
{
	private readonly IIdentityService _service;

	public ForgotPasswordCommandHandler(
		IIdentityService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}
	public async Task<DtoResult<AccountDto.ActivateEmailResponseDto>> Handle(
		ForgotPasswordCommand request,
		CancellationToken cancellationToken)
	{
		var valOutput = (new ForgotPasswordCommandValidator()).Validate(request);
		if (valOutput.IsValid)
		{
			return await _service.ForgotPasswordAsync(request.Email, cancellationToken);
		}

		var result = new DtoResult<AccountDto.ActivateEmailResponseDto>(
			valOutput.Errors
				.Select(_ => _.ErrorMessage).ToList());

		return result;
	}
}
