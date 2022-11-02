using FrontDeskApp.Application.Common.Interfaces.Repositories;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Services;
using FrontDeskApp.Application.StorageTypes;
using FrontDeskApp.Domain.Entities;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace FrontDeskApp.Infrastructure.Services;

internal sealed class StorageTypeService : BaseService<StorageType, StorageTypeDto.Dto>, IStorageTypeService
{
	public StorageTypeService(
		IStorageTypeRepository repository,
		ILogger<BaseService<StorageType, StorageTypeDto.Dto>> logger,
		IMapper mapper) : base(repository, logger, mapper)
	{
	}
}
