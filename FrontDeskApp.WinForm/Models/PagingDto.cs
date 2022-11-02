﻿using System.Diagnostics.CodeAnalysis;

namespace FrontDeskApp.WinForm.Models;

/// <summary>
/// Defines all properties for setting the paging information of a query.
/// </summary>
[ExcludeFromCodeCoverage]
public abstract class PagingDto
{
	public bool IsPagingEnabled { get; set; } = true;
	public bool IsAscendingOrder { get; set; } = true;
	public int CurrentPage { get; set; } = 0;
	public int PageSize { get; set; } = (int)FrontDeskApp.Shared.Enums.PageSize.Default;
	public string OrderBy { get; set; }
}
