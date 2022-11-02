using System.Diagnostics.CodeAnalysis;

namespace FrontDeskApp.Application.Common.Results;

/// <summary>
/// A return object based from a query, the T defines the object type of the Result property.
/// </summary>
/// <typeparam name="T">The object type of the Result property.</typeparam>
[ExcludeFromCodeCoverage]
public class QueryResult<T> : PagingResult
{
	public IEnumerable<T> Result { get; init; } = new List<T>();

	public QueryResult()
	{
	}

	public QueryResult(
		IList<T> items)
	{
		Result = items;
		TotalRecords = items.Count;
	}

	public QueryResult(
		IList<T> items,
		int count,
		int pageNumber,
		int pageSize)
	{
		if (items?.Count > 0)
		{

			Result = items;

			TotalRecords = count;
			CurrentPage = pageNumber;
			PageSize = (Shared.Enums.PageSize)pageSize;
			TotalPages = (int)Math.Ceiling(count / (double)pageSize);

		}
	}

	public QueryResult(
		string errorMessage)
	{
		Errors.Add(errorMessage);
	}

	public QueryResult(
		List<string> errorMessages)
	{
		Errors.AddRange(errorMessages);
	}
}
