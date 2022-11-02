using FrontDeskApp.Application.Common.Interfaces;
using FrontDeskApp.Application.Common.Interfaces.Repositories;
using FrontDeskApp.Application.Common.Repositories;
using FrontDeskApp.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace FrontDeskApp.Infrastructure.Repositories;

internal sealed class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
	public CustomerRepository(
		IAppDbContext dbContext,
		ILogger<BaseRepository<Customer>> logger) : base(dbContext, logger)
	{
	}
}
