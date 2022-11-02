using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Application.Customers;
using FrontDeskApp.Domain.Entities;
using Mapster;

namespace FrontDeskApp.Infrastructure.Mappings;

[ExcludeFromCodeCoverage]
public sealed class CustomerMappingConfig : IRegister
{
	public void Register(
		TypeAdapterConfig config)
	{
		config.NewConfig<Customer, CustomerDto.Dto>();
		config.NewConfig<Customer, CustomerDto.CreateDto>();
		config.NewConfig<Customer, CustomerDto.DeleteDto>();
		config.NewConfig<Customer, CustomerDto.UpdateDto>();
		config.NewConfig<Customer, CustomerDto.QueryDto>()
			.Map(dest => dest.CustomerName, src => $"{src.FirstName} {src.LastName}");

		config.NewConfig<CustomerDto.Dto, Customer>();
		config.NewConfig<CustomerDto.CreateDto, Customer>();
		config.NewConfig<CustomerDto.DeleteDto, Customer>();
		config.NewConfig<CustomerDto.UpdateDto, Customer>();
		config.NewConfig<CustomerDto.QueryDto, Customer>();
	}
}
