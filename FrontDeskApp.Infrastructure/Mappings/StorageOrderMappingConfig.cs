using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.StorageOrders;
using FrontDeskApp.Domain.Entities;
using Mapster;

namespace FrontDeskApp.Infrastructure.Mappings;

[ExcludeFromCodeCoverage]
public sealed class StorageOrderMappingConfig : IRegister
{
	public void Register(
		TypeAdapterConfig config)
	{
		config.NewConfig<StorageOrder, StorageOrderDto.Dto>();
		config.NewConfig<StorageOrder, StorageOrderDto.CreateDto>();
		config.NewConfig<StorageOrder, StorageOrderDto.DeleteDto>();
		config.NewConfig<StorageOrder, StorageOrderDto.UpdateDto>();
		config.NewConfig<StorageOrder, StorageOrderDto.QueryDto>()
			.Map(dest => dest.Customer, src => $"{src.Customer.FirstName} {src.Customer.LastName}")
			.Map(dest => dest.StorageLocation, src => src.Storage.Location);

		config.NewConfig<StorageOrderDto.Dto, StorageOrder>();
		config.NewConfig<StorageOrderDto.CreateDto, StorageOrder>();
		config.NewConfig<StorageOrderDto.DeleteDto, StorageOrder>();
		config.NewConfig<StorageOrderDto.UpdateDto, StorageOrder>();
		config.NewConfig<StorageOrderDto.QueryDto, StorageOrder>();
	}
}
