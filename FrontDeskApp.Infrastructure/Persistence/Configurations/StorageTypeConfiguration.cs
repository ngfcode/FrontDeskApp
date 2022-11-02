using System.Diagnostics.CodeAnalysis;
using FrontDeskApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrontDeskApp.Infrastructure.Persistence.Configurations;

[ExcludeFromCodeCoverage]
internal sealed class StorageTypeConfiguration : IEntityTypeConfiguration<StorageType>
{
	public void Configure(
		EntityTypeBuilder<StorageType> builder)
	{
		builder.Property<Guid>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("uniqueidentifier");

		builder.Property<string>("Code")
			.IsRequired()
			.HasMaxLength(20)
			.HasColumnType("nvarchar(20)");

		builder.Property<DateTime?>("CreatedDateTime")
			.HasColumnType("datetime");

		builder.Property<Guid?>("CreatedId")
			.HasColumnType("uniqueidentifier");

		builder.Property<string>("CreatedName")
			.HasMaxLength(50)
			.HasColumnType("nvarchar(50)");

		builder.Property<string>("Description")
			.HasMaxLength(200)
			.HasColumnType("nvarchar(200)");

		builder.Property<byte>("IsSoftDeleted")
			.HasColumnType("tinyint");

		builder.Property<string>("Name")
			.IsRequired()
			.HasMaxLength(50)
			.HasColumnType("nvarchar(50)");

		builder.Property<int>("SizeType")
			.HasColumnType("int");

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

		builder.ToTable("StorageType");
	}
}
