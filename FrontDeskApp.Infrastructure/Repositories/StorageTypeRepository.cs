using FrontDeskApp.Application.Common.Interfaces;
using FrontDeskApp.Application.Common.Interfaces.Repositories;
using FrontDeskApp.Application.Common.Repositories;
using FrontDeskApp.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace FrontDeskApp.Infrastructure.Repositories;

internal sealed class StorageTypeRepository : BaseRepository<StorageType>, IStorageTypeRepository
{
	public StorageTypeRepository(
		IAppDbContext dbContext,
		ILogger<BaseRepository<StorageType>> logger) : base(dbContext, logger)
	{
	}
}
