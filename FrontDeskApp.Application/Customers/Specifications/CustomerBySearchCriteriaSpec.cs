using Ardalis.GuardClauses;
using Ardalis.Specification;
using FrontDeskApp.Domain.Entities;
using static FrontDeskApp.Application.Customers.CustomerDto;

namespace FrontDeskApp.Application.Customers.Specifications;

internal class CustomerBySearchCriteriaSpec : Specification<Customer>
{
	public CustomerBySearchCriteriaSpec(
		SearchCriteria searchCriteria)
	{
		Guard.Against.Null(searchCriteria, nameof(searchCriteria));

		#region Sets the criteria
		searchCriteria.FirstName = searchCriteria.FirstName?.Trim();
		searchCriteria.LastName = searchCriteria.LastName?.Trim();

		if (string.IsNullOrEmpty(searchCriteria.FirstName))
		{
			Query.Search(_ => _.FirstName, $"%{searchCriteria.FirstName}%");
		}

		if (string.IsNullOrEmpty(searchCriteria.LastName))
		{
			Query.Search(_ => _.LastName, $"%{searchCriteria.LastName}%");
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
		#endregion
	}
}
