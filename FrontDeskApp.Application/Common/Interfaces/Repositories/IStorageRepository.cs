using FrontDeskApp.Domain.Entities;

namespace FrontDeskApp.Application.Common.Interfaces.Repositories;

/// <summary>
/// An interface for performing the command transactions of Storage.
/// </summary>
/// <typeparam name="Storage">The entity to be used for transactions.</typeparam>
public interface IStorageRepository : IRepository<Storage>
{
}
