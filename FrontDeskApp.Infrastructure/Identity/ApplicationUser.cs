using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using FrontDeskApp.Domain.Entities;
using FrontDeskApp.Shared.Constants;
using Microsoft.AspNetCore.Identity;

namespace FrontDeskApp.Infrastructure.Identity;

[ExcludeFromCodeCoverage]
public class ApplicationUser : IdentityUser<Guid>
{
	[MaxLength(DefaultValues.NameLength)]
	public string FirstName { get; set; }
	[MaxLength(DefaultValues.NameLength)]
	public string MiddleName { get; set; }
	[MaxLength(DefaultValues.NameLength)]
	public string LastName { get; set; }

	[IgnoreDataMember]
	public string FullName
	{
		get
		{
			return $"{FirstName} {LastName}";
		}
	}

	public string RefreshToken { get; set; }
	public DateTime? RefreshTokenExpiryDate { get; set; }

	public byte[] Photo { get; set; }
	public bool IsActivated { get; set; }

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
