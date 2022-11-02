using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.Accounts.Commands.ResendEmailToken;

/// <summary>
/// The command that handles the resend email token request.
/// </summary>
[ExcludeFromCodeCoverage]
public sealed class ResendEmailTokenCommand : IRequest<DtoResult<AccountDto.ActivateEmailResponseDto>>
{
	public string Email { get; set; }
}

internal sealed class ResendEmailTokenCommandHandler :
	IRequestHandler<ResendEmailTokenCommand, DtoResult<AccountDto.ActivateEmailResponseDto>>
{
	private readonly IIdentityService _service;

	public ResendEmailTokenCommandHandler(
		IIdentityService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}

	public async Task<DtoResult<AccountDto.ActivateEmailResponseDto>> Handle(
		ResendEmailTokenCommand request,
		CancellationToken cancellationToken)
	{
		var valOutput = (new ResendEmailTokenCommandValidator()).Validate(request);
		if (valOutput.IsValid)
		{
			return await _service.ResendEmailConfirmationAsync(request.Email, cancellationToken);
		}

		var result = new DtoResult<AccountDto.ActivateEmailResponseDto>(
			valOutput.Errors
				.Select(_ => _.ErrorMessage).ToList());

		return result;
	}
}
