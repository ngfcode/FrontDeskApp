using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using MediatR;

namespace FrontDeskApp.Application.Accounts.Commands.Logoff;

/// <summary>
/// The command that handles the logoff request.
/// </summary>
[ExcludeFromCodeCoverage]
public sealed class LogoffCommand : IRequest
{
	public AccountDto.LogoffDto Dto { get; set; }
}

internal sealed class LogoffAccountCommandHandler : IRequestHandler<LogoffCommand>
{
	private readonly IIdentityService _service;

	public LogoffAccountCommandHandler(
		IIdentityService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}

	public async Task<Unit> Handle(
		LogoffCommand request,
		CancellationToken cancellationToken)
	{
		await _service.LogoffAsync(cancellationToken);
		return Unit.Value;
	}
}
