using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace FrontDeskApp.Application.Common.Dtos;

/// <summary>
/// A base class for creating dtos which includes audit properties.
/// </summary>
[ExcludeFromCodeCoverage]
public abstract class AuditDto
{
	/// <summary>
	/// Defines all audit labels that can be used for display and validation error messages.
	/// </summary>
	public abstract class Label
	{
		public const string Version = "Version";
		public const string CreatedBy = "Created By";
		public const string CreatedDateTime = "Date Created";
		public const string UpdatedBy = "Updated By";
		public const string UpdatedDateTime = "Date Last Updated";
	}

	/// <summary>
	/// Defines all dto properties for auditing.
	/// </summary>
	public abstract class Dto
	{
		[Browsable(false)]
		[JsonIgnore]
		public byte IsSoftDeleted { get; set; } = 0;

		[DisplayName(Label.Version)]
		public byte[] Version { get; set; }
		public string VersionString
		{
			get
			{
				string versionStr = string.Empty;
				if (Version is object)
					versionStr = Convert.ToBase64String(Version);

				return versionStr;
			}

			set
			{
				Version ??= Convert.FromBase64String(value);
			}
		}

		public Guid? CreatedId { get; set; }
		[DisplayName(Label.CreatedBy)]
		public string CreatedName { get; set; }
		[DisplayName(Label.CreatedDateTime)]
		public DateTime? CreatedDateTime { get; set; }

		public Guid? UpdatedId { get; set; }
		[DisplayName(Label.UpdatedBy)]
		public string UpdatedName { get; set; }
		[DisplayName(Label.UpdatedDateTime)]
		public DateTime? UpdatedDateTime { get; set; }
	}
}
