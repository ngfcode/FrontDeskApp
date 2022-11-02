using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace FrontDeskApp.WinForm.Models;

/// <summary>
/// Defines the generic search criteria object for filtering a query.
/// </summary>
[ExcludeFromCodeCoverage]
public class SearchCriteriaDto : PagingDto
{
	[Browsable(false)]
	[JsonIgnore]
	// Determines if related tables will be inclded during query or not.
	public bool LoadChildren { get; set; }

	public Guid? Id { get; set; }
	public string Code { get; set; }
	public string Name { get; set; }
	public bool? IsActive { get; set; }

	// Can be used for filtering the query with single search criteria field.
	public string Filters { get; set; }
}
