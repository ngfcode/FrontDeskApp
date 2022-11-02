using FrontDeskApp.Application.Common.Interfaces.Repositories;
using FrontDeskApp.Application.Common.Interfaces.Services;
using FrontDeskApp.Application.Common.Services;
using FrontDeskApp.Application.Customers;
using FrontDeskApp.Domain.Entities;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace FrontDeskApp.Infrastructure.Services;

internal sealed class CustomerService : BaseService<Customer, CustomerDto.Dto>, ICustomerService
{
	public CustomerService(
		ICustomerRepository repository,
		ILogger<BaseService<Customer, CustomerDto.Dto>> logger,
		IMapper mapper) : base(repository, logger, mapper)
	{
	}
}
