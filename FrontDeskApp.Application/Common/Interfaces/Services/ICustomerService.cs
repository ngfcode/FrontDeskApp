using FrontDeskApp.Application.Customers;
using FrontDeskApp.Domain.Entities;

namespace FrontDeskApp.Application.Common.Interfaces.Services;

/// <summary>
/// An interface that defines all query methods.
/// </summary>
/// <typeparam name="Customer">The entity object to use for retrieving data.</typeparam>
/// <typeparam name="CustomerDto.Dto">The expected dto object to be returned.</typeparam>
public interface ICustomerService : IService<Customer, CustomerDto.Dto>
{
}
