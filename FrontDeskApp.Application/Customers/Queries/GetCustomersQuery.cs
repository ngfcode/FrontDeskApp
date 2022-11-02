using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using FrontDeskApp.Application.Customers.Specifications;
using MediatR;

namespace FrontDeskApp.Application.Customers.Queries;

[ExcludeFromCodeCoverage]
public class GetCustomersQuery : IRequest<QueryResult<CustomerDto.QueryDto>>
{
	public CustomerDto.SearchCriteria SearchCriteria { get; set; }
}

public sealed class GetCustomersQueryHandler :
	IRequestHandler<GetCustomersQuery, QueryResult<CustomerDto.QueryDto>>
{
	private readonly ICustomerService _service;

	public GetCustomersQueryHandler(
		ICustomerService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}
	public async Task<QueryResult<CustomerDto.QueryDto>> Handle(
		GetCustomersQuery request,
		CancellationToken cancellationToken)
	{
		return await _service.ListBySpecificationAsync<CustomerDto.QueryDto>(
			new CustomerBySearchCriteriaSpec(request.SearchCriteria),
			request.SearchCriteria.CurrentPage,
			request.SearchCriteria.PageSize,
			cancellationToken);
	}
}

