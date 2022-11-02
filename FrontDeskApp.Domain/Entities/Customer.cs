using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Domain.Common;
using FrontDeskApp.Shared.Constants;

namespace FrontDeskApp.Domain.Entities;

/// <summary>
/// This class represents the Customer table
/// </summary>
[ExcludeFromCodeCoverage]
public class Customer : BaseEntity
{
	[Required]
	[MaxLength(MaxLengths.Customer.FirstName)]
	public string FirstName { get; set; }

	[MaxLength(MaxLengths.Customer.MiddleName)]
	public string MiddleName { get; set; }

	[Required]
	[MaxLength(MaxLengths.Customer.LastName)]
	public string LastName { get; set; }

	[MaxLength(MaxLengths.Customer.PhoneNo)]
	public string PhoneNo { get; set; }
}
