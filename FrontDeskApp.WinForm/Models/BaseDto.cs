using System.Diagnostics.CodeAnalysis;

namespace FrontDeskApp.WinForm.Models;

/// <summary>
/// A base class that contains the generic guid id for dto.
/// </summary>
[ExcludeFromCodeCoverage]
public abstract class BaseDto
{
	/// <summary>
	/// Defines the label for the generic guid id that can be used for display and error messages.
	/// </summary>
	public abstract class Label : AuditDto.Label
	{
		public const string Id = "Primary Id";
	}

	/// <summary>
	/// Defines the generic guid id and includes the audit properties as well.
	/// </summary>
	public abstract class Dto : AuditDto.Dto
	{
		public Guid Id { get; init; }
	}

	/// <summary>
	/// Defines a generic guid id without the auditing properties.
	/// </summary>
	public abstract class IdDto
	{
		public Guid Id { get; init; }
	}
}
