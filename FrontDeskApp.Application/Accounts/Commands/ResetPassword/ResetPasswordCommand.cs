using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.Accounts.Commands.ResetPassword;

/// <summary>
/// The command thet handles the reset password request.
/// </summary>
[ExcludeFromCodeCoverage]
public sealed class ResetPasswordCommand : IRequest<DtoResult<AccountDto.Dto>>
{
	public AccountDto.ResetPasswordDto Dto { get; set; }
}

internal sealed class ResetPasswordAccountCommandHandler :
	IRequestHandler<ResetPasswordCommand, DtoResult<AccountDto.Dto>>
{
	private readonly IIdentityService _service;

	public ResetPasswordAccountCommandHandler(
		IIdentityService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}
	public async Task<DtoResult<AccountDto.Dto>> Handle(
		ResetPasswordCommand request,
		CancellationToken cancellationToken)
	{
		var valOutput = (new ResetPasswordCommandValidator()).Validate(request);
		if (valOutput.IsValid)
		{
			return await _service.ResetPasswordAsync(request.Dto, cancellationToken);
		}

		var result = new DtoResult<AccountDto.Dto>(
			valOutput.Errors
				.Select(_ => _.ErrorMessage).ToList());

		return result;
	}
}
