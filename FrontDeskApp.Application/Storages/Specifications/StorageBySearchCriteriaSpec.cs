using Ardalis.GuardClauses;
using Ardalis.Specification;
using FrontDeskApp.Application.Common.Extensions;
using FrontDeskApp.Domain.Entities;
using static FrontDeskApp.Application.Storages.StorageDto;

namespace FrontDeskApp.Application.Storages.Specifications;

internal class StorageBySearchCriteriaSpec : Specification<Storage>
{
	public StorageBySearchCriteriaSpec(
		SearchCriteria searchCriteria)
	{
		Guard.Against.Null(searchCriteria, nameof(searchCriteria));

		#region Sets the criteria
		searchCriteria.Code = searchCriteria.Code?.Trim().ToUpper();
		searchCriteria.Name = searchCriteria.Name?.Trim();

		if (searchCriteria.Id is not null && searchCriteria.Id != Guid.Empty)
		{
			Query.Where(_ => _.Id == searchCriteria.Id);
		}

		if (searchCriteria.StorageTypeId is not null && searchCriteria.StorageTypeId != Guid.Empty)
		{
			Query.Where(_ => _.StorageTypeId == searchCriteria.StorageTypeId);
		}

		if (searchCriteria.SizeType is not null)
		{
			Query.Where(_ => _.StorageType.SizeType == searchCriteria.SizeType);
		}

		if (searchCriteria.IsAvailable is not null)
		{
			Query.Where(_ => _.IsAvailable == searchCriteria.IsAvailable);
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
			Query.Include(_ => _.StorageType);
		}
		#endregion


		#region Sorting
		if (!string.IsNullOrEmpty(searchCriteria.OrderBy))
		{
			Query.OrderBy(searchCriteria.OrderBy, searchCriteria.IsAscendingOrder);
		}

		else
		{
			Query.OrderBy(_ => _.StorageType.Code).ThenBy(_ => _.Location);
		}
		#endregion
	}
}
