using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FrontDeskApp.Domain.Common;

/// <summary>
/// This base class contains the generic guid id used by every entity, as well as the audit entity.
/// </summary>
[ExcludeFromCodeCoverage]
public abstract class BaseEntity : AuditEntity
{
	[Key]
	public Guid Id { get; set; }
}
