using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.Accounts.Commands.RevokeAll;

/// <summary>
/// The command that handles the refresh token request.
/// </summary>
[ExcludeFromCodeCoverage]
public sealed class RevokeAllCommand : IRequest<Result>
{
}

internal sealed class RevokeAllCommandHandler : IRequestHandler<RevokeAllCommand, Result>
{
	private readonly IIdentityService _service;

	public RevokeAllCommandHandler(
		IIdentityService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}

	public async Task<Result> Handle(
		RevokeAllCommand request,
		CancellationToken cancellationToken)
	{
		await _service.RevokeAllAsync(cancellationToken);

		return Result.Success();
	}
}
