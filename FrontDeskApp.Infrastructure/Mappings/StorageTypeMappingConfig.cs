using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.StorageTypes;
using FrontDeskApp.Domain.Entities;
using Mapster;

namespace FrontDeskApp.Infrastructure.Mappings;

[ExcludeFromCodeCoverage]
public sealed class StorageTypeMappingConfig : IRegister
{
	public void Register(
		TypeAdapterConfig config)
	{
		config.NewConfig<StorageType, StorageTypeDto.Dto>();
		config.NewConfig<StorageType, StorageTypeDto.CreateDto>();
		config.NewConfig<StorageType, StorageTypeDto.DeleteDto>();
		config.NewConfig<StorageType, StorageTypeDto.UpdateDto>();
		config.NewConfig<StorageType, StorageTypeDto.QueryDto>()
			.Map(dest => dest.TotalStorage, src => src.Storages.Count())
			.Map(dest => dest.TotalAvailable, src => src.Storages.Where(_ => _.IsAvailable).Count());

		config.NewConfig<StorageTypeDto.Dto, StorageType>();
		config.NewConfig<StorageTypeDto.CreateDto, StorageType>();
		config.NewConfig<StorageTypeDto.DeleteDto, StorageType>();
		config.NewConfig<StorageTypeDto.UpdateDto, StorageType>();
		config.NewConfig<StorageTypeDto.QueryDto, StorageType>();
	}
}
