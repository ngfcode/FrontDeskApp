using FrontDeskApp.Domain.Entities;

namespace FrontDeskApp.Application.Common.Interfaces.Repositories;

/// <summary>
/// An interface for performing the command transactions of Customer.
/// </summary>
/// <typeparam name="Customer">The entity to be used for transactions.</typeparam>
public interface ICustomerRepository : IRepository<Customer>
{
}
