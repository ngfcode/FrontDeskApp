using FrontDeskApp.Domain.Entities;

namespace FrontDeskApp.Application.Common.Interfaces.Repositories;

/// <summary>
/// An interface for performing the command transactions of StorageOrder.
/// </summary>
/// <typeparam name="StorageOrder">The entity to be used for transactions.</typeparam>
public interface IStorageOrderRepository : IRepository<StorageOrder>
{
}
