using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Shared.Constants;

namespace FrontDeskApp.Application.Common.Results;

/// <summary>
/// An abstract object that contains all required properties for paging and including the error handler.
/// </summary>
[ExcludeFromCodeCoverage]
public abstract class PagingResult : ErrorResult
{
	public bool IsPagingEnabled { get; set; }

	public int CurrentPage { get; init; }
	public Shared.Enums.PageSize PageSize { get; set; } = DefaultValues.DefaultPageSize;
	public int TotalPages { get; init; }
	public int TotalRecords { get; set; }
	public bool HasNextPage => CurrentPage < TotalPages;
	public bool HasPrevPage => CurrentPage > 0;
}
