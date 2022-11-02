using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrontDeskApp.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsSoftDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Version = table.Column<byte[]>(type: "timestamp", maxLength: 8, rowVersion: true, nullable: true),
                    CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    IsSoftDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Version = table.Column<byte[]>(type: "timestamp", maxLength: 8, rowVersion: true, nullable: true),
                    CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsSoftDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Version = table.Column<byte[]>(type: "timestamp", maxLength: 8, rowVersion: true, nullable: true),
                    CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StorageType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SizeType = table.Column<int>(type: "int", nullable: false),
                    IsSoftDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Version = table.Column<byte[]>(type: "timestamp", maxLength: 8, rowVersion: true, nullable: true),
                    CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSoftDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Version = table.Column<byte[]>(type: "timestamp", maxLength: 8, rowVersion: true, nullable: true),
                    CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSoftDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Version = table.Column<byte[]>(type: "timestamp", maxLength: 8, rowVersion: true, nullable: true),
                    CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsSoftDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Version = table.Column<byte[]>(type: "timestamp", maxLength: 8, rowVersion: true, nullable: true),
                    CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsSoftDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Version = table.Column<byte[]>(type: "timestamp", maxLength: 8, rowVersion: true, nullable: true),
                    CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsSoftDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Version = table.Column<byte[]>(type: "timestamp", maxLength: 8, rowVersion: true, nullable: true),
                    CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StorageTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsSoftDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Version = table.Column<byte[]>(type: "timestamp", maxLength: 8, rowVersion: true, nullable: true),
                    CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storage_StorageType_StorageTypeId",
                        column: x => x.StorageTypeId,
                        principalTable: "StorageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StorageOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StorageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoxSize = table.Column<int>(type: "int", nullable: false),
                    RetrievedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSoftDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Version = table.Column<byte[]>(type: "timestamp", maxLength: 8, rowVersion: true, nullable: true),
                    CreatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageOrder_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorageOrder_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CreatedDateTime", "CreatedId", "CreatedName", "FirstName", "IsSoftDeleted", "LastName", "MiddleName", "PhoneNo", "UpdatedDateTime", "UpdatedId", "UpdatedName" },
                values: new object[,]
                {
                    { new Guid("0fae19d5-bfee-430a-a466-21dbb65d5d38"), null, null, null, "Noel", (byte)0, "Francisco", "Gonzales", "123456789", null, null, null },
                    { new Guid("416088b3-2b6d-4111-91cf-77862d010423"), null, null, null, "Tony", (byte)0, "Starks", null, "987654321", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "StorageType",
                columns: new[] { "Id", "Code", "CreatedDateTime", "CreatedId", "CreatedName", "Description", "IsSoftDeleted", "Name", "SizeType", "UpdatedDateTime", "UpdatedId", "UpdatedName" },
                values: new object[,]
                {
                    { new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), "LARGE-TYPE", null, null, null, null, (byte)0, "Large Type Storage", 3, null, null, null },
                    { new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), "SMALL-TYPE", null, null, null, null, (byte)0, "Small Type Storage", 1, null, null, null },
                    { new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), "MEDIUM-TYPE", null, null, null, null, (byte)0, "Medium Type Storage", 2, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Storage",
                columns: new[] { "Id", "CreatedDateTime", "CreatedId", "CreatedName", "IsAvailable", "IsSoftDeleted", "Location", "StorageTypeId", "UpdatedDateTime", "UpdatedId", "UpdatedName" },
                values: new object[,]
                {
                    { new Guid("002ee9ab-79d3-4b63-8c52-0962ee991116"), null, null, null, true, (byte)0, "LOC19", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("02121dae-1bbc-4da8-902a-f245dd72560e"), null, null, null, true, (byte)0, "LOC41", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("02c9c8bf-4519-4108-a2a3-2551daf712f5"), null, null, null, true, (byte)0, "LOC13", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("03632dbd-4986-4d97-8008-ceb73050dc82"), null, null, null, true, (byte)0, "LOC25", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("09099a2c-94e3-4eda-a70e-6980f6d5cd45"), null, null, null, true, (byte)0, "LOC11", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("0bb1ca8c-93d9-4f88-8a16-88a24021fef9"), null, null, null, true, (byte)0, "LOC12", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("0c993c3d-bde8-4481-aa8f-120d431818bd"), null, null, null, true, (byte)0, "LOC14", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("13e670de-c2b8-4a8e-8dee-0c9b316f5204"), null, null, null, true, (byte)0, "LOC03", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("18d80353-fc62-452c-b236-6b5a139cb24a"), null, null, null, true, (byte)0, "LOC34", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("1bea3fbd-23f4-4ec8-bf2e-79ae65ae6365"), null, null, null, true, (byte)0, "LOC50", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("20849c8f-eacd-4bcf-8715-ed284430a0e1"), null, null, null, true, (byte)0, "LOC02", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("218488c1-cfb6-42f6-8924-cc01fa73025c"), null, null, null, true, (byte)0, "LOC31", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("23a5d6c5-6433-4296-9049-bd308037d9c3"), null, null, null, true, (byte)0, "LOC14", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("244f76b0-86de-4eaf-a97a-24b93b7b4dcd"), null, null, null, true, (byte)0, "LOC25", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("2711c9d8-83c6-4b32-a987-113d52490826"), null, null, null, true, (byte)0, "LOC42", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("272f296c-ea67-48b3-8d97-23d44ee368c5"), null, null, null, true, (byte)0, "LOC26", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("275d39a2-da63-48f0-b82a-f90938b34985"), null, null, null, true, (byte)0, "LOC06", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("29044c4a-321a-48a4-a6dc-fa8bca81913d"), null, null, null, true, (byte)0, "LOC11", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("2e973419-139b-4b30-bdd1-a96d3fd15514"), null, null, null, true, (byte)0, "LOC28", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("2f97a483-6e80-46da-b121-79ab52ed4a94"), null, null, null, true, (byte)0, "LOC24", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("2fbd8d65-1c4f-4eec-8b5c-fb0a323800e5"), null, null, null, true, (byte)0, "LOC46", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("332af1b4-6184-4a45-8442-4078ae3bb8f1"), null, null, null, true, (byte)0, "LOC35", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("33e10fea-f227-412a-9e48-1e6d6f2bc1e0"), null, null, null, true, (byte)0, "LOC32", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("34149861-da71-4e52-82a0-db57bee8c16d"), null, null, null, true, (byte)0, "LOC23", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("3639228d-5a18-4e67-91b4-29600835e57a"), null, null, null, true, (byte)0, "LOC36", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("3c038f6d-f202-4390-9637-f9727e4dec98"), null, null, null, true, (byte)0, "LOC38", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("40b02e79-377f-4f03-8630-cda5b14b2cc0"), null, null, null, true, (byte)0, "LOC26", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("435aa786-a23a-4c03-8ddd-cee884875cfb"), null, null, null, true, (byte)0, "LOC42", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("43bb647f-07f2-4931-9c19-d146dbbc7767"), null, null, null, true, (byte)0, "LOC47", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("482a7c68-431e-481a-af13-363f8c29bf2d"), null, null, null, true, (byte)0, "LOC46", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("4a3bf646-4510-4b00-bede-fdec2e4dc029"), null, null, null, true, (byte)0, "LOC16", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("4d92af47-0006-4180-a961-732c6b3ecf49"), null, null, null, true, (byte)0, "LOC03", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("4f59b898-1c59-46b4-a769-30c6eda0fa6b"), null, null, null, true, (byte)0, "LOC05", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("513167c9-fa8e-480f-9fc9-2f4bd35c9355"), null, null, null, true, (byte)0, "LOC45", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("52582dfa-afb9-4065-ab65-70b24b523485"), null, null, null, true, (byte)0, "LOC15", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("54392e2f-5668-40a9-96f8-fadc4579a260"), null, null, null, true, (byte)0, "LOC13", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("572428a4-cbdf-4676-a88b-f693a362cfde"), null, null, null, true, (byte)0, "LOC12", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("583677f9-5513-4bd3-896c-d7b8701912d9"), null, null, null, true, (byte)0, "LOC30", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("58901708-8f90-41bc-8279-f5ce5120a011"), null, null, null, true, (byte)0, "LOC39", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("5a0a9f54-71db-44e1-8dd1-d3e186cd09bd"), null, null, null, true, (byte)0, "LOC50", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("5aac0765-1aa4-43c6-9c09-187454729286"), null, null, null, true, (byte)0, "LOC45", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("5bbb9059-8a1c-401c-8ca4-8b2f0222126f"), null, null, null, true, (byte)0, "LOC31", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Storage",
                columns: new[] { "Id", "CreatedDateTime", "CreatedId", "CreatedName", "IsAvailable", "IsSoftDeleted", "Location", "StorageTypeId", "UpdatedDateTime", "UpdatedId", "UpdatedName" },
                values: new object[,]
                {
                    { new Guid("5da8b8d8-d220-4859-bfcc-e474f5922097"), null, null, null, true, (byte)0, "LOC12", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("5f38e16a-ef97-4e29-9b19-a6cd10e52a88"), null, null, null, true, (byte)0, "LOC03", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("6284678b-8016-4313-aa13-98c14f55c3d7"), null, null, null, true, (byte)0, "LOC33", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("62dee335-f982-4094-bcff-efcc55a1deea"), null, null, null, true, (byte)0, "LOC18", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("637ebb14-8d6b-414b-8b8f-da959b790ca2"), null, null, null, true, (byte)0, "LOC46", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("671a72a7-1a0b-47a9-a052-4edd3a29e1f8"), null, null, null, true, (byte)0, "LOC07", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("6838d6e1-3706-4f2a-abbf-d033d12c6316"), null, null, null, true, (byte)0, "LOC01", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("696b1e43-1d33-4af5-827b-472b51e8f635"), null, null, null, true, (byte)0, "LOC47", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("69fe9808-ad67-4498-b778-380d0654042c"), null, null, null, true, (byte)0, "LOC21", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("6b579ef1-4fcd-4319-ae1b-e33652357192"), null, null, null, true, (byte)0, "LOC50", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("6bbf8d3e-7a94-4797-91e2-1a92193c1d3a"), null, null, null, true, (byte)0, "LOC22", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("6f2101c0-0336-40fa-a521-adaf9dc3ffe6"), null, null, null, true, (byte)0, "LOC29", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("70d6fc00-e58a-48a9-ad18-41dd15e3046e"), null, null, null, true, (byte)0, "LOC09", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("71b65761-88fd-4797-b039-0e80c6b43396"), null, null, null, true, (byte)0, "LOC30", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("71c6cecc-5964-45bf-9b1b-f1eaa31f8a91"), null, null, null, true, (byte)0, "LOC37", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("7333ff02-b2c6-4e79-8643-6fa568fb4815"), null, null, null, true, (byte)0, "LOC10", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("7381dfd1-91a7-47c8-b4af-a17b830c1440"), null, null, null, true, (byte)0, "LOC02", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("79c11d4e-32d0-4ae4-9759-b539c4c95027"), null, null, null, true, (byte)0, "LOC18", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("7a0b774a-0fc0-4699-b9e5-7e33a3a5068a"), null, null, null, true, (byte)0, "LOC43", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("7c2a0195-0878-423a-a783-b664f490e8c1"), null, null, null, true, (byte)0, "LOC36", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("7d27d71d-1a3f-40c0-b440-287b3befc267"), null, null, null, true, (byte)0, "LOC49", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("7e6b593e-e58a-4f9a-9b5f-e5a124e71da1"), null, null, null, true, (byte)0, "LOC08", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("7f256564-f00e-4c4f-ba32-1ca9839f5156"), null, null, null, true, (byte)0, "LOC41", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("80ae645a-d0ae-4fc9-b528-188f64f7cc4c"), null, null, null, true, (byte)0, "LOC24", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("80f507d9-7eca-48e6-ad15-448917b98671"), null, null, null, true, (byte)0, "LOC05", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("811c08e9-59de-4629-b4f2-f7b5525d7a51"), null, null, null, true, (byte)0, "LOC01", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("82953fd2-5024-4c3d-a82f-2726bff12283"), null, null, null, true, (byte)0, "LOC38", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("8314b7c0-a447-4cac-b934-e618978e06f2"), null, null, null, true, (byte)0, "LOC23", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("84ef84e2-b5db-41c1-949d-319cb7eeaacd"), null, null, null, true, (byte)0, "LOC39", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("8753c841-5a4e-4c08-8fe2-58a10f500d7c"), null, null, null, true, (byte)0, "LOC44", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("87c8cac0-e0e8-4b56-91f5-cb163406efeb"), null, null, null, true, (byte)0, "LOC29", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("8857874c-565f-48a8-96f6-a91405d70042"), null, null, null, true, (byte)0, "LOC15", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("8a8cc34a-c79b-4482-b671-6d8ca76018c1"), null, null, null, true, (byte)0, "LOC16", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("8a96c3f4-ecc6-4018-90b6-50683af10d7a"), null, null, null, true, (byte)0, "LOC01", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("8f25aa48-5717-4397-a892-306217ee6b29"), null, null, null, true, (byte)0, "LOC22", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("910d5c06-362a-4870-a7bb-f9f141ceaeb3"), null, null, null, true, (byte)0, "LOC40", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("975ef53b-65f8-48a7-a7f8-b748cba42887"), null, null, null, true, (byte)0, "LOC33", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("97a9469f-aa0c-4599-adde-3c65ed2f0f31"), null, null, null, true, (byte)0, "LOC27", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("97c39535-a456-4e48-b81b-d48744b65997"), null, null, null, true, (byte)0, "LOC22", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("97db7c43-469b-4147-8131-80ff67f33bf5"), null, null, null, true, (byte)0, "LOC39", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("9f279d8c-5494-4e24-b27c-ad3319b827cb"), null, null, null, true, (byte)0, "LOC28", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("9f294d1c-a7ff-4832-9fd5-b1ad89c55448"), null, null, null, true, (byte)0, "LOC48", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Storage",
                columns: new[] { "Id", "CreatedDateTime", "CreatedId", "CreatedName", "IsAvailable", "IsSoftDeleted", "Location", "StorageTypeId", "UpdatedDateTime", "UpdatedId", "UpdatedName" },
                values: new object[,]
                {
                    { new Guid("a299e84c-91c7-4541-8e50-4b6d27ca01a7"), null, null, null, true, (byte)0, "LOC20", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("a2d31147-244a-4018-b690-4308c0b71e69"), null, null, null, true, (byte)0, "LOC09", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("a42cfb2f-8b80-4b99-9f0c-935f457bc1d2"), null, null, null, true, (byte)0, "LOC17", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("a5eb40b9-424e-4f91-98dc-a3753c3bb988"), null, null, null, true, (byte)0, "LOC34", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("a835afdc-cb3c-4ac7-ac1f-f484dcef4f3f"), null, null, null, true, (byte)0, "LOC44", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("a97b08f9-b52f-4a77-aea1-14a6afab7d39"), null, null, null, true, (byte)0, "LOC20", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("a98b87f9-2287-4e21-a1a4-27eeaf128860"), null, null, null, true, (byte)0, "LOC19", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("a9b22ef1-1e64-411b-8568-0156fc5ba98b"), null, null, null, true, (byte)0, "LOC30", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("aa0c02cb-f158-4701-8418-5d1294fb2ddf"), null, null, null, true, (byte)0, "LOC04", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("ac43df80-cd60-4992-9884-1c3a914f999f"), null, null, null, true, (byte)0, "LOC21", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("adf3a43a-4d05-4f42-81cd-2892b1fc954c"), null, null, null, true, (byte)0, "LOC17", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("b0182323-6deb-4a32-9043-ab89a563479e"), null, null, null, true, (byte)0, "LOC43", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("b08b131e-da76-41fe-bd44-54b6dd6ff6a2"), null, null, null, true, (byte)0, "LOC11", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("b08da94e-00cf-4a34-86ef-d6d22de7a858"), null, null, null, true, (byte)0, "LOC27", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("b0d96e56-f756-441c-809a-40e812149d6e"), null, null, null, true, (byte)0, "LOC09", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("b2c55887-3915-4dac-a987-153216de9db2"), null, null, null, true, (byte)0, "LOC45", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("b4acace0-68f8-48ed-ad32-e373d3423edf"), null, null, null, true, (byte)0, "LOC35", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("b5663d62-6c0d-48f4-8d39-0adfe05ba876"), null, null, null, true, (byte)0, "LOC18", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("b6d6f11f-2060-40f6-9c2c-1908f00f424d"), null, null, null, true, (byte)0, "LOC34", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("b76621f8-b418-49ab-8bec-189ed480f10a"), null, null, null, true, (byte)0, "LOC49", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("b7ce5959-62c8-4cb9-9253-f25d6fbd4cbf"), null, null, null, true, (byte)0, "LOC21", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("b8df3d4c-2425-4b36-b282-c997ae0c3cf9"), null, null, null, true, (byte)0, "LOC29", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("b8f3f2b6-0c18-4478-86c9-d34ea14853f9"), null, null, null, true, (byte)0, "LOC07", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("ba0a0e59-33ef-4f09-9a50-cd44eec5f39e"), null, null, null, true, (byte)0, "LOC06", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("bb090fda-336c-41a5-86d2-a0dd09e2bcb0"), null, null, null, true, (byte)0, "LOC40", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("bb97929c-8bc6-4e83-9b3e-73afdd2c38c9"), null, null, null, true, (byte)0, "LOC35", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("c0b7bc81-f69a-4f93-b595-fef771c232a7"), null, null, null, true, (byte)0, "LOC40", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("c15edfa0-2721-4c61-ab8e-876f5ced711d"), null, null, null, true, (byte)0, "LOC31", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("c22b3a9f-726f-4498-81da-207ecffb20e0"), null, null, null, true, (byte)0, "LOC37", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("c3ccb866-d39d-42fb-9de2-5356cd0a2369"), null, null, null, true, (byte)0, "LOC32", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("c5f7698f-2beb-493b-89bb-29cf50820097"), null, null, null, true, (byte)0, "LOC08", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("c6cfffe2-240c-4118-9a59-af6f0b6c35bb"), null, null, null, true, (byte)0, "LOC13", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("c80d1bc5-4c55-4a0c-87e6-f7161551da92"), null, null, null, true, (byte)0, "LOC41", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("ca270cbb-6772-474a-9176-dda0479bffc8"), null, null, null, true, (byte)0, "LOC24", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("ca629c82-d1ab-4962-bee4-c1fb01367ddd"), null, null, null, true, (byte)0, "LOC32", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("d206eab6-32b0-4779-acc8-a23fa77e460e"), null, null, null, true, (byte)0, "LOC49", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("d33402f5-d206-43d6-84a1-7fef724effd3"), null, null, null, true, (byte)0, "LOC23", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("d5a83902-057d-45f4-a01e-55f504977dd0"), null, null, null, true, (byte)0, "LOC04", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("d666424f-8a60-4304-9d99-a4b634ea376a"), null, null, null, true, (byte)0, "LOC36", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("d9d59af5-6b23-433a-8864-eb54f625e1d8"), null, null, null, true, (byte)0, "LOC14", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("e15f0204-4e65-4877-bc73-4df104650bd9"), null, null, null, true, (byte)0, "LOC28", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("e1b77b91-c592-4fcf-b0de-f2973287f10f"), null, null, null, true, (byte)0, "LOC10", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Storage",
                columns: new[] { "Id", "CreatedDateTime", "CreatedId", "CreatedName", "IsAvailable", "IsSoftDeleted", "Location", "StorageTypeId", "UpdatedDateTime", "UpdatedId", "UpdatedName" },
                values: new object[,]
                {
                    { new Guid("e21cf2d5-ffe9-4c15-af1d-28ca2cf7beb6"), null, null, null, true, (byte)0, "LOC25", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("e27618da-60f3-4ddd-b76c-7a5e42f53142"), null, null, null, true, (byte)0, "LOC42", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("e3ece54d-e532-4c64-a410-d75f7469515e"), null, null, null, true, (byte)0, "LOC20", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("e422b5a2-d473-4433-8813-38df9786482c"), null, null, null, true, (byte)0, "LOC02", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("e45f0d5e-6ebb-4374-b68f-141ab451c077"), null, null, null, true, (byte)0, "LOC27", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("e6d7f69d-b604-49d8-94ab-1691f5e59eab"), null, null, null, true, (byte)0, "LOC38", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("e70b96f4-daa9-42c9-95ba-bd73e91b016e"), null, null, null, true, (byte)0, "LOC10", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("e7732afe-7ba9-4d23-8fc9-de08028d71d3"), null, null, null, true, (byte)0, "LOC08", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("e900a3e5-36d5-47b0-a480-18b4a592dac2"), null, null, null, true, (byte)0, "LOC48", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("e9ab15bc-658f-476f-a010-85cee06666ce"), null, null, null, true, (byte)0, "LOC16", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("ea51904f-aa14-4ae5-9764-fe88182ca46d"), null, null, null, true, (byte)0, "LOC15", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("ea7a28ed-7dfa-4142-acb5-6c062c97fc90"), null, null, null, true, (byte)0, "LOC07", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("ec41c0ea-3243-49d6-bb0a-ae7172d2e56e"), null, null, null, true, (byte)0, "LOC04", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("ed79de00-6aed-4265-91d2-f50cdaefee31"), null, null, null, true, (byte)0, "LOC26", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("ef5d761a-4b84-4ac8-bbc4-eb07e26b0e00"), null, null, null, true, (byte)0, "LOC19", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("efa66d70-e276-4b3e-a66d-4138527121a6"), null, null, null, true, (byte)0, "LOC48", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("f01a7f8a-be73-4445-af46-47ebaec67134"), null, null, null, true, (byte)0, "LOC33", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("f37b7291-6318-4a45-b254-48aa0d60ac1e"), null, null, null, true, (byte)0, "LOC44", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("f537bf60-7f72-4e79-a364-0520085a1dc0"), null, null, null, true, (byte)0, "LOC43", new Guid("a6d7bff0-2b8a-4956-99cc-46bbde703243"), null, null, null },
                    { new Guid("f63aae70-85aa-41e6-a3e0-820e36ccf8b3"), null, null, null, true, (byte)0, "LOC17", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null },
                    { new Guid("f846b4fc-a639-4d7c-9aac-98aa9231f121"), null, null, null, true, (byte)0, "LOC06", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("f9ba1c36-0352-4f2d-8ffe-a93af0091722"), null, null, null, true, (byte)0, "LOC37", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("fc148b10-eb58-4434-b225-901ba8adbec8"), null, null, null, true, (byte)0, "LOC47", new Guid("0ef3ac49-f99f-4501-8c38-2eca7b277f41"), null, null, null },
                    { new Guid("fe30740e-06dc-4801-9137-da97120eb757"), null, null, null, true, (byte)0, "LOC05", new Guid("c1a96f2e-1d92-4e94-b90b-df922e0b0dad"), null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IsSoftDeleted",
                table: "Customer",
                column: "IsSoftDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_IsSoftDeleted",
                table: "Storage",
                column: "IsSoftDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_StorageTypeId",
                table: "Storage",
                column: "StorageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageOrder_CustomerId",
                table: "StorageOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageOrder_IsSoftDeleted",
                table: "StorageOrder",
                column: "IsSoftDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StorageOrder_StorageId",
                table: "StorageOrder",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageType_IsSoftDeleted",
                table: "StorageType",
                column: "IsSoftDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "StorageOrder");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "StorageType");
        }
    }
}
