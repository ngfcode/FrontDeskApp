using Ardalis.GuardClauses;
using FrontDeskApp.Application.Common.Interfaces.Repositories;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Results;
using FrontDeskApp.Application.Common.Services;
using FrontDeskApp.Application.StorageOrders;
using FrontDeskApp.Domain.Entities;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace FrontDeskApp.Infrastructure.Services;

internal sealed class StorageOrderService : BaseService<StorageOrder, StorageOrderDto.Dto>, IStorageOrderService
{
	private readonly IStorageRepository _repoStorage;

	public StorageOrderService(
		IStorageOrderRepository repository,
		IStorageRepository repoStorage,
		ILogger<BaseService<StorageOrder, StorageOrderDto.Dto>> logger,
		IMapper mapper) : base(repository, logger, mapper)
	{
		_repoStorage = Guard.Against.Null(repoStorage, nameof(repoStorage));
	}

	public override async Task<DtoResult<StorageOrderDto.Dto>> AddAsync(
		StorageOrderDto.Dto dto,
		CancellationToken cancellationToken = default)
	{
		// Update the Storage
		var storageEntity = await _repoStorage.GetByIdAsync(dto.StorageId, cancellationToken);
		storageEntity.IsAvailable = false;

		var resultStorage = await _repoStorage.UpdateAsync(storageEntity, cancellationToken);
		if (resultStorage is not null)
		{
			// Add Storage Order
			return await base.AddAsync(dto, cancellationToken);
		}

		return new DtoResult<StorageOrderDto.Dto>("Error updating the Storage.");
	}

	public override async Task<DtoResult<StorageOrderDto.Dto>> UpdateAsync(
		StorageOrderDto.Dto dto,
		CancellationToken cancellationToken = default)
	{
		// Update the Storage
		var storageEntity = await _repoStorage.GetByIdAsync(dto.StorageId, cancellationToken);
		storageEntity.IsAvailable = true;

		var resultStorage = await _repoStorage.UpdateAsync(storageEntity, cancellationToken);
		if (resultStorage is not null)
		{
			// Add Storage Order
			return await base.UpdateAsync(dto, cancellationToken);
		}

		return new DtoResult<StorageOrderDto.Dto>("Error updating the Storage.");
	}
}
