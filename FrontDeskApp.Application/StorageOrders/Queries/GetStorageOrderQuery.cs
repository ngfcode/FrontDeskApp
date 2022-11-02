using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using MediatR;

namespace FrontDeskApp.Application.StorageOrders.Queries;

[ExcludeFromCodeCoverage]
public sealed class GetStorageOrderQuery : IRequest<DtoResult<StorageOrderDto.Dto>>
{
	public Guid Id { get; set; }
}

public sealed class GetStorageOrderQueryHandler :
	IRequestHandler<GetStorageOrderQuery, DtoResult<StorageOrderDto.Dto>>
{
	private readonly IStorageOrderService _service;

	public GetStorageOrderQueryHandler(
		IStorageOrderService service)
	{
		_service = Guard.Against.Null(service, nameof(service));
	}

	public async Task<DtoResult<StorageOrderDto.Dto>> Handle(
		GetStorageOrderQuery request,
		CancellationToken cancellationToken)
	{
		return await _service.GetByIdAsync(request.Id,
			cancellationToken);
	}
}
