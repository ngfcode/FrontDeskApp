using FrontDeskApp.Application.StorageOrders;
using FrontDeskApp.Domain.Entities;

namespace FrontDeskApp.Application.Common.Interfaces.Services;

/// <summary>
/// An interface that defines all query methods.
/// </summary>
/// <typeparam name="StorageOrder">The entity object to use for retrieving data.</typeparam>
/// <typeparam name="StorageOrderDto.Dto">The expected dto object to be returned.</typeparam>
public interface IStorageOrderService : IService<StorageOrder, StorageOrderDto.Dto>
{
}
