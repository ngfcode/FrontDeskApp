using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Domain.Common;
using FrontDeskApp.Shared.Constants;

namespace FrontDeskApp.Domain.Entities;

/// <summary>
/// This class represents the Storage table
/// </summary>
[ExcludeFromCodeCoverage]
public class Storage : BaseEntity
{
	[Required]
	[ForeignKey(nameof(StorageType))]
	public Guid StorageTypeId { get; set; }

	[Required]
	[MaxLength(MaxLengths.Storage.Location)]
	public string Location { get; set; }

	[Required]
	public bool IsAvailable { get; set; }

	public virtual StorageType StorageType { get; set; }
}
