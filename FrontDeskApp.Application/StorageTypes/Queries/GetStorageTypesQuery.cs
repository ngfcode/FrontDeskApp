using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using FrontDeskApp.Application.StorageTypes.Specifications;
using MediatR;

namespace FrontDeskApp.Application.StorageTypes.Queries;

[ExcludeFromCodeCoverage]
public class GetStorageTypesQuery : IRequest<QueryResult<StorageTypeDto.QueryDto>>
{
	public StorageTypeDto.SearchCriteria SearchCriteria { get; set; }
}

public sealed class GetStorageTypeTypesQueryHandler :
	IRequestHandler<GetStorageTypesQuery, QueryResult<StorageTypeDto.QueryDto>>
{
	private readonly IStorageTypeService _service;

	public GetStorageTypeTypesQueryHandler(
		IStorageTypeService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}
	public async Task<QueryResult<StorageTypeDto.QueryDto>> Handle(
		GetStorageTypesQuery request,
		CancellationToken cancellationToken)
	{
		return await _service.ListBySpecificationAsync<StorageTypeDto.QueryDto>(
			new StorageTypeBySearchCriteriaSpec(request.SearchCriteria),
			request.SearchCriteria.CurrentPage,
			request.SearchCriteria.PageSize,
			cancellationToken);
	}
}

