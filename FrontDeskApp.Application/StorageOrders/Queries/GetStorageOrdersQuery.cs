using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using FrontDeskApp.Application.StorageOrders.Specifications;
using MediatR;

namespace FrontDeskApp.Application.StorageOrders.Queries;

[ExcludeFromCodeCoverage]
public class GetStorageOrdersQuery : IRequest<QueryResult<StorageOrderDto.QueryDto>>
{
	public StorageOrderDto.SearchCriteria SearchCriteria { get; set; }
}

public sealed class GetStorageOrdersQueryHandler :
	IRequestHandler<GetStorageOrdersQuery, QueryResult<StorageOrderDto.QueryDto>>
{
	private readonly IStorageOrderService _service;

	public GetStorageOrdersQueryHandler(
		IStorageOrderService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}
	public async Task<QueryResult<StorageOrderDto.QueryDto>> Handle(
		GetStorageOrdersQuery request,
		CancellationToken cancellationToken)
	{
		return await _service.ListBySpecificationAsync<StorageOrderDto.QueryDto>(
			new StorageOrderBySearchCriteriaSpec(request.SearchCriteria),
			request.SearchCriteria.CurrentPage,
			request.SearchCriteria.PageSize,
			cancellationToken);
	}
}

