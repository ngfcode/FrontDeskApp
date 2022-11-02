using Ardalis.GuardClauses;
using Ardalis.Specification;
using FrontDeskApp.Application.Common.Extensions;
using FrontDeskApp.Domain.Entities;
using static FrontDeskApp.Application.StorageOrders.StorageOrderDto;

namespace FrontDeskApp.Application.StorageOrders.Specifications;

internal class StorageOrderBySearchCriteriaSpec : Specification<StorageOrder>
{
	public StorageOrderBySearchCriteriaSpec(
		SearchCriteria searchCriteria)
	{
		Guard.Against.Null(searchCriteria, nameof(searchCriteria));

		#region Sets the criteria
		searchCriteria.StorageLocation = searchCriteria.StorageLocation?.Trim().ToUpper();

		if (searchCriteria.CustomerId is not null && searchCriteria.CustomerId != Guid.Empty)
		{
			Query.Where(_ => _.CustomerId == searchCriteria.CustomerId);
		}

		if (searchCriteria.StorageTypeId is not null && searchCriteria.StorageTypeId != Guid.Empty)
		{
			Query.Where(_ => _.Storage.StorageTypeId == searchCriteria.StorageTypeId);
		}

		if (searchCriteria.StorageLocation is not null)
		{
			Query.Where(_ => _.Storage.Location == searchCriteria.StorageLocation);
		}
		#endregion

		#region Checks for paging
		if (searchCriteria.IsPagingEnabled)
		{

			int index = searchCriteria.CurrentPage * searchCriteria.PageSize;
			Query.Skip(index).Take(searchCriteria.PageSize);

		}
		#endregion

		#region Include related entities
		if (searchCriteria.LoadChildren)
		{
			Query
				.Include(_ => _.Customer)
				.Include(_ => _.Storage);
		}
		#endregion

		#region Sorting
		if (!string.IsNullOrEmpty(searchCriteria.OrderBy))
		{
			Query.OrderBy(searchCriteria.OrderBy, searchCriteria.IsAscendingOrder);
		}

		else
		{
			Query.OrderBy(_ => _.StoredDate);
		}
		#endregion
	}
}
