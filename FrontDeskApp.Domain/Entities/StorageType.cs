using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Domain.Common;
using FrontDeskApp.Shared.Constants;

namespace FrontDeskApp.Domain.Entities;

/// <summary>
/// This class represents the Storage Type table
/// </summary>
[ExcludeFromCodeCoverage]
public class StorageType : BaseEntity
{
	[Required]
	[MaxLength(MaxLengths.StorageType.Code)]
	public string Code { get; set; }

	[Required]
	[MaxLength(MaxLengths.StorageType.Name)]
	public string Name { get; set; }

	[MaxLength(MaxLengths.StorageType.Description)]
	public string Description { get; set; }

	[Required]
	public int SizeType { get; set; }

	public virtual IEnumerable<Storage> Storages { get; set; }
}
