using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.Accounts.Commands.ActivateEmail;

/// <summary>
/// The command that handles the activate email request.
/// </summary>
[ExcludeFromCodeCoverage]
public sealed class ActivateEmailCommand : IRequest<DtoResult<AccountDto.ActivateEmailResponseDto>>
{
	public string Email { get; init; }
	public string Token { get; init; }
}

internal sealed class ActivateEmailCommandHandler :
	IRequestHandler<ActivateEmailCommand, DtoResult<AccountDto.ActivateEmailResponseDto>>
{
	private readonly IIdentityService _service;

	public ActivateEmailCommandHandler(
		IIdentityService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}

	public async Task<DtoResult<AccountDto.ActivateEmailResponseDto>> Handle(
		ActivateEmailCommand request,
		CancellationToken cancellationToken)
	{
		var valOutput = (new ActivateEmailCommandValidator()).Validate(request);
		if (valOutput.IsValid)
		{
			return await _service.ActivateEmailAsync(request.Email, request.Token, cancellationToken);
		}

		var result = new DtoResult<AccountDto.ActivateEmailResponseDto>(
			valOutput.Errors
				.Select(_ => _.ErrorMessage).ToList());

		return result;
	}
}
