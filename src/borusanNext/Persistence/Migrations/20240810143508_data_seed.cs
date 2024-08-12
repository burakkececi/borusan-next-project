using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class data_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Banner = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BodyShellParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LeftFrontFender = table.Column<int>(type: "integer", nullable: false),
                    LeftFrontDoor = table.Column<int>(type: "integer", nullable: false),
                    LeftRearDoor = table.Column<int>(type: "integer", nullable: false),
                    LeftRearFender = table.Column<int>(type: "integer", nullable: false),
                    RightFrontFender = table.Column<int>(type: "integer", nullable: false),
                    RightFrontDoor = table.Column<int>(type: "integer", nullable: false),
                    RightRearDoor = table.Column<int>(type: "integer", nullable: false),
                    RightRearFender = table.Column<int>(type: "integer", nullable: false),
                    Frontbumper = table.Column<int>(type: "integer", nullable: false),
                    RearBumper = table.Column<int>(type: "integer", nullable: false),
                    Bonnet = table.Column<int>(type: "integer", nullable: false),
                    Ceiling = table.Column<int>(type: "integer", nullable: false),
                    Luggage = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyShellParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BodyTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BodyName = table.Column<string>(type: "text", nullable: false),
                    Door = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Logo = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Banner = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarColors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChassisParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsRightChassisChanged = table.Column<bool>(type: "boolean", nullable: false),
                    IsLeftChassisChanged = table.Column<bool>(type: "boolean", nullable: false),
                    IsFrontPanelChanged = table.Column<bool>(type: "boolean", nullable: false),
                    IsBackPanelChanged = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChassisParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Licences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LicenceNo = table.Column<int>(type: "integer", nullable: false),
                    ProvidedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Latitute = table.Column<string>(type: "text", nullable: false),
                    Longitute = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transmissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    AuthenticatorType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelName = table.Column<string>(type: "text", nullable: false),
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModels_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpertizeResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarDamageInformationRecord = table.Column<int>(type: "integer", nullable: false),
                    InquiryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ChassisPartId = table.Column<Guid>(type: "uuid", nullable: false),
                    BodyShellPartId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertizeResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpertizeResults_BodyShellParts_BodyShellPartId",
                        column: x => x.BodyShellPartId,
                        principalTable: "BodyShellParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertizeResults_ChassisParts_ChassisPartId",
                        column: x => x.ChassisPartId,
                        principalTable: "ChassisParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EngineNo = table.Column<string>(type: "text", nullable: false),
                    EngineCapacity = table.Column<int>(type: "integer", nullable: false),
                    MotorPower = table.Column<int>(type: "integer", nullable: false),
                    MaximumTorque = table.Column<int>(type: "integer", nullable: false),
                    Acceleration = table.Column<double>(type: "double precision", nullable: false),
                    MaximumSpeed = table.Column<int>(type: "integer", nullable: false),
                    FuelTankVolume = table.Column<int>(type: "integer", nullable: false),
                    OutOfTownConsumptionRate = table.Column<double>(type: "double precision", nullable: false),
                    UrbanConsumptionRate = table.Column<double>(type: "double precision", nullable: false),
                    AverageConsumptionRate = table.Column<double>(type: "double precision", nullable: false),
                    FuelTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Engines_FuelTypes_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenerationImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GenerationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenerationImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenerationImages_Generations_GenerationId",
                        column: x => x.GenerationId,
                        principalTable: "Generations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogItemTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TagId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlogId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogItemTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogItemTags_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogItemTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    CustomerType = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAuthenticators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActivationKey = table.Column<string>(type: "text", nullable: true),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAuthenticators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAuthenticators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtpAuthenticators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SecretKey = table.Column<byte[]>(type: "bytea", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpAuthenticators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtpAuthenticators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    ExpiresDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedByIp = table.Column<string>(type: "text", nullable: false),
                    RevokedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RevokedByIp = table.Column<string>(type: "text", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "text", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    LicenceId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sellers_Licences_LicenceId",
                        column: x => x.LicenceId,
                        principalTable: "Licences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sellers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sellers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    OperationClaimId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModalExtensions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Lenght = table.Column<double>(type: "double precision", nullable: false),
                    Width = table.Column<double>(type: "double precision", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    FuelTank = table.Column<double>(type: "double precision", nullable: false),
                    LuggageCapacity = table.Column<double>(type: "double precision", nullable: false),
                    EmptyWeight = table.Column<double>(type: "double precision", nullable: false),
                    ModelYear = table.Column<int>(type: "integer", nullable: false),
                    CarModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    GenerationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModalExtensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModalExtensions_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModalExtensions_Generations_GenerationId",
                        column: x => x.GenerationId,
                        principalTable: "Generations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChassisNumber = table.Column<string>(type: "text", nullable: false),
                    Plate = table.Column<string>(type: "text", nullable: false),
                    Kilometers = table.Column<int>(type: "integer", nullable: false),
                    SpareKey = table.Column<bool>(type: "boolean", nullable: false),
                    Inquiry = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WheelType = table.Column<string>(type: "text", nullable: false),
                    SpareWheel = table.Column<bool>(type: "boolean", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    ModalExtensionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ColorId = table.Column<Guid>(type: "uuid", nullable: false),
                    EngineId = table.Column<Guid>(type: "uuid", nullable: false),
                    BodyTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransmissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    TramerId = table.Column<Guid>(type: "uuid", nullable: false),
                    SellerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_BodyTypes_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalTable: "BodyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_CarColors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "CarColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_ExpertizeResults_TramerId",
                        column: x => x.TramerId,
                        principalTable: "ExpertizeResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_ModalExtensions_ModalExtensionId",
                        column: x => x.ModalExtensionId,
                        principalTable: "ModalExtensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Transmissions_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "Transmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdvertNo = table.Column<int>(type: "integer", nullable: false),
                    CarId = table.Column<Guid>(type: "uuid", nullable: false),
                    SellerId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adverts_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Adverts_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CarId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdvertImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdvertId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertImages_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAdvertLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdvertId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAdvertLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAdvertLogs_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAdvertLogs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFavorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdvertId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerFavorites_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerFavorites_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Banner", "CreatedDate", "DeletedDate", "Description", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1c1fac0a-4c1f-4ade-bded-a9b7a28df01b"), "https://res.cloudinary.com/dl0cotczj/image/upload/v1722923108/g09uyd5sinylzgo2xtjj.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Borusan Otomotiv Grubu'nun tek çatı altında çoklu marka ve çoklu kanal stratejisi vizyonu doğrultusunda oluşturulan ikinci el otomobil platformu Borusan Next, kendi lokasyonlarında, teknoloji, güven, hız ve premium müşteri deneyimi odaklı bir yaklaşım ile kullanılmış otomobil alım, satım, takas ve iş ortakları vasıtasıyla da finansman ve sigorta çözümleri sunuyor.", "İkinci El Arabanın Yeni Adresi Borusan Next!", null },
                    { new Guid("6321910f-01ee-47be-b65e-8868ffecb023"), "https://res.cloudinary.com/dl0cotczj/image/upload/v1722923108/roar5vpmq5y2btncajl2.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Borusan Otomotiv Grubu'nun tek çatı altında çoklu marka ve çoklu kanal stratejisi vizyonu doğrultusunda oluşturulan ikinci el otomobil platformu Borusan Next, kendi lokasyonlarında, teknoloji, güven, hız ve premium müşteri deneyimi odaklı bir yaklaşım ile kullanılmış otomobil alım, satım, takas ve iş ortakları vasıtasıyla da finansman ve sigorta çözümleri sunuyor.", "Hız Tutkunları Motoru Nextten...", null },
                    { new Guid("d323a479-a0f5-4347-a764-698be769fb57"), "https://res.cloudinary.com/dl0cotczj/image/upload/v1722923108/cnhqv7ttffz6297xulca.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Borusan Otomotiv Grubu'nun tek çatı altında çoklu marka ve çoklu kanal stratejisi vizyonu doğrultusunda oluşturulan ikinci el otomobil platformu Borusan Next, kendi lokasyonlarında, teknoloji, güven, hız ve premium müşteri deneyimi odaklı bir yaklaşım ile kullanılmış otomobil alım, satım, takas ve iş ortakları vasıtasıyla da finansman ve sigorta çözümleri sunuyor.", "Burası Harika Bir Title!", null }
                });

            migrationBuilder.InsertData(
                table: "BodyShellParts",
                columns: new[] { "Id", "Bonnet", "Ceiling", "CreatedDate", "DeletedDate", "Frontbumper", "LeftFrontDoor", "LeftFrontFender", "LeftRearDoor", "LeftRearFender", "Luggage", "RearBumper", "RightFrontDoor", "RightFrontFender", "RightRearDoor", "RightRearFender", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3eeff5e8-58ab-4f64-82a9-05d77b83b4ef"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 3, 3, 3, 3, 0, 2, 0, 0, 0, 0, null },
                    { new Guid("8c9d2d89-affb-4202-9953-ab86cf490ca0"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, null },
                    { new Guid("db7257a0-5a57-4960-8a34-7f4f798470a2"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2, null }
                });

            migrationBuilder.InsertData(
                table: "BodyTypes",
                columns: new[] { "Id", "BodyName", "CreatedDate", "DeletedDate", "Door", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1e6fa0ec-590b-4d7f-8036-63f823390031"), "Hatchback", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "4", null },
                    { new Guid("491df778-2c1a-4d5f-a0c9-d28b5ffcb747"), "SUV", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "4", null },
                    { new Guid("7204f988-a804-43d0-8f9c-4084c1c5dfc0"), "Sedan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "4", null }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Logo", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0f1e4581-6b0b-4b9f-a4ab-3b292c082456"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://res.cloudinary.com/dl0cotczj/image/upload/v1722869832/vqmnm1pnw8ny9rdyku28.svg", "Land Rover", null },
                    { new Guid("96ec5f7f-8b0f-41b9-9694-e9968fd49f7a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://res.cloudinary.com/dl0cotczj/image/upload/v1722106757/dalglsprdgaabq0m7jmg.png", "MINI", null },
                    { new Guid("c571076a-f830-4682-bfb3-5ca69537ee41"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://res.cloudinary.com/dl0cotczj/image/upload/v1722869825/cpoit6q62nuhyb9byxkn.png", "BMW", null }
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "Banner", "CreatedDate", "DeletedDate", "Description", "Title", "UpdatedDate" },
                values: new object[] { new Guid("4ddb2ea7-21a7-4d1d-9367-bdf25cc75ac8"), "https://res.cloudinary.com/dl0cotczj/image/upload/v1722923108/g09uyd5sinylzgo2xtjj.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bu Bir Kampanya Detayı", "Bu Bir Kampanya", null });

            migrationBuilder.InsertData(
                table: "CarColors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("22596234-0c65-4e4e-9db4-bbf0584af494"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blue", null },
                    { new Guid("22b793c7-8706-4850-aaa8-0f2fac8a2858"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Black", null },
                    { new Guid("38211267-9cce-4040-adae-0c64bc26dab8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Red", null }
                });

            migrationBuilder.InsertData(
                table: "ChassisParts",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsBackPanelChanged", "IsFrontPanelChanged", "IsLeftChassisChanged", "IsRightChassisChanged", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("352dd90f-0292-4613-b5d9-3540a723c6dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, false, false, null },
                    { new Guid("85262f34-ace7-4f68-8b20-8ed9a0fd77c6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, false, false, null },
                    { new Guid("e59f7e66-cc28-4270-84ed-aa6812f00935"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, false, false, null }
                });

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("55126902-8144-4e5a-9b4f-06cc32304d57"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Petrol", null },
                    { new Guid("5e44df51-9db5-46cc-b9ab-7c64a491e2fe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Diesel", null },
                    { new Guid("7c27ae08-d686-43b7-9fc2-5a9df75963de"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Electric", null }
                });

            migrationBuilder.InsertData(
                table: "Generations",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("353a7e00-a2ba-4111-af4a-21302b0d8f50"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "2.Nesil", null },
                    { new Guid("ccb47a46-d3ee-421f-b731-8810a62a0628"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "4.Nesil Makyaj", null },
                    { new Guid("d94a19fa-9478-4514-8238-e08eb534a209"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "7.Nesil Makyaj", null }
                });

            migrationBuilder.InsertData(
                table: "Licences",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "LicenceNo", "ProvidedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("7f30d80f-3a7b-429c-81a5-0c9507839691"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3401870, "Borusan Otomotiv", null },
                    { new Guid("d1993933-0185-4333-888c-36f226993e1c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3501870, "Borusan Otomotiv", null },
                    { new Guid("e99ccd48-51a3-46c0-b539-a28cec7d214c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6401872, "Borusan Otomotiv", null }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "City", "CreatedDate", "DeletedDate", "Latitute", "Longitute", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2f565ad5-7ae1-42ad-82f2-96944052aa27"), "Akpınar, Bilim Cd. No:2, 34485 Sancaktepe", "Istanbul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "40.9753623", "29.2244372", null },
                    { new Guid("4744af1a-89ba-4d1b-890c-9d3e3c755cda"), "Firüzköy Yolu No: 21 Avcılar", "Istanbul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "40.992769", "28.716821", null },
                    { new Guid("59a7ddc2-3920-4652-9543-797fbd1d3d38"), "Firüzköy Yolu No: 21 Avcılar", "Istanbul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "40.992769", "28.716821", null }
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Admin", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Read", null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.Write", null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Auth.RevokeToken", null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Admin", null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Read", null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Write", null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Create", null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Update", null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "OperationClaims.Delete", null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Admin", null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Read", null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Write", null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Create", null },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Update", null },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UserOperationClaims.Delete", null },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Admin", null },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Read", null },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Write", null },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Create", null },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Update", null },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Users.Delete", null },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Brands.Admin", null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Brands.Read", null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Brands.Write", null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Brands.Create", null },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Brands.Update", null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Brands.Delete", null },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Appointments.Admin", null },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Appointments.Read", null },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Appointments.Write", null },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Appointments.Create", null },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Appointments.Update", null },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Appointments.Delete", null },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blogs.Admin", null },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blogs.Read", null },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blogs.Write", null },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blogs.Create", null },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blogs.Update", null },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blogs.Delete", null },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BlogItemTags.Admin", null },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BlogItemTags.Read", null },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BlogItemTags.Write", null },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BlogItemTags.Create", null },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BlogItemTags.Update", null },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BlogItemTags.Delete", null },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BodyShellParts.Admin", null },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BodyShellParts.Read", null },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BodyShellParts.Write", null },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BodyShellParts.Create", null },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BodyShellParts.Update", null },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BodyShellParts.Delete", null },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BodyTypes.Admin", null },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BodyTypes.Read", null },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BodyTypes.Write", null },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BodyTypes.Create", null },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BodyTypes.Update", null },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BodyTypes.Delete", null },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Campaigns.Admin", null },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Campaigns.Read", null },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Campaigns.Write", null },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Campaigns.Create", null },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Campaigns.Update", null },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Campaigns.Delete", null },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarColors.Admin", null },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarColors.Read", null },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarColors.Write", null },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarColors.Create", null },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarColors.Update", null },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarColors.Delete", null },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarModels.Admin", null },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarModels.Read", null },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarModels.Write", null },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarModels.Create", null },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarModels.Update", null },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarModels.Delete", null },
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ChassisParts.Admin", null },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ChassisParts.Read", null },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ChassisParts.Write", null },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ChassisParts.Create", null },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ChassisParts.Update", null },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ChassisParts.Delete", null },
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerAdvertLogs.Admin", null },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerAdvertLogs.Read", null },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerAdvertLogs.Write", null },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerAdvertLogs.Create", null },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerAdvertLogs.Update", null },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerAdvertLogs.Delete", null },
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Engines.Admin", null },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Engines.Read", null },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Engines.Write", null },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Engines.Create", null },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Engines.Update", null },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Engines.Delete", null },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ExpertizeResults.Admin", null },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ExpertizeResults.Read", null },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ExpertizeResults.Write", null },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ExpertizeResults.Create", null },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ExpertizeResults.Update", null },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ExpertizeResults.Delete", null },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FuelTypes.Admin", null },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FuelTypes.Read", null },
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FuelTypes.Write", null },
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FuelTypes.Create", null },
                    { 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FuelTypes.Update", null },
                    { 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "FuelTypes.Delete", null },
                    { 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Generations.Admin", null },
                    { 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Generations.Read", null },
                    { 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Generations.Write", null },
                    { 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Generations.Create", null },
                    { 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Generations.Update", null },
                    { 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Generations.Delete", null },
                    { 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Licences.Admin", null },
                    { 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Licences.Read", null },
                    { 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Licences.Write", null },
                    { 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Licences.Create", null },
                    { 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Licences.Update", null },
                    { 119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Licences.Delete", null },
                    { 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Admin", null },
                    { 121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Read", null },
                    { 122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Write", null },
                    { 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Create", null },
                    { 124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Update", null },
                    { 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Delete", null },
                    { 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tags.Admin", null },
                    { 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tags.Read", null },
                    { 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tags.Write", null },
                    { 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tags.Create", null },
                    { 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tags.Update", null },
                    { 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tags.Delete", null },
                    { 132, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Transmissions.Admin", null },
                    { 133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Transmissions.Read", null },
                    { 134, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Transmissions.Write", null },
                    { 135, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Transmissions.Create", null },
                    { 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Transmissions.Update", null },
                    { 137, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Transmissions.Delete", null },
                    { 138, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customers.Admin", null },
                    { 139, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customers.Read", null },
                    { 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customers.Write", null },
                    { 141, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customers.Create", null },
                    { 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customers.Update", null },
                    { 143, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customers.Delete", null },
                    { 144, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sellers.Admin", null },
                    { 145, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sellers.Read", null },
                    { 146, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sellers.Write", null },
                    { 147, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sellers.Create", null },
                    { 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sellers.Update", null },
                    { 149, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sellers.Delete", null },
                    { 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Admin", null },
                    { 151, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Read", null },
                    { 152, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Write", null },
                    { 153, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Create", null },
                    { 154, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Update", null },
                    { 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Locations.Delete", null },
                    { 156, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ExpertizeResults.Admin", null },
                    { 157, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ExpertizeResults.Read", null },
                    { 158, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ExpertizeResults.Write", null },
                    { 159, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ExpertizeResults.Create", null },
                    { 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ExpertizeResults.Update", null },
                    { 161, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ExpertizeResults.Delete", null },
                    { 162, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adverts.Admin", null },
                    { 163, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adverts.Read", null },
                    { 164, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adverts.Write", null },
                    { 165, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adverts.Create", null },
                    { 166, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adverts.Update", null },
                    { 167, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adverts.Delete", null },
                    { 168, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarModels.Admin", null },
                    { 169, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarModels.Read", null },
                    { 170, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarModels.Write", null },
                    { 171, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarModels.Create", null },
                    { 172, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarModels.Update", null },
                    { 173, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarModels.Delete", null },
                    { 174, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AdvertImages.Admin", null },
                    { 175, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AdvertImages.Read", null },
                    { 176, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AdvertImages.Write", null },
                    { 177, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AdvertImages.Create", null },
                    { 178, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AdvertImages.Update", null },
                    { 179, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AdvertImages.Delete", null },
                    { 180, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ModalExtensions.Admin", null },
                    { 181, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ModalExtensions.Read", null },
                    { 182, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ModalExtensions.Write", null },
                    { 183, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ModalExtensions.Create", null },
                    { 184, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ModalExtensions.Update", null },
                    { 185, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ModalExtensions.Delete", null },
                    { 186, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GenerationImages.Admin", null },
                    { 187, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GenerationImages.Read", null },
                    { 188, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GenerationImages.Write", null },
                    { 189, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GenerationImages.Create", null },
                    { 190, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GenerationImages.Update", null },
                    { 191, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GenerationImages.Delete", null },
                    { 192, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cars.Admin", null },
                    { 193, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cars.Read", null },
                    { 194, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cars.Write", null },
                    { 195, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cars.Create", null },
                    { 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cars.Update", null },
                    { 197, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cars.Delete", null },
                    { 198, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Admin", null },
                    { 199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Read", null },
                    { 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Write", null },
                    { 201, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Create", null },
                    { 202, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Update", null },
                    { 203, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[] { new Guid("873dbb53-f3ca-4bda-a0d7-18ae10ca9f3e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "İkinci El", null });

            migrationBuilder.InsertData(
                table: "Transmissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2c450873-2f0b-4da2-a7ff-245ca5c73e19"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Manuel", null },
                    { new Guid("b830d944-aa1b-4074-9a24-1ff60f1cd38d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Automatic", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("36160d4c-8a2a-4959-9769-ebf2bd812237"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "sefa@borusan.com", new byte[] { 121, 11, 38, 238, 177, 129, 113, 132, 120, 242, 149, 237, 244, 128, 33, 234, 208, 128, 55, 75, 158, 137, 146, 179, 36, 39, 129, 37, 240, 44, 157, 44, 87, 20, 119, 210, 165, 166, 119, 198, 243, 81, 98, 219, 147, 128, 59, 119, 199, 141, 95, 150, 151, 35, 237, 69, 217, 37, 90, 246, 13, 16, 0, 236 }, new byte[] { 129, 213, 139, 19, 223, 148, 207, 23, 29, 119, 174, 93, 88, 180, 169, 136, 24, 77, 27, 2, 97, 230, 47, 250, 175, 133, 253, 77, 71, 131, 181, 247, 11, 132, 56, 108, 150, 42, 70, 95, 232, 28, 83, 109, 125, 184, 134, 72, 136, 114, 69, 189, 10, 157, 81, 24, 249, 248, 110, 127, 138, 205, 236, 17, 113, 171, 10, 87, 155, 145, 176, 213, 162, 236, 72, 194, 217, 174, 114, 181, 227, 79, 237, 200, 27, 21, 198, 248, 179, 207, 100, 227, 181, 185, 87, 179, 38, 41, 151, 243, 182, 232, 181, 129, 215, 126, 218, 147, 113, 71, 86, 239, 99, 24, 43, 31, 16, 120, 197, 133, 146, 193, 22, 213, 49, 170, 228, 159 }, null },
                    { new Guid("398b5d31-f2e2-473f-8f40-78f7e79af217"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "kececi@borusan.com", new byte[] { 121, 11, 38, 238, 177, 129, 113, 132, 120, 242, 149, 237, 244, 128, 33, 234, 208, 128, 55, 75, 158, 137, 146, 179, 36, 39, 129, 37, 240, 44, 157, 44, 87, 20, 119, 210, 165, 166, 119, 198, 243, 81, 98, 219, 147, 128, 59, 119, 199, 141, 95, 150, 151, 35, 237, 69, 217, 37, 90, 246, 13, 16, 0, 236 }, new byte[] { 129, 213, 139, 19, 223, 148, 207, 23, 29, 119, 174, 93, 88, 180, 169, 136, 24, 77, 27, 2, 97, 230, 47, 250, 175, 133, 253, 77, 71, 131, 181, 247, 11, 132, 56, 108, 150, 42, 70, 95, 232, 28, 83, 109, 125, 184, 134, 72, 136, 114, 69, 189, 10, 157, 81, 24, 249, 248, 110, 127, 138, 205, 236, 17, 113, 171, 10, 87, 155, 145, 176, 213, 162, 236, 72, 194, 217, 174, 114, 181, 227, 79, 237, 200, 27, 21, 198, 248, 179, 207, 100, 227, 181, 185, 87, 179, 38, 41, 151, 243, 182, 232, 181, 129, 215, 126, 218, 147, 113, 71, 86, 239, 99, 24, 43, 31, 16, 120, 197, 133, 146, 193, 22, 213, 49, 170, 228, 159 }, null },
                    { new Guid("6444d306-ab8e-4e84-a6ff-77037d68fd2e"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "burak@borusan.com", new byte[] { 121, 11, 38, 238, 177, 129, 113, 132, 120, 242, 149, 237, 244, 128, 33, 234, 208, 128, 55, 75, 158, 137, 146, 179, 36, 39, 129, 37, 240, 44, 157, 44, 87, 20, 119, 210, 165, 166, 119, 198, 243, 81, 98, 219, 147, 128, 59, 119, 199, 141, 95, 150, 151, 35, 237, 69, 217, 37, 90, 246, 13, 16, 0, 236 }, new byte[] { 129, 213, 139, 19, 223, 148, 207, 23, 29, 119, 174, 93, 88, 180, 169, 136, 24, 77, 27, 2, 97, 230, 47, 250, 175, 133, 253, 77, 71, 131, 181, 247, 11, 132, 56, 108, 150, 42, 70, 95, 232, 28, 83, 109, 125, 184, 134, 72, 136, 114, 69, 189, 10, 157, 81, 24, 249, 248, 110, 127, 138, 205, 236, 17, 113, 171, 10, 87, 155, 145, 176, 213, 162, 236, 72, 194, 217, 174, 114, 181, 227, 79, 237, 200, 27, 21, 198, 248, 179, 207, 100, 227, 181, 185, 87, 179, 38, 41, 151, 243, 182, 232, 181, 129, 215, 126, 218, 147, 113, 71, 86, 239, 99, 24, 43, 31, 16, 120, 197, 133, 146, 193, 22, 213, 49, 170, 228, 159 }, null },
                    { new Guid("69bd8e0f-59d4-4532-ae32-03cec3e39158"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "samandira@borusan.com", new byte[] { 121, 11, 38, 238, 177, 129, 113, 132, 120, 242, 149, 237, 244, 128, 33, 234, 208, 128, 55, 75, 158, 137, 146, 179, 36, 39, 129, 37, 240, 44, 157, 44, 87, 20, 119, 210, 165, 166, 119, 198, 243, 81, 98, 219, 147, 128, 59, 119, 199, 141, 95, 150, 151, 35, 237, 69, 217, 37, 90, 246, 13, 16, 0, 236 }, new byte[] { 129, 213, 139, 19, 223, 148, 207, 23, 29, 119, 174, 93, 88, 180, 169, 136, 24, 77, 27, 2, 97, 230, 47, 250, 175, 133, 253, 77, 71, 131, 181, 247, 11, 132, 56, 108, 150, 42, 70, 95, 232, 28, 83, 109, 125, 184, 134, 72, 136, 114, 69, 189, 10, 157, 81, 24, 249, 248, 110, 127, 138, 205, 236, 17, 113, 171, 10, 87, 155, 145, 176, 213, 162, 236, 72, 194, 217, 174, 114, 181, 227, 79, 237, 200, 27, 21, 198, 248, 179, 207, 100, 227, 181, 185, 87, 179, 38, 41, 151, 243, 182, 232, 181, 129, 215, 126, 218, 147, 113, 71, 86, 239, 99, 24, 43, 31, 16, 120, 197, 133, 146, 193, 22, 213, 49, 170, 228, 159 }, null },
                    { new Guid("ada31c5d-6014-46d2-a1c3-ed8007e898cf"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ali@borusan.com", new byte[] { 121, 11, 38, 238, 177, 129, 113, 132, 120, 242, 149, 237, 244, 128, 33, 234, 208, 128, 55, 75, 158, 137, 146, 179, 36, 39, 129, 37, 240, 44, 157, 44, 87, 20, 119, 210, 165, 166, 119, 198, 243, 81, 98, 219, 147, 128, 59, 119, 199, 141, 95, 150, 151, 35, 237, 69, 217, 37, 90, 246, 13, 16, 0, 236 }, new byte[] { 129, 213, 139, 19, 223, 148, 207, 23, 29, 119, 174, 93, 88, 180, 169, 136, 24, 77, 27, 2, 97, 230, 47, 250, 175, 133, 253, 77, 71, 131, 181, 247, 11, 132, 56, 108, 150, 42, 70, 95, 232, 28, 83, 109, 125, 184, 134, 72, 136, 114, 69, 189, 10, 157, 81, 24, 249, 248, 110, 127, 138, 205, 236, 17, 113, 171, 10, 87, 155, 145, 176, 213, 162, 236, 72, 194, 217, 174, 114, 181, 227, 79, 237, 200, 27, 21, 198, 248, 179, 207, 100, 227, 181, 185, 87, 179, 38, 41, 151, 243, 182, 232, 181, 129, 215, 126, 218, 147, 113, 71, 86, 239, 99, 24, 43, 31, 16, 120, 197, 133, 146, 193, 22, 213, 49, 170, 228, 159 }, null },
                    { new Guid("b73f6541-460e-4d9d-97eb-1402f63df038"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "avcilar@borusan.com", new byte[] { 121, 11, 38, 238, 177, 129, 113, 132, 120, 242, 149, 237, 244, 128, 33, 234, 208, 128, 55, 75, 158, 137, 146, 179, 36, 39, 129, 37, 240, 44, 157, 44, 87, 20, 119, 210, 165, 166, 119, 198, 243, 81, 98, 219, 147, 128, 59, 119, 199, 141, 95, 150, 151, 35, 237, 69, 217, 37, 90, 246, 13, 16, 0, 236 }, new byte[] { 129, 213, 139, 19, 223, 148, 207, 23, 29, 119, 174, 93, 88, 180, 169, 136, 24, 77, 27, 2, 97, 230, 47, 250, 175, 133, 253, 77, 71, 131, 181, 247, 11, 132, 56, 108, 150, 42, 70, 95, 232, 28, 83, 109, 125, 184, 134, 72, 136, 114, 69, 189, 10, 157, 81, 24, 249, 248, 110, 127, 138, 205, 236, 17, 113, 171, 10, 87, 155, 145, 176, 213, 162, 236, 72, 194, 217, 174, 114, 181, 227, 79, 237, 200, 27, 21, 198, 248, 179, 207, 100, 227, 181, 185, 87, 179, 38, 41, 151, 243, 182, 232, 181, 129, 215, 126, 218, 147, 113, 71, 86, 239, 99, 24, 43, 31, 16, 120, 197, 133, 146, 193, 22, 213, 49, 170, 228, 159 }, null },
                    { new Guid("bd4dd3dc-72e4-42cb-bde3-0fcb1867b10d"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "meryem@borusan.com", new byte[] { 121, 11, 38, 238, 177, 129, 113, 132, 120, 242, 149, 237, 244, 128, 33, 234, 208, 128, 55, 75, 158, 137, 146, 179, 36, 39, 129, 37, 240, 44, 157, 44, 87, 20, 119, 210, 165, 166, 119, 198, 243, 81, 98, 219, 147, 128, 59, 119, 199, 141, 95, 150, 151, 35, 237, 69, 217, 37, 90, 246, 13, 16, 0, 236 }, new byte[] { 129, 213, 139, 19, 223, 148, 207, 23, 29, 119, 174, 93, 88, 180, 169, 136, 24, 77, 27, 2, 97, 230, 47, 250, 175, 133, 253, 77, 71, 131, 181, 247, 11, 132, 56, 108, 150, 42, 70, 95, 232, 28, 83, 109, 125, 184, 134, 72, 136, 114, 69, 189, 10, 157, 81, 24, 249, 248, 110, 127, 138, 205, 236, 17, 113, 171, 10, 87, 155, 145, 176, 213, 162, 236, 72, 194, 217, 174, 114, 181, 227, 79, 237, 200, 27, 21, 198, 248, 179, 207, 100, 227, 181, 185, 87, 179, 38, 41, 151, 243, 182, 232, 181, 129, 215, 126, 218, 147, 113, 71, 86, 239, 99, 24, 43, 31, 16, 120, 197, 133, 146, 193, 22, 213, 49, 170, 228, 159 }, null },
                    { new Guid("e4cd1e5f-37b6-474d-88ba-cf6dfdca9207"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@borusan.com", new byte[] { 121, 11, 38, 238, 177, 129, 113, 132, 120, 242, 149, 237, 244, 128, 33, 234, 208, 128, 55, 75, 158, 137, 146, 179, 36, 39, 129, 37, 240, 44, 157, 44, 87, 20, 119, 210, 165, 166, 119, 198, 243, 81, 98, 219, 147, 128, 59, 119, 199, 141, 95, 150, 151, 35, 237, 69, 217, 37, 90, 246, 13, 16, 0, 236 }, new byte[] { 129, 213, 139, 19, 223, 148, 207, 23, 29, 119, 174, 93, 88, 180, 169, 136, 24, 77, 27, 2, 97, 230, 47, 250, 175, 133, 253, 77, 71, 131, 181, 247, 11, 132, 56, 108, 150, 42, 70, 95, 232, 28, 83, 109, 125, 184, 134, 72, 136, 114, 69, 189, 10, 157, 81, 24, 249, 248, 110, 127, 138, 205, 236, 17, 113, 171, 10, 87, 155, 145, 176, 213, 162, 236, 72, 194, 217, 174, 114, 181, 227, 79, 237, 200, 27, 21, 198, 248, 179, 207, 100, 227, 181, 185, 87, 179, 38, 41, 151, 243, 182, 232, 181, 129, 215, 126, 218, 147, 113, 71, 86, 239, 99, 24, 43, 31, 16, 120, 197, 133, 146, 193, 22, 213, 49, 170, 228, 159 }, null }
                });

            migrationBuilder.InsertData(
                table: "BlogItemTags",
                columns: new[] { "Id", "BlogId", "CreatedDate", "DeletedDate", "TagId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("24786008-f2f5-456a-b3b2-9be51d2584af"), new Guid("1c1fac0a-4c1f-4ade-bded-a9b7a28df01b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("873dbb53-f3ca-4bda-a0d7-18ae10ca9f3e"), null },
                    { new Guid("e3415515-de98-4ba4-ab4d-9527e6b9dbd4"), new Guid("6321910f-01ee-47be-b65e-8868ffecb023"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("873dbb53-f3ca-4bda-a0d7-18ae10ca9f3e"), null },
                    { new Guid("f433e050-e90c-4551-b65d-edb409244e3c"), new Guid("d323a479-a0f5-4347-a764-698be769fb57"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("873dbb53-f3ca-4bda-a0d7-18ae10ca9f3e"), null }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "BrandId", "CreatedDate", "DeletedDate", "ModelName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1c852177-9ca6-4ff6-af49-eb88c0f72cff"), new Guid("96ec5f7f-8b0f-41b9-9694-e9968fd49f7a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cooper Countryman", null },
                    { new Guid("534e852f-1bcf-4ae3-9ae4-4b5976bdfd87"), new Guid("0f1e4581-6b0b-4b9f-a4ab-3b292c082456"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Range Rover", null },
                    { new Guid("86a6edf9-745f-4a0f-9413-110b4cd6bfb6"), new Guid("c571076a-f830-4682-bfb3-5ca69537ee41"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "520i", null }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDate", "CustomerType", "DeletedDate", "FirstName", "LastName", "Phone", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("27ca8f20-333f-4fc2-a535-c156a2aec150"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Burak", "Keçeci", "5555555555", null, new Guid("6444d306-ab8e-4e84-a6ff-77037d68fd2e") },
                    { new Guid("ab623e31-88ab-48cb-8942-2c541343d651"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "Meryem", "Talay", "5555555555", null, new Guid("bd4dd3dc-72e4-42cb-bde3-0fcb1867b10d") },
                    { new Guid("b1e3b9cd-1c82-4f68-a70e-8349c28af525"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Sefa", "Pehlivan", "5555555555", null, new Guid("36160d4c-8a2a-4959-9769-ebf2bd812237") },
                    { new Guid("d2f17680-26d1-4ac3-90c6-4ffec9e5c0ad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, "Ali", "Laçin", "5555555555", null, new Guid("ada31c5d-6014-46d2-a1c3-ed8007e898cf") }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "Acceleration", "AverageConsumptionRate", "CreatedDate", "DeletedDate", "EngineCapacity", "EngineNo", "FuelTankVolume", "FuelTypeId", "MaximumSpeed", "MaximumTorque", "MotorPower", "OutOfTownConsumptionRate", "UpdatedDate", "UrbanConsumptionRate" },
                values: new object[,]
                {
                    { new Guid("0106e5db-0b88-4231-9cc0-263868fb5c01"), 6.0, 3.1000000000000001, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1800, "ENG456789123", 55, new Guid("7c27ae08-d686-43b7-9fc2-5a9df75963de"), 230, 300, 200, 3.5, null, 2.8999999999999999 },
                    { new Guid("12f9441e-92f2-4333-9e55-b1131c1bfde3"), 5.5, 3.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2000, "ENG123456789", 60, new Guid("55126902-8144-4e5a-9b4f-06cc32304d57"), 240, 350, 250, 3.3999999999999999, null, 2.7999999999999998 },
                    { new Guid("f235cb8f-559a-4659-8bba-8fba8b0737d6"), 7.0, 3.2000000000000002, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1500, "ENG987654321", 50, new Guid("5e44df51-9db5-46cc-b9ab-7c64a491e2fe"), 220, 250, 180, 3.3999999999999999, null, 3.0 }
                });

            migrationBuilder.InsertData(
                table: "ExpertizeResults",
                columns: new[] { "Id", "BodyShellPartId", "CarDamageInformationRecord", "ChassisPartId", "CreatedDate", "DeletedDate", "InquiryDate", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0ce199f9-3627-44bb-b3c2-fbd72c6799c2"), new Guid("8c9d2d89-affb-4202-9953-ab86cf490ca0"), 0, new Guid("352dd90f-0292-4613-b5d9-3540a723c6dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("47e992e3-6561-49ff-a827-0e19aaf10345"), new Guid("3eeff5e8-58ab-4f64-82a9-05d77b83b4ef"), 30000, new Guid("e59f7e66-cc28-4270-84ed-aa6812f00935"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("b8cb292b-c61b-4c73-9f20-f8fe2b746b5a"), new Guid("db7257a0-5a57-4960-8a34-7f4f798470a2"), 4000, new Guid("85262f34-ace7-4f68-8b20-8ed9a0fd77c6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "LicenceId", "LocationId", "Name", "PhoneNumber", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("056dd418-5114-4ea1-baf3-07d4b8fc26f6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("7f30d80f-3a7b-429c-81a5-0c9507839691"), new Guid("59a7ddc2-3920-4652-9543-797fbd1d3d38"), "Borusan Avcılar", "5354567890", null, new Guid("b73f6541-460e-4d9d-97eb-1402f63df038") },
                    { new Guid("667742ae-ae24-4d8c-9029-57ab5ba305ba"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("d1993933-0185-4333-888c-36f226993e1c"), new Guid("4744af1a-89ba-4d1b-890c-9d3e3c755cda"), "Kececi Oto", "5556667777", null, new Guid("398b5d31-f2e2-473f-8f40-78f7e79af217") },
                    { new Guid("785d6af9-4404-4d7a-ad3e-82319812b037"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e99ccd48-51a3-46c0-b539-a28cec7d214c"), new Guid("2f565ad5-7ae1-42ad-82f2-96944052aa27"), "Borusan Samandıra", "5426543210", null, new Guid("69bd8e0f-59d4-4532-ae32-03cec3e39158") }
                });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d4611002-39eb-4493-9483-5555f84f711e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("e4cd1e5f-37b6-474d-88ba-cf6dfdca9207") });

            migrationBuilder.InsertData(
                table: "ModalExtensions",
                columns: new[] { "Id", "CarModelId", "CreatedDate", "DeletedDate", "EmptyWeight", "FuelTank", "GenerationId", "Height", "Lenght", "LuggageCapacity", "ModelYear", "Name", "UpdatedDate", "Width" },
                values: new object[,]
                {
                    { new Guid("0333574e-400f-4ae4-80f2-0ac061efd7c8"), new Guid("534e852f-1bcf-4ae3-9ae4-4b5976bdfd87"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.0, 0.0, new Guid("ccb47a46-d3ee-421f-b731-8810a62a0628"), 1557.0, 4299.0, 0.0, 2021, "2.0 PHEV Vogue", null, 1822.0 },
                    { new Guid("40b9b81b-ccb9-4906-ad6d-7f0c2a9c728d"), new Guid("1c852177-9ca6-4ff6-af49-eb88c0f72cff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.0, 0.0, new Guid("353a7e00-a2ba-4111-af4a-21302b0d8f50"), 1557.0, 4299.0, 0.0, 2021, "1.5 Pepper", null, 1822.0 },
                    { new Guid("e1721aa6-b49b-4290-8f71-ae5d17267d5a"), new Guid("86a6edf9-745f-4a0f-9413-110b4cd6bfb6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.0, 0.0, new Guid("d94a19fa-9478-4514-8238-e08eb534a209"), 1557.0, 4299.0, 0.0, 2021, "520i Luxury Line", null, 1822.0 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BodyTypeId", "ChassisNumber", "ColorId", "CreatedDate", "DeletedDate", "EngineId", "Inquiry", "Kilometers", "ModalExtensionId", "Plate", "Price", "SellerId", "SpareKey", "SpareWheel", "TramerId", "TransmissionId", "UpdatedDate", "WheelType" },
                values: new object[,]
                {
                    { new Guid("12f8c123-4b6d-4a1e-928b-c1e6beb2e6f1"), new Guid("7204f988-a804-43d0-8f9c-4084c1c5dfc0"), "2HGCM82644A654321", new Guid("22596234-0c65-4e4e-9db4-bbf0584af494"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f235cb8f-559a-4659-8bba-8fba8b0737d6"), new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 45000, new Guid("0333574e-400f-4ae4-80f2-0ac061efd7c8"), "22AB123", 20000.00m, new Guid("785d6af9-4404-4d7a-ad3e-82319812b037"), true, false, new Guid("0ce199f9-3627-44bb-b3c2-fbd72c6799c2"), new Guid("b830d944-aa1b-4074-9a24-1ff60f1cd38d"), null, "Steel" },
                    { new Guid("48f8a123-6b7d-4a2e-928b-c1e6beb2e7f2"), new Guid("491df778-2c1a-4d5f-a0c9-d28b5ffcb747"), "3HGCM82655A789012", new Guid("22b793c7-8706-4850-aaa8-0f2fac8a2858"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0106e5db-0b88-4231-9cc0-263868fb5c01"), new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 75000, new Guid("40b9b81b-ccb9-4906-ad6d-7f0c2a9c728d"), "78CD456", 18000.00m, new Guid("667742ae-ae24-4d8c-9029-57ab5ba305ba"), false, true, new Guid("b8cb292b-c61b-4c73-9f20-f8fe2b746b5a"), new Guid("2c450873-2f0b-4da2-a7ff-245ca5c73e19"), null, "Alloy" },
                    { new Guid("948018bd-0032-4a6e-928b-c1e6beb2e76b"), new Guid("1e6fa0ec-590b-4d7f-8036-63f823390031"), "1HGCM82633A123456", new Guid("38211267-9cce-4040-adae-0c64bc26dab8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("12f9441e-92f2-4333-9e55-b1131c1bfde3"), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 60000, new Guid("e1721aa6-b49b-4290-8f71-ae5d17267d5a"), "34GS407", 25000.00m, new Guid("056dd418-5114-4ea1-baf3-07d4b8fc26f6"), true, true, new Guid("47e992e3-6561-49ff-a827-0e19aaf10345"), new Guid("b830d944-aa1b-4074-9a24-1ff60f1cd38d"), null, "Alloy" }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "AdvertNo", "CarId", "CreatedDate", "DeletedDate", "SellerId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("87b836e5-0f84-4bc0-8825-0a3c50277385"), 2, new Guid("12f8c123-4b6d-4a1e-928b-c1e6beb2e6f1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null },
                    { new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"), 1, new Guid("948018bd-0032-4a6e-928b-c1e6beb2e76b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "CarId", "CreatedDate", "CustomerId", "DateAndTime", "DeletedDate", "UpdatedDate" },
                values: new object[] { new Guid("72f3de2b-6f55-400b-9b17-7e9c7dcb3167"), new Guid("48f8a123-6b7d-4a2e-928b-c1e6beb2e7f2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b1e3b9cd-1c82-4f68-a70e-8349c28af525"), new DateTime(2024, 7, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.InsertData(
                table: "AdvertImages",
                columns: new[] { "Id", "AdvertId", "CreatedDate", "DeletedDate", "ImageURL", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("31895bc7-6acb-47ab-b17e-c25cdf4e206a"), new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927430/wkhtgdd9329qljrwrtct.jpg", null },
                    { new Guid("4003779f-2f80-44aa-9569-737c0fa8fd5e"), new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927428/hdfqjaqsgg9ujzkmmg8k.jpg", null },
                    { new Guid("41d24792-ce26-41a7-ab03-86dd2b20da0e"), new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927430/e1trhsymprfpj4cv8qsj.jpg", null },
                    { new Guid("48360d95-19b9-4dc6-a5f9-ed7150ecd965"), new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927432/mkkciln87ynjbnje13ft.jpg", null },
                    { new Guid("7ad496e8-4960-42e5-947e-3af49eb2b54b"), new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927427/uebfhjzoiofr0epripub.jpg", null },
                    { new Guid("9439d26c-d71c-4fb4-948f-bcf7969875b0"), new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927428/sjswo927ezke9ad4ehiq.jpg", null },
                    { new Guid("9b099ef1-1465-457a-8f53-fe1322cbd1cc"), new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927433/rq2hr77xj9psnaau2qed.jpg", null },
                    { new Guid("abff24eb-4e70-4ed8-9628-6cbae7351290"), new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927430/dsjdl0uscjqi7dpwvjbb.jpg", null },
                    { new Guid("b755d05c-57f6-4929-ace4-5478f32dadb4"), new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927431/iwqgm7levti1a1peom4i.jpg", null },
                    { new Guid("e6bd50d8-861e-4696-8be6-74ed1a268090"), new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927429/x8tr1bwix1qafh6ekps2.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "CustomerAdvertLogs",
                columns: new[] { "Id", "AdvertId", "ContactStatus", "CreatedDate", "CustomerId", "DeletedDate", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2b6897d8-6964-4d3f-9bd7-e4e16a9285d1"), new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ab623e31-88ab-48cb-8942-2c541343d651"), null, null },
                    { new Guid("5015e481-036b-4f18-a500-28ecdbab1327"), new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("27ca8f20-333f-4fc2-a535-c156a2aec150"), null, null }
                });

            migrationBuilder.InsertData(
                table: "CustomerFavorites",
                columns: new[] { "Id", "AdvertId", "CreatedDate", "CustomerId", "DeletedDate", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("374b8206-bc64-47e1-8a3b-3359fb8eba1f"), new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ab623e31-88ab-48cb-8942-2c541343d651"), null, null },
                    { new Guid("3bdf5ae4-4e67-445b-85f9-005575de78fd"), new Guid("87b836e5-0f84-4bc0-8825-0a3c50277385"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ab623e31-88ab-48cb-8942-2c541343d651"), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertImages_AdvertId",
                table: "AdvertImages",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_CarId",
                table: "Adverts",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_SellerId",
                table: "Adverts",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CarId",
                table: "Appointments",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogItemTags_BlogId",
                table: "BlogItemTags",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogItemTags_TagId",
                table: "BlogItemTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_BrandId",
                table: "CarModels",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BodyTypeId",
                table: "Cars",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ColorId",
                table: "Cars",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineId",
                table: "Cars",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModalExtensionId",
                table: "Cars",
                column: "ModalExtensionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_SellerId",
                table: "Cars",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TramerId",
                table: "Cars",
                column: "TramerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TransmissionId",
                table: "Cars",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAdvertLogs_AdvertId",
                table: "CustomerAdvertLogs",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAdvertLogs_CustomerId",
                table: "CustomerAdvertLogs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFavorites_AdvertId",
                table: "CustomerFavorites",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFavorites_CustomerId",
                table: "CustomerFavorites",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailAuthenticators_UserId",
                table: "EmailAuthenticators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Engines_FuelTypeId",
                table: "Engines",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertizeResults_BodyShellPartId",
                table: "ExpertizeResults",
                column: "BodyShellPartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpertizeResults_ChassisPartId",
                table: "ExpertizeResults",
                column: "ChassisPartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenerationImages_GenerationId",
                table: "GenerationImages",
                column: "GenerationId");

            migrationBuilder.CreateIndex(
                name: "IX_ModalExtensions_CarModelId",
                table: "ModalExtensions",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModalExtensions_GenerationId",
                table: "ModalExtensions",
                column: "GenerationId");

            migrationBuilder.CreateIndex(
                name: "IX_OtpAuthenticators_UserId",
                table: "OtpAuthenticators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_LicenceId",
                table: "Sellers",
                column: "LicenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_LocationId",
                table: "Sellers",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_UserId",
                table: "Sellers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertImages");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "BlogItemTags");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "CustomerAdvertLogs");

            migrationBuilder.DropTable(
                name: "CustomerFavorites");

            migrationBuilder.DropTable(
                name: "EmailAuthenticators");

            migrationBuilder.DropTable(
                name: "GenerationImages");

            migrationBuilder.DropTable(
                name: "OtpAuthenticators");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "BodyTypes");

            migrationBuilder.DropTable(
                name: "CarColors");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "ExpertizeResults");

            migrationBuilder.DropTable(
                name: "ModalExtensions");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "Transmissions");

            migrationBuilder.DropTable(
                name: "FuelTypes");

            migrationBuilder.DropTable(
                name: "BodyShellParts");

            migrationBuilder.DropTable(
                name: "ChassisParts");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "Generations");

            migrationBuilder.DropTable(
                name: "Licences");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
