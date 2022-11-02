using FrontDeskApp.Application.Common.Interfaces;
using FrontDeskApp.Application.Common.Interfaces.Repositories;
using FrontDeskApp.Application.Common.Repositories;
using FrontDeskApp.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace FrontDeskApp.Infrastructure.Repositories;

internal sealed class StorageOrderRepository : BaseRepository<StorageOrder>, IStorageOrderRepository
{
	public StorageOrderRepository(
		IAppDbContext dbContext,
		ILogger<BaseRepository<StorageOrder>> logger) : base(dbContext, logger)
	{
	}
}
