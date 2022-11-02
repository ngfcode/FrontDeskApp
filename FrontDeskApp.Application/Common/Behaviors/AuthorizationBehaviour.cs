using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using MediatR;

namespace FrontDeskApp.Application.Common.Behaviors;

/// <summary>
/// A pipeline behavior that handles authorization validation prior to executing the command.
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
[ExcludeFromCodeCoverage]
public sealed class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
{
	private readonly ICurrentUserService _currentUserService;
	private readonly IIdentityService _identityService;

	public AuthorizationBehaviour(
		ICurrentUserService currentUserService,
		IIdentityService identityService)
	{
		_currentUserService = Guard.Against.Null(currentUserService, nameof(currentUserService));
		_identityService = Guard.Against.Null(identityService, nameof(identityService)); ;
	}

	public Task<TResponse> Handle(
		TRequest request,
		CancellationToken cancellationToken,
		RequestHandlerDelegate<TResponse> next)
	{
		throw new NotImplementedException();
	}
}
