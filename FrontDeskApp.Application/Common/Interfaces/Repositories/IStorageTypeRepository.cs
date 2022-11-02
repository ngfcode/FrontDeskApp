using FrontDeskApp.Domain.Entities;

namespace FrontDeskApp.Application.Common.Interfaces.Repositories;

/// <summary>
/// An interface for performing the command transactions of StorageType.
/// </summary>
/// <typeparam name="StorageType">The entity to be used for transactions.</typeparam>
public interface IStorageTypeRepository : IRepository<StorageType>
{
}
