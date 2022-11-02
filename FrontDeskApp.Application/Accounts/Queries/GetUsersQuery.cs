using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.Accounts.Queries;

/// <summary>
/// This is the request receiver for getting all accounts based on the given criteria.
/// </summary>
[ExcludeFromCodeCoverage]
public sealed class GetUsersQuery : IRequest<QueryResult<AccountDto.QueryDto>>
{
	public AccountDto.SearchCriteria SearchCriteria { get; set; }
}

public sealed class GetUsersQueryHandler :
	IRequestHandler<GetUsersQuery, QueryResult<AccountDto.QueryDto>>
{
	private readonly IIdentityService _service;

	public GetUsersQueryHandler(
		IIdentityService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}

	public async Task<QueryResult<AccountDto.QueryDto>> Handle(
		GetUsersQuery request,
		CancellationToken cancellationToken)
	{
		return await _service.ListUsersAsync(request.SearchCriteria, cancellationToken);
	}
}
