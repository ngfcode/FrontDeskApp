using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrontDeskApp.Infrastructure.Persistence.Configurations;

[ExcludeFromCodeCoverage]
internal static class EntityBaseConfiguration
{
	public static void ConfigureBase<T>(
			this EntityTypeBuilder<T> builder)
			where T : BaseEntity
	{
		builder.Property(e => e.Id)
			.ValueGeneratedOnAdd();

		builder.Property(e => e.IsSoftDeleted)
			.IsRequired();

		builder.ConfigureAudit();
	}

	public static void ConfigureAudit<T>(
		this EntityTypeBuilder<T> builder)
		where T : AuditEntity
	{
	}
}
