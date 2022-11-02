using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.Accounts.Commands.ChangePassword;

/// <summary>
/// The command that handles the change password request.
/// </summary>
[ExcludeFromCodeCoverage]
public sealed class ChangePasswordCommand : IRequest<DtoResult<AccountDto.Dto>>
{
	public AccountDto.ChangePasswordDto Dto { get; set; }
}

internal sealed class ChangePasswordCommandHandler :
	IRequestHandler<ChangePasswordCommand, DtoResult<AccountDto.Dto>>
{
	private readonly IIdentityService _service;

	public ChangePasswordCommandHandler(
		IIdentityService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}

	public async Task<DtoResult<AccountDto.Dto>> Handle(
		ChangePasswordCommand request,
		CancellationToken cancellationToken)
	{
		var valOutput = (new ChangePasswordCommandValidator()).Validate(request);
		if (valOutput.IsValid)
		{
			return await _service.ChangePasswordAsync(request.Dto, cancellationToken);
		}

		var result = new DtoResult<AccountDto.Dto>(
			valOutput.Errors
				.Select(_ => _.ErrorMessage).ToList());

		return result;
	}
}
