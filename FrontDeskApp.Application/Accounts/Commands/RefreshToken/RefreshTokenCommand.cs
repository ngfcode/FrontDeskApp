using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.Accounts.Commands.RefreshToken;

/// <summary>
/// The command that handles the refresh token request.
/// </summary>
[ExcludeFromCodeCoverage]
public sealed class RefreshTokenCommand : IRequest<DtoResult<AccountDto.TokenResponseDto>>
{
	public AccountDto.TokenDto Dto { get; set; }
}

internal sealed class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, DtoResult<AccountDto.TokenResponseDto>>
{
	private readonly IIdentityService _service;

	public RefreshTokenCommandHandler(
		IIdentityService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}

	public async Task<DtoResult<AccountDto.TokenResponseDto>> Handle(
		RefreshTokenCommand request,
		CancellationToken cancellationToken)
	{
		var valOutput = (new RefreshTokenCommandValidator()).Validate(request);
		if (valOutput.IsValid)
		{
			return await _service.RefreshTokenAsync(request.Dto, cancellationToken);
		}

		var result = new DtoResult<AccountDto.TokenResponseDto>(
			valOutput.Errors
				.Select(_ => _.ErrorMessage).ToList());

		return result;
	}
}
