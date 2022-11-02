using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.Accounts.Commands.Register;

/// <summary>
/// The command that handles the register request.
/// </summary>
[ExcludeFromCodeCoverage]
public sealed class RegisterCommand : IRequest<DtoResult<AccountDto.RegisterResponseDto>>
{
	public AccountDto.RegisterDto Dto { get; set; }
}

internal sealed class RegisterAccountCommandHandler :
	IRequestHandler<RegisterCommand, DtoResult<AccountDto.RegisterResponseDto>>
{
	private readonly IIdentityService _service;

	public RegisterAccountCommandHandler(
		IIdentityService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}

	public async Task<DtoResult<AccountDto.RegisterResponseDto>> Handle(
		RegisterCommand request,
		CancellationToken cancellationToken)
	{
		// Sets the value of the username same as the email
		request.Dto.UserName = request.Dto.Email;

		var valOutput = (new RegisterCommandValidator()).Validate(request);
		if (valOutput.IsValid)
		{
			return await _service.CreateUserAsync(request.Dto, cancellationToken);
		}

		var result = new DtoResult<AccountDto.RegisterResponseDto>(
			valOutput.Errors
				.Select(_ => _.ErrorMessage).ToList());

		return result;
	}
}
