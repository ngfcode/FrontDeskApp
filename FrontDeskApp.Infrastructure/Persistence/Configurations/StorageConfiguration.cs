using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrontDeskApp.Infrastructure.Persistence.Configurations;

[ExcludeFromCodeCoverage]
internal sealed class StorageConfiguration : IEntityTypeConfiguration<Storage>
{
	public void Configure(
		EntityTypeBuilder<Storage> builder)
	{
		builder.Property<Guid>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("uniqueidentifier");

		builder.Property<DateTime?>("CreatedDateTime")
			.HasColumnType("datetime");

		builder.Property<Guid?>("CreatedId")
			.HasColumnType("uniqueidentifier");

		builder.Property<string>("CreatedName")
			.HasMaxLength(50)
			.HasColumnType("nvarchar(50)");

		builder.Property<bool>("IsAvailable")
			.HasColumnType("bit");

		builder.Property<byte>("IsSoftDeleted")
			.HasColumnType("tinyint");

		builder.Property<string>("Location")
			.IsRequired()
			.HasMaxLength(50)
			.HasColumnType("nvarchar(50)");

		builder.Property<Guid>("StorageTypeId")
			.HasColumnType("uniqueidentifier");

		builder.Property<DateTime?>("UpdatedDateTime")
			.HasColumnType("datetime");

		builder.Property<Guid?>("UpdatedId")
			.HasColumnType("uniqueidentifier");

		builder.Property<string>("UpdatedName")
			.HasMaxLength(50)
			.HasColumnType("nvarchar(50)");

		builder.Property<byte[]>("Version")
			.IsConcurrencyToken()
			.ValueGeneratedOnAddOrUpdate()
			.HasMaxLength(8)
			.HasColumnType("timestamp");

		builder.HasKey("Id");

		builder.HasIndex("IsSoftDeleted");

		builder.HasIndex("StorageTypeId");

		builder.ToTable("Storage");
	}
}
