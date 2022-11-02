using Ardalis.GuardClauses;
using Ardalis.Specification;
using FrontDeskApp.Application.Common.Extensions;
using FrontDeskApp.Domain.Entities;
using static FrontDeskApp.Application.StorageTypes.StorageTypeDto;

namespace FrontDeskApp.Application.StorageTypes.Specifications;

internal class StorageTypeBySearchCriteriaSpec : Specification<StorageType>
{
	public StorageTypeBySearchCriteriaSpec(
		SearchCriteria searchCriteria)
	{
		Guard.Against.Null(searchCriteria, nameof(searchCriteria));

		#region Sets the criteria
		searchCriteria.Code = searchCriteria.Code?.Trim().ToUpper();
		searchCriteria.Name = searchCriteria.Name?.Trim();

		if (!string.IsNullOrEmpty(searchCriteria.Code))
		{
			Query.Where(_ => _.Code == searchCriteria.Code);
		}

		if (!string.IsNullOrEmpty(searchCriteria.Name))
		{
			Query.Search(_ => _.Name, $"%{searchCriteria.Name}%");
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
			Query.Include(_ => _.Storages);
		}
		#endregion

		#region Sorting
		if (!string.IsNullOrEmpty(searchCriteria.OrderBy))
		{
			Query.OrderBy(searchCriteria.OrderBy, searchCriteria.IsAscendingOrder);
		}

		else
		{
			Query.OrderBy(_ => _.Code);
		}
		#endregion
	}
}
