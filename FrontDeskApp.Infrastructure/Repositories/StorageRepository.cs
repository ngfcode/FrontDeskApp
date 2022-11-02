using FrontDeskApp.Application.Common.Interfaces;
using FrontDeskApp.Application.Common.Interfaces.Repositories;
using FrontDeskApp.Application.Common.Repositories;
using FrontDeskApp.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace FrontDeskApp.Infrastructure.Repositories;

internal sealed class StorageRepository : BaseRepository<Storage>, IStorageRepository
{
	public StorageRepository(
		IAppDbContext dbContext,
		ILogger<BaseRepository<Storage>> logger) : base(dbContext, logger)
	{
	}
}
