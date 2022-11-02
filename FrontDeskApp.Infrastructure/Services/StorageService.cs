using FrontDeskApp.Application.Common.Interfaces.Repositories;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Services;
using FrontDeskApp.Application.Storages;
using FrontDeskApp.Domain.Entities;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace FrontDeskApp.Infrastructure.Services;

internal sealed class StorageService : BaseService<Storage, StorageDto.Dto>, IStorageService
{
	public StorageService(
		IStorageRepository repository,
		ILogger<BaseService<Storage, StorageDto.Dto>> logger,
		IMapper mapper) : base(repository, logger, mapper)
	{
	}
}
