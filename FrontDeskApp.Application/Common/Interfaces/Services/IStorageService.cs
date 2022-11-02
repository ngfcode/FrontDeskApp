using FrontDeskApp.Application.Storages;
using FrontDeskApp.Domain.Entities;

namespace FrontDeskApp.Application.Common.Interfaces.Services;

/// <summary>
/// An interface that defines all query methods.
/// </summary>
/// <typeparam name="Storage">The entity object to use for retrieving data.</typeparam>
/// <typeparam name="StorageDto.Dto">The expected dto object to be returned.</typeparam>
public interface IStorageService : IService<Storage, StorageDto.Dto>
{
}
