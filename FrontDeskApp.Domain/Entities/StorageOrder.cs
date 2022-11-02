using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Domain.Common;

namespace FrontDeskApp.Domain.Entities;

/// <summary>
/// This class represents the StorageOrder table
/// </summary>
[ExcludeFromCodeCoverage]
public class StorageOrder : BaseEntity
{
	[Required]
	[ForeignKey(nameof(Customer))]
	public Guid CustomerId { get; set; }

	[Required]
	[ForeignKey(nameof(Storage))]
	public Guid StorageId { get; set; }

	[Required]
	public DateTime StoredDate { get; set; }

	[Required]
	public int BoxSize { get; set; }

	public DateTime? RetrievedDate { get; set; }

	public virtual Customer Customer { get; set; }
	public virtual Storage Storage { get; set; }
}
