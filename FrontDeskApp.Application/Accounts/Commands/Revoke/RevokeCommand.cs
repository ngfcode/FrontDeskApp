using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.Accounts.Commands.Revoke;

/// <summary>
/// The command that handles the refresh token request.
/// </summary>
[ExcludeFromCodeCoverage]
public sealed class RevokeCommand : IRequest<Result>
{
	public string UserName { get; set; }
}

internal sealed class RevokeCommandHandler : IRequestHandler<RevokeCommand, Result>
{
	private readonly IIdentityService _service;

	public RevokeCommandHandler(
		IIdentityService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}

	public async Task<Result> Handle(
		RevokeCommand request,
		CancellationToken cancellationToken)
	{
		var valOutput = (new RevokeCommandValidator()).Validate(request);
		if (valOutput.IsValid)
		{
			return await _service.RevokeAsync(request.UserName, cancellationToken);
		}

		return Result.Failure(valOutput.Errors
				.Select(_ => _.ErrorMessage).ToList());
	}
}
