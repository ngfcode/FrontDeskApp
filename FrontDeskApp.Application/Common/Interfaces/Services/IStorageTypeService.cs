using FrontDeskApp.Application.StorageTypes;
using FrontDeskApp.Domain.Entities;

namespace FrontDeskApp.Application.Common.Interfaces.Services;

/// <summary>
/// An interface that defines all query methods.
/// </summary>
/// <typeparam name="StorageType">The entity object to use for retrieving data.</typeparam>
/// <typeparam name="StorageTypeDto.Dto">The expected dto object to be returned.</typeparam>
public interface IStorageTypeService : IService<StorageType, StorageTypeDto.Dto>
{
}
