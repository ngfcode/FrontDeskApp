using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Shared.Constants;

namespace FrontDeskApp.Domain.Common;

/// <summary>
/// This abstract class is used for auditing purpose, it also contain property for soft deletion.
/// </summary>
[ExcludeFromCodeCoverage]
public abstract class AuditEntity : ISoftDelete
{
	public byte IsSoftDeleted { get; set; } = 0;

	[Column(TypeName = "timestamp")]
	[MaxLength(8)]
	[Timestamp]
	public byte[] Version { get; set; }

	public Guid? CreatedId { get; set; }
	[MaxLength(DefaultValues.NameLength)]
	public string CreatedName { get; set; }
	[Column(TypeName = "datetime")]
	public DateTime? CreatedDateTime { get; set; }

	public Guid? UpdatedId { get; set; }
	[MaxLength(DefaultValues.NameLength)]
	public string UpdatedName { get; set; }
	[Column(TypeName = "datetime")]
	public DateTime? UpdatedDateTime { get; set; }
}
