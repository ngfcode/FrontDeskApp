using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using FrontDeskApp.Application.Storages.Specifications;
using MediatR;

namespace FrontDeskApp.Application.Storages.Queries;

[ExcludeFromCodeCoverage]
public class GetStoragesQuery : IRequest<QueryResult<StorageDto.QueryDto>>
{
	public StorageDto.SearchCriteria SearchCriteria { get; set; }
}

public sealed class GetStoragesQueryHandler :
	IRequestHandler<GetStoragesQuery, QueryResult<StorageDto.QueryDto>>
{
	private readonly IStorageService _service;

	public GetStoragesQueryHandler(
		IStorageService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}
	public async Task<QueryResult<StorageDto.QueryDto>> Handle(
		GetStoragesQuery request,
		CancellationToken cancellationToken)
	{
		return await _service.ListBySpecificationAsync<StorageDto.QueryDto>(
			new StorageBySearchCriteriaSpec(request.SearchCriteria),
			request.SearchCriteria.CurrentPage,
			request.SearchCriteria.PageSize,
			cancellationToken);
	}
}

