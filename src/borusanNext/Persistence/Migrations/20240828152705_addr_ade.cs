using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addr_ade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("2353c39c-7ebf-40e7-a9a8-1b15f616b52c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b345972e-61c4-451c-82e6-e26a48393ddf"));
            
            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Sellers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));


            migrationBuilder.AddColumn<string>(
                name: "AddressLine",
                table: "Sellers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Latitute",
                table: "Sellers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LicenceNo",
                table: "Sellers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Longitute",
                table: "Sellers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProvidedBy",
                table: "Sellers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Customers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AddressLine",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentityNumber",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    District = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("96ec5f7f-8b0f-41b9-9694-e9968fd49f7a"),
                column: "Logo",
                value: "https://res.cloudinary.com/dl0cotczj/image/upload/v1724597194/szhvy5qofpb482r5yazn.png");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("27ca8f20-333f-4fc2-a535-c156a2aec150"),
                columns: new[] { "AddressId", "AddressLine", "IdentityNumber" },
                values: new object[] { new Guid("a48e5400-d10b-450c-817a-6a5188e13de9"), "", "44444444444" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("ab623e31-88ab-48cb-8942-2c541343d651"),
                columns: new[] { "AddressId", "AddressLine", "IdentityNumber" },
                values: new object[] { new Guid("a48e5400-d10b-450c-817a-6a5188e13de9"), "", "33333333333" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b1e3b9cd-1c82-4f68-a70e-8349c28af525"),
                columns: new[] { "AddressId", "AddressLine", "IdentityNumber" },
                values: new object[] { new Guid("a48e5400-d10b-450c-817a-6a5188e13de9"), "", "11111111111" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("d2f17680-26d1-4ac3-90c6-4ffec9e5c0ad"),
                columns: new[] { "AddressId", "AddressLine", "IdentityNumber" },
                values: new object[] { new Guid("a48e5400-d10b-450c-817a-6a5188e13de9"), "", "22222222222" });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 114,
                column: "Name",
                value: "Tags.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 115,
                column: "Name",
                value: "Tags.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 116,
                column: "Name",
                value: "Tags.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 117,
                column: "Name",
                value: "Tags.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 118,
                column: "Name",
                value: "Tags.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 119,
                column: "Name",
                value: "Tags.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 120,
                column: "Name",
                value: "Transmissions.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 121,
                column: "Name",
                value: "Transmissions.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 122,
                column: "Name",
                value: "Transmissions.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 123,
                column: "Name",
                value: "Transmissions.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 124,
                column: "Name",
                value: "Transmissions.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 125,
                column: "Name",
                value: "Transmissions.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 126,
                column: "Name",
                value: "Customers.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 127,
                column: "Name",
                value: "Customers.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 128,
                column: "Name",
                value: "Customers.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 129,
                column: "Name",
                value: "Customers.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 130,
                column: "Name",
                value: "Customers.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 131,
                column: "Name",
                value: "Customers.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 132,
                column: "Name",
                value: "Sellers.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 133,
                column: "Name",
                value: "Sellers.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 134,
                column: "Name",
                value: "Sellers.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 135,
                column: "Name",
                value: "Sellers.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 136,
                column: "Name",
                value: "Sellers.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 137,
                column: "Name",
                value: "Sellers.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 138,
                column: "Name",
                value: "ExpertizeResults.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 139,
                column: "Name",
                value: "ExpertizeResults.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 140,
                column: "Name",
                value: "ExpertizeResults.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 141,
                column: "Name",
                value: "ExpertizeResults.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 142,
                column: "Name",
                value: "ExpertizeResults.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 143,
                column: "Name",
                value: "ExpertizeResults.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 144,
                column: "Name",
                value: "Adverts.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 145,
                column: "Name",
                value: "Adverts.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 146,
                column: "Name",
                value: "Adverts.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 147,
                column: "Name",
                value: "Adverts.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 148,
                column: "Name",
                value: "Adverts.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 149,
                column: "Name",
                value: "Adverts.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 150,
                column: "Name",
                value: "CarModels.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 151,
                column: "Name",
                value: "CarModels.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 152,
                column: "Name",
                value: "CarModels.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 153,
                column: "Name",
                value: "CarModels.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 154,
                column: "Name",
                value: "CarModels.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 155,
                column: "Name",
                value: "CarModels.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 156,
                column: "Name",
                value: "AdvertImages.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 157,
                column: "Name",
                value: "AdvertImages.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 158,
                column: "Name",
                value: "AdvertImages.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 159,
                column: "Name",
                value: "AdvertImages.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 160,
                column: "Name",
                value: "AdvertImages.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 161,
                column: "Name",
                value: "AdvertImages.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 162,
                column: "Name",
                value: "ModalExtensions.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 163,
                column: "Name",
                value: "ModalExtensions.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 164,
                column: "Name",
                value: "ModalExtensions.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 165,
                column: "Name",
                value: "ModalExtensions.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 166,
                column: "Name",
                value: "ModalExtensions.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 167,
                column: "Name",
                value: "ModalExtensions.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 168,
                column: "Name",
                value: "GenerationImages.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 169,
                column: "Name",
                value: "GenerationImages.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 170,
                column: "Name",
                value: "GenerationImages.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 171,
                column: "Name",
                value: "GenerationImages.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 172,
                column: "Name",
                value: "GenerationImages.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 173,
                column: "Name",
                value: "GenerationImages.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 174,
                column: "Name",
                value: "Cars.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 175,
                column: "Name",
                value: "Cars.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 176,
                column: "Name",
                value: "Cars.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 177,
                column: "Name",
                value: "Cars.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 178,
                column: "Name",
                value: "Cars.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 179,
                column: "Name",
                value: "Cars.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 180,
                column: "Name",
                value: "CustomerFavorites.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 181,
                column: "Name",
                value: "CustomerFavorites.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 182,
                column: "Name",
                value: "CustomerFavorites.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 183,
                column: "Name",
                value: "CustomerFavorites.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 184,
                column: "Name",
                value: "CustomerFavorites.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 185,
                column: "Name",
                value: "CustomerFavorites.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 186,
                column: "Name",
                value: "AdvertDetails.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 187,
                column: "Name",
                value: "AdvertDetails.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 188,
                column: "Name",
                value: "CarModelDetails.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 189,
                column: "Name",
                value: "CarModelDetails.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 190,
                column: "Name",
                value: "Pricing.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 191,
                column: "Name",
                value: "Pricing.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 192,
                column: "Name",
                value: "Addresses.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 193,
                column: "Name",
                value: "Addresses.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 194,
                column: "Name",
                value: "Addresses.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 195,
                column: "Name",
                value: "Addresses.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 196,
                column: "Name",
                value: "Addresses.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 197,
                column: "Name",
                value: "Addresses.Delete");

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: new Guid("056dd418-5114-4ea1-baf3-07d4b8fc26f6"),
                columns: new[] { "AddressId", "AddressLine", "Latitute", "LicenceNo", "Longitute", "ProvidedBy" },
                values: new object[] { new Guid("047c6a96-da39-4b67-b68d-1b1956ca2e7d"), "Firüzköy Yolu No: 21 Avcılar", "40.992769", 0, "28.716821", "Burak" });

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: new Guid("785d6af9-4404-4d7a-ad3e-82319812b037"),
                columns: new[] { "AddressId", "AddressLine", "Latitute", "LicenceNo", "Longitute", "ProvidedBy" },
                values: new object[] { new Guid("a48e5400-d10b-450c-817a-6a5188e13de9"), "Akpınar, Bilim Cd. No:2, 34485 Sancaktepe", "40.9753623", 0, "29.2244372", "Burak" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36160d4c-8a2a-4959-9769-ebf2bd812237"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 190, 51, 253, 201, 61, 125, 215, 21, 147, 43, 136, 2, 182, 37, 233, 124, 12, 134, 196, 47, 190, 149, 10, 133, 215, 98, 20, 57, 127, 41, 88, 76, 121, 87, 144, 224, 78, 112, 236, 220, 217, 229, 213, 160, 222, 63, 34, 196, 141, 94, 156, 166, 216, 170, 213, 241, 164, 38, 140, 32, 119, 174, 224, 169 }, new byte[] { 51, 212, 213, 220, 80, 123, 23, 143, 87, 248, 104, 40, 169, 1, 247, 223, 249, 179, 232, 36, 197, 181, 43, 78, 24, 140, 234, 17, 206, 23, 160, 153, 206, 53, 66, 239, 214, 217, 228, 7, 91, 129, 81, 168, 214, 102, 52, 102, 55, 222, 195, 183, 250, 170, 212, 179, 17, 199, 123, 106, 144, 110, 8, 92, 175, 99, 68, 248, 239, 206, 123, 146, 186, 139, 112, 50, 212, 109, 32, 81, 89, 87, 50, 186, 89, 98, 231, 124, 208, 151, 23, 161, 14, 248, 249, 187, 121, 158, 202, 156, 165, 69, 230, 109, 78, 44, 219, 250, 235, 122, 87, 128, 48, 203, 126, 165, 240, 103, 59, 98, 1, 11, 10, 200, 28, 102, 194, 55 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("398b5d31-f2e2-473f-8f40-78f7e79af217"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 190, 51, 253, 201, 61, 125, 215, 21, 147, 43, 136, 2, 182, 37, 233, 124, 12, 134, 196, 47, 190, 149, 10, 133, 215, 98, 20, 57, 127, 41, 88, 76, 121, 87, 144, 224, 78, 112, 236, 220, 217, 229, 213, 160, 222, 63, 34, 196, 141, 94, 156, 166, 216, 170, 213, 241, 164, 38, 140, 32, 119, 174, 224, 169 }, new byte[] { 51, 212, 213, 220, 80, 123, 23, 143, 87, 248, 104, 40, 169, 1, 247, 223, 249, 179, 232, 36, 197, 181, 43, 78, 24, 140, 234, 17, 206, 23, 160, 153, 206, 53, 66, 239, 214, 217, 228, 7, 91, 129, 81, 168, 214, 102, 52, 102, 55, 222, 195, 183, 250, 170, 212, 179, 17, 199, 123, 106, 144, 110, 8, 92, 175, 99, 68, 248, 239, 206, 123, 146, 186, 139, 112, 50, 212, 109, 32, 81, 89, 87, 50, 186, 89, 98, 231, 124, 208, 151, 23, 161, 14, 248, 249, 187, 121, 158, 202, 156, 165, 69, 230, 109, 78, 44, 219, 250, 235, 122, 87, 128, 48, 203, 126, 165, 240, 103, 59, 98, 1, 11, 10, 200, 28, 102, 194, 55 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6444d306-ab8e-4e84-a6ff-77037d68fd2e"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 190, 51, 253, 201, 61, 125, 215, 21, 147, 43, 136, 2, 182, 37, 233, 124, 12, 134, 196, 47, 190, 149, 10, 133, 215, 98, 20, 57, 127, 41, 88, 76, 121, 87, 144, 224, 78, 112, 236, 220, 217, 229, 213, 160, 222, 63, 34, 196, 141, 94, 156, 166, 216, 170, 213, 241, 164, 38, 140, 32, 119, 174, 224, 169 }, new byte[] { 51, 212, 213, 220, 80, 123, 23, 143, 87, 248, 104, 40, 169, 1, 247, 223, 249, 179, 232, 36, 197, 181, 43, 78, 24, 140, 234, 17, 206, 23, 160, 153, 206, 53, 66, 239, 214, 217, 228, 7, 91, 129, 81, 168, 214, 102, 52, 102, 55, 222, 195, 183, 250, 170, 212, 179, 17, 199, 123, 106, 144, 110, 8, 92, 175, 99, 68, 248, 239, 206, 123, 146, 186, 139, 112, 50, 212, 109, 32, 81, 89, 87, 50, 186, 89, 98, 231, 124, 208, 151, 23, 161, 14, 248, 249, 187, 121, 158, 202, 156, 165, 69, 230, 109, 78, 44, 219, 250, 235, 122, 87, 128, 48, 203, 126, 165, 240, 103, 59, 98, 1, 11, 10, 200, 28, 102, 194, 55 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd8e0f-59d4-4532-ae32-03cec3e39158"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 190, 51, 253, 201, 61, 125, 215, 21, 147, 43, 136, 2, 182, 37, 233, 124, 12, 134, 196, 47, 190, 149, 10, 133, 215, 98, 20, 57, 127, 41, 88, 76, 121, 87, 144, 224, 78, 112, 236, 220, 217, 229, 213, 160, 222, 63, 34, 196, 141, 94, 156, 166, 216, 170, 213, 241, 164, 38, 140, 32, 119, 174, 224, 169 }, new byte[] { 51, 212, 213, 220, 80, 123, 23, 143, 87, 248, 104, 40, 169, 1, 247, 223, 249, 179, 232, 36, 197, 181, 43, 78, 24, 140, 234, 17, 206, 23, 160, 153, 206, 53, 66, 239, 214, 217, 228, 7, 91, 129, 81, 168, 214, 102, 52, 102, 55, 222, 195, 183, 250, 170, 212, 179, 17, 199, 123, 106, 144, 110, 8, 92, 175, 99, 68, 248, 239, 206, 123, 146, 186, 139, 112, 50, 212, 109, 32, 81, 89, 87, 50, 186, 89, 98, 231, 124, 208, 151, 23, 161, 14, 248, 249, 187, 121, 158, 202, 156, 165, 69, 230, 109, 78, 44, 219, 250, 235, 122, 87, 128, 48, 203, 126, 165, 240, 103, 59, 98, 1, 11, 10, 200, 28, 102, 194, 55 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ada31c5d-6014-46d2-a1c3-ed8007e898cf"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 190, 51, 253, 201, 61, 125, 215, 21, 147, 43, 136, 2, 182, 37, 233, 124, 12, 134, 196, 47, 190, 149, 10, 133, 215, 98, 20, 57, 127, 41, 88, 76, 121, 87, 144, 224, 78, 112, 236, 220, 217, 229, 213, 160, 222, 63, 34, 196, 141, 94, 156, 166, 216, 170, 213, 241, 164, 38, 140, 32, 119, 174, 224, 169 }, new byte[] { 51, 212, 213, 220, 80, 123, 23, 143, 87, 248, 104, 40, 169, 1, 247, 223, 249, 179, 232, 36, 197, 181, 43, 78, 24, 140, 234, 17, 206, 23, 160, 153, 206, 53, 66, 239, 214, 217, 228, 7, 91, 129, 81, 168, 214, 102, 52, 102, 55, 222, 195, 183, 250, 170, 212, 179, 17, 199, 123, 106, 144, 110, 8, 92, 175, 99, 68, 248, 239, 206, 123, 146, 186, 139, 112, 50, 212, 109, 32, 81, 89, 87, 50, 186, 89, 98, 231, 124, 208, 151, 23, 161, 14, 248, 249, 187, 121, 158, 202, 156, 165, 69, 230, 109, 78, 44, 219, 250, 235, 122, 87, 128, 48, 203, 126, 165, 240, 103, 59, 98, 1, 11, 10, 200, 28, 102, 194, 55 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b73f6541-460e-4d9d-97eb-1402f63df038"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 190, 51, 253, 201, 61, 125, 215, 21, 147, 43, 136, 2, 182, 37, 233, 124, 12, 134, 196, 47, 190, 149, 10, 133, 215, 98, 20, 57, 127, 41, 88, 76, 121, 87, 144, 224, 78, 112, 236, 220, 217, 229, 213, 160, 222, 63, 34, 196, 141, 94, 156, 166, 216, 170, 213, 241, 164, 38, 140, 32, 119, 174, 224, 169 }, new byte[] { 51, 212, 213, 220, 80, 123, 23, 143, 87, 248, 104, 40, 169, 1, 247, 223, 249, 179, 232, 36, 197, 181, 43, 78, 24, 140, 234, 17, 206, 23, 160, 153, 206, 53, 66, 239, 214, 217, 228, 7, 91, 129, 81, 168, 214, 102, 52, 102, 55, 222, 195, 183, 250, 170, 212, 179, 17, 199, 123, 106, 144, 110, 8, 92, 175, 99, 68, 248, 239, 206, 123, 146, 186, 139, 112, 50, 212, 109, 32, 81, 89, 87, 50, 186, 89, 98, 231, 124, 208, 151, 23, 161, 14, 248, 249, 187, 121, 158, 202, 156, 165, 69, 230, 109, 78, 44, 219, 250, 235, 122, 87, 128, 48, 203, 126, 165, 240, 103, 59, 98, 1, 11, 10, 200, 28, 102, 194, 55 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd4dd3dc-72e4-42cb-bde3-0fcb1867b10d"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 190, 51, 253, 201, 61, 125, 215, 21, 147, 43, 136, 2, 182, 37, 233, 124, 12, 134, 196, 47, 190, 149, 10, 133, 215, 98, 20, 57, 127, 41, 88, 76, 121, 87, 144, 224, 78, 112, 236, 220, 217, 229, 213, 160, 222, 63, 34, 196, 141, 94, 156, 166, 216, 170, 213, 241, 164, 38, 140, 32, 119, 174, 224, 169 }, new byte[] { 51, 212, 213, 220, 80, 123, 23, 143, 87, 248, 104, 40, 169, 1, 247, 223, 249, 179, 232, 36, 197, 181, 43, 78, 24, 140, 234, 17, 206, 23, 160, 153, 206, 53, 66, 239, 214, 217, 228, 7, 91, 129, 81, 168, 214, 102, 52, 102, 55, 222, 195, 183, 250, 170, 212, 179, 17, 199, 123, 106, 144, 110, 8, 92, 175, 99, 68, 248, 239, 206, 123, 146, 186, 139, 112, 50, 212, 109, 32, 81, 89, 87, 50, 186, 89, 98, 231, 124, 208, 151, 23, 161, 14, 248, 249, 187, 121, 158, 202, 156, 165, 69, 230, 109, 78, 44, 219, 250, 235, 122, 87, 128, 48, 203, 126, 165, 240, 103, 59, 98, 1, 11, 10, 200, 28, 102, 194, 55 } });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "Provider", "UpdatedDate" },
                values: new object[] { new Guid("784f958c-a60b-4805-af3b-7c219a7a953f"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@borusan.com", new byte[] { 190, 51, 253, 201, 61, 125, 215, 21, 147, 43, 136, 2, 182, 37, 233, 124, 12, 134, 196, 47, 190, 149, 10, 133, 215, 98, 20, 57, 127, 41, 88, 76, 121, 87, 144, 224, 78, 112, 236, 220, 217, 229, 213, 160, 222, 63, 34, 196, 141, 94, 156, 166, 216, 170, 213, 241, 164, 38, 140, 32, 119, 174, 224, 169 }, new byte[] { 51, 212, 213, 220, 80, 123, 23, 143, 87, 248, 104, 40, 169, 1, 247, 223, 249, 179, 232, 36, 197, 181, 43, 78, 24, 140, 234, 17, 206, 23, 160, 153, 206, 53, 66, 239, 214, 217, 228, 7, 91, 129, 81, 168, 214, 102, 52, 102, 55, 222, 195, 183, 250, 170, 212, 179, 17, 199, 123, 106, 144, 110, 8, 92, 175, 99, 68, 248, 239, 206, 123, 146, 186, 139, 112, 50, 212, 109, 32, 81, 89, 87, 50, 186, 89, 98, 231, 124, 208, 151, 23, 161, 14, 248, 249, 187, 121, 158, 202, 156, 165, 69, 230, 109, 78, 44, 219, 250, 235, 122, 87, 128, 48, 203, 126, 165, 240, 103, 59, 98, 1, 11, 10, 200, 28, 102, 194, 55 }, 0, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("5f72a330-a581-4b88-92bc-b93e42dc82bc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("784f958c-a60b-4805-af3b-7c219a7a953f") });

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_AddressId",
                table: "Sellers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Customers_Addresses_AddressId",
            //    table: "Customers",
            //    column: "AddressId",
            //    principalTable: "Addresses",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Sellers_Addresses_AddressId",
            //    table: "Sellers",
            //    column: "AddressId",
            //    principalTable: "Addresses",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_AddressId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Addresses_AddressId",
                table: "Sellers");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Sellers_AddressId",
                table: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("5f72a330-a581-4b88-92bc-b93e42dc82bc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("784f958c-a60b-4805-af3b-7c219a7a953f"));

            migrationBuilder.DropColumn(
                name: "AddressLine",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Latitute",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "LicenceNo",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Longitute",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "ProvidedBy",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AddressLine",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IdentityNumber",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Sellers",
                newName: "LocationId");

            migrationBuilder.AddColumn<Guid>(
                name: "LicenceId",
                table: "Sellers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Licences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    LicenceNo = table.Column<int>(type: "integer", nullable: false),
                    ProvidedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
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
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Latitute = table.Column<string>(type: "text", nullable: false),
                    Longitute = table.Column<string>(type: "text", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("96ec5f7f-8b0f-41b9-9694-e9968fd49f7a"),
                column: "Logo",
                value: "https://res.cloudinary.com/dl0cotczj/image/upload/v1722106757/dalglsprdgaabq0m7jmg.png");

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

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 114,
                column: "Name",
                value: "Licences.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 115,
                column: "Name",
                value: "Licences.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 116,
                column: "Name",
                value: "Licences.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 117,
                column: "Name",
                value: "Licences.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 118,
                column: "Name",
                value: "Licences.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 119,
                column: "Name",
                value: "Licences.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 120,
                column: "Name",
                value: "Locations.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 121,
                column: "Name",
                value: "Locations.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 122,
                column: "Name",
                value: "Locations.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 123,
                column: "Name",
                value: "Locations.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 124,
                column: "Name",
                value: "Locations.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 125,
                column: "Name",
                value: "Locations.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 126,
                column: "Name",
                value: "Tags.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 127,
                column: "Name",
                value: "Tags.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 128,
                column: "Name",
                value: "Tags.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 129,
                column: "Name",
                value: "Tags.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 130,
                column: "Name",
                value: "Tags.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 131,
                column: "Name",
                value: "Tags.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 132,
                column: "Name",
                value: "Transmissions.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 133,
                column: "Name",
                value: "Transmissions.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 134,
                column: "Name",
                value: "Transmissions.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 135,
                column: "Name",
                value: "Transmissions.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 136,
                column: "Name",
                value: "Transmissions.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 137,
                column: "Name",
                value: "Transmissions.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 138,
                column: "Name",
                value: "Customers.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 139,
                column: "Name",
                value: "Customers.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 140,
                column: "Name",
                value: "Customers.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 141,
                column: "Name",
                value: "Customers.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 142,
                column: "Name",
                value: "Customers.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 143,
                column: "Name",
                value: "Customers.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 144,
                column: "Name",
                value: "Sellers.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 145,
                column: "Name",
                value: "Sellers.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 146,
                column: "Name",
                value: "Sellers.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 147,
                column: "Name",
                value: "Sellers.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 148,
                column: "Name",
                value: "Sellers.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 149,
                column: "Name",
                value: "Sellers.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 150,
                column: "Name",
                value: "Locations.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 151,
                column: "Name",
                value: "Locations.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 152,
                column: "Name",
                value: "Locations.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 153,
                column: "Name",
                value: "Locations.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 154,
                column: "Name",
                value: "Locations.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 155,
                column: "Name",
                value: "Locations.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 156,
                column: "Name",
                value: "ExpertizeResults.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 157,
                column: "Name",
                value: "ExpertizeResults.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 158,
                column: "Name",
                value: "ExpertizeResults.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 159,
                column: "Name",
                value: "ExpertizeResults.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 160,
                column: "Name",
                value: "ExpertizeResults.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 161,
                column: "Name",
                value: "ExpertizeResults.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 162,
                column: "Name",
                value: "Adverts.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 163,
                column: "Name",
                value: "Adverts.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 164,
                column: "Name",
                value: "Adverts.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 165,
                column: "Name",
                value: "Adverts.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 166,
                column: "Name",
                value: "Adverts.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 167,
                column: "Name",
                value: "Adverts.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 168,
                column: "Name",
                value: "CarModels.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 169,
                column: "Name",
                value: "CarModels.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 170,
                column: "Name",
                value: "CarModels.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 171,
                column: "Name",
                value: "CarModels.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 172,
                column: "Name",
                value: "CarModels.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 173,
                column: "Name",
                value: "CarModels.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 174,
                column: "Name",
                value: "AdvertImages.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 175,
                column: "Name",
                value: "AdvertImages.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 176,
                column: "Name",
                value: "AdvertImages.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 177,
                column: "Name",
                value: "AdvertImages.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 178,
                column: "Name",
                value: "AdvertImages.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 179,
                column: "Name",
                value: "AdvertImages.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 180,
                column: "Name",
                value: "ModalExtensions.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 181,
                column: "Name",
                value: "ModalExtensions.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 182,
                column: "Name",
                value: "ModalExtensions.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 183,
                column: "Name",
                value: "ModalExtensions.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 184,
                column: "Name",
                value: "ModalExtensions.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 185,
                column: "Name",
                value: "ModalExtensions.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 186,
                column: "Name",
                value: "GenerationImages.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 187,
                column: "Name",
                value: "GenerationImages.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 188,
                column: "Name",
                value: "GenerationImages.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 189,
                column: "Name",
                value: "GenerationImages.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 190,
                column: "Name",
                value: "GenerationImages.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 191,
                column: "Name",
                value: "GenerationImages.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 192,
                column: "Name",
                value: "Cars.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 193,
                column: "Name",
                value: "Cars.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 194,
                column: "Name",
                value: "Cars.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 195,
                column: "Name",
                value: "Cars.Create");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 196,
                column: "Name",
                value: "Cars.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 197,
                column: "Name",
                value: "Cars.Delete");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 198, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Admin", null },
                    { 199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Read", null },
                    { 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Write", null },
                    { 201, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Create", null },
                    { 202, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Update", null },
                    { 203, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Delete", null },
                    { 204, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AdvertDetails.Admin", null },
                    { 205, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AdvertDetails.Read", null },
                    { 206, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarModelDetails.Admin", null },
                    { 207, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CarModelDetails.Read", null }
                });

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: new Guid("056dd418-5114-4ea1-baf3-07d4b8fc26f6"),
                columns: new[] { "LicenceId", "LocationId" },
                values: new object[] { new Guid("7f30d80f-3a7b-429c-81a5-0c9507839691"), new Guid("59a7ddc2-3920-4652-9543-797fbd1d3d38") });

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: new Guid("785d6af9-4404-4d7a-ad3e-82319812b037"),
                columns: new[] { "LicenceId", "LocationId" },
                values: new object[] { new Guid("e99ccd48-51a3-46c0-b539-a28cec7d214c"), new Guid("2f565ad5-7ae1-42ad-82f2-96944052aa27") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36160d4c-8a2a-4959-9769-ebf2bd812237"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 75, 78, 130, 39, 198, 88, 171, 27, 174, 62, 73, 135, 29, 148, 235, 233, 193, 189, 98, 20, 19, 112, 178, 235, 230, 157, 212, 70, 199, 83, 130, 151, 95, 64, 171, 243, 240, 192, 44, 88, 124, 18, 105, 59, 129, 121, 229, 74, 223, 103, 191, 77, 49, 35, 172, 154, 210, 47, 247, 113, 156, 209, 31, 141 }, new byte[] { 66, 83, 110, 165, 231, 175, 119, 62, 184, 86, 7, 37, 254, 68, 6, 173, 122, 1, 27, 151, 184, 167, 114, 83, 129, 238, 81, 111, 106, 104, 58, 53, 199, 59, 246, 63, 89, 10, 40, 211, 10, 145, 31, 121, 99, 154, 97, 204, 229, 24, 57, 94, 177, 40, 82, 153, 202, 39, 237, 179, 234, 215, 101, 99, 193, 154, 100, 218, 3, 122, 62, 249, 198, 22, 134, 107, 239, 23, 209, 102, 183, 89, 236, 227, 248, 114, 5, 9, 136, 102, 42, 79, 22, 43, 154, 92, 129, 154, 172, 92, 113, 67, 154, 72, 122, 23, 118, 129, 61, 113, 248, 28, 150, 76, 167, 203, 109, 194, 4, 51, 142, 73, 98, 226, 151, 167, 148, 72 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("398b5d31-f2e2-473f-8f40-78f7e79af217"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 75, 78, 130, 39, 198, 88, 171, 27, 174, 62, 73, 135, 29, 148, 235, 233, 193, 189, 98, 20, 19, 112, 178, 235, 230, 157, 212, 70, 199, 83, 130, 151, 95, 64, 171, 243, 240, 192, 44, 88, 124, 18, 105, 59, 129, 121, 229, 74, 223, 103, 191, 77, 49, 35, 172, 154, 210, 47, 247, 113, 156, 209, 31, 141 }, new byte[] { 66, 83, 110, 165, 231, 175, 119, 62, 184, 86, 7, 37, 254, 68, 6, 173, 122, 1, 27, 151, 184, 167, 114, 83, 129, 238, 81, 111, 106, 104, 58, 53, 199, 59, 246, 63, 89, 10, 40, 211, 10, 145, 31, 121, 99, 154, 97, 204, 229, 24, 57, 94, 177, 40, 82, 153, 202, 39, 237, 179, 234, 215, 101, 99, 193, 154, 100, 218, 3, 122, 62, 249, 198, 22, 134, 107, 239, 23, 209, 102, 183, 89, 236, 227, 248, 114, 5, 9, 136, 102, 42, 79, 22, 43, 154, 92, 129, 154, 172, 92, 113, 67, 154, 72, 122, 23, 118, 129, 61, 113, 248, 28, 150, 76, 167, 203, 109, 194, 4, 51, 142, 73, 98, 226, 151, 167, 148, 72 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6444d306-ab8e-4e84-a6ff-77037d68fd2e"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 75, 78, 130, 39, 198, 88, 171, 27, 174, 62, 73, 135, 29, 148, 235, 233, 193, 189, 98, 20, 19, 112, 178, 235, 230, 157, 212, 70, 199, 83, 130, 151, 95, 64, 171, 243, 240, 192, 44, 88, 124, 18, 105, 59, 129, 121, 229, 74, 223, 103, 191, 77, 49, 35, 172, 154, 210, 47, 247, 113, 156, 209, 31, 141 }, new byte[] { 66, 83, 110, 165, 231, 175, 119, 62, 184, 86, 7, 37, 254, 68, 6, 173, 122, 1, 27, 151, 184, 167, 114, 83, 129, 238, 81, 111, 106, 104, 58, 53, 199, 59, 246, 63, 89, 10, 40, 211, 10, 145, 31, 121, 99, 154, 97, 204, 229, 24, 57, 94, 177, 40, 82, 153, 202, 39, 237, 179, 234, 215, 101, 99, 193, 154, 100, 218, 3, 122, 62, 249, 198, 22, 134, 107, 239, 23, 209, 102, 183, 89, 236, 227, 248, 114, 5, 9, 136, 102, 42, 79, 22, 43, 154, 92, 129, 154, 172, 92, 113, 67, 154, 72, 122, 23, 118, 129, 61, 113, 248, 28, 150, 76, 167, 203, 109, 194, 4, 51, 142, 73, 98, 226, 151, 167, 148, 72 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd8e0f-59d4-4532-ae32-03cec3e39158"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 75, 78, 130, 39, 198, 88, 171, 27, 174, 62, 73, 135, 29, 148, 235, 233, 193, 189, 98, 20, 19, 112, 178, 235, 230, 157, 212, 70, 199, 83, 130, 151, 95, 64, 171, 243, 240, 192, 44, 88, 124, 18, 105, 59, 129, 121, 229, 74, 223, 103, 191, 77, 49, 35, 172, 154, 210, 47, 247, 113, 156, 209, 31, 141 }, new byte[] { 66, 83, 110, 165, 231, 175, 119, 62, 184, 86, 7, 37, 254, 68, 6, 173, 122, 1, 27, 151, 184, 167, 114, 83, 129, 238, 81, 111, 106, 104, 58, 53, 199, 59, 246, 63, 89, 10, 40, 211, 10, 145, 31, 121, 99, 154, 97, 204, 229, 24, 57, 94, 177, 40, 82, 153, 202, 39, 237, 179, 234, 215, 101, 99, 193, 154, 100, 218, 3, 122, 62, 249, 198, 22, 134, 107, 239, 23, 209, 102, 183, 89, 236, 227, 248, 114, 5, 9, 136, 102, 42, 79, 22, 43, 154, 92, 129, 154, 172, 92, 113, 67, 154, 72, 122, 23, 118, 129, 61, 113, 248, 28, 150, 76, 167, 203, 109, 194, 4, 51, 142, 73, 98, 226, 151, 167, 148, 72 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ada31c5d-6014-46d2-a1c3-ed8007e898cf"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 75, 78, 130, 39, 198, 88, 171, 27, 174, 62, 73, 135, 29, 148, 235, 233, 193, 189, 98, 20, 19, 112, 178, 235, 230, 157, 212, 70, 199, 83, 130, 151, 95, 64, 171, 243, 240, 192, 44, 88, 124, 18, 105, 59, 129, 121, 229, 74, 223, 103, 191, 77, 49, 35, 172, 154, 210, 47, 247, 113, 156, 209, 31, 141 }, new byte[] { 66, 83, 110, 165, 231, 175, 119, 62, 184, 86, 7, 37, 254, 68, 6, 173, 122, 1, 27, 151, 184, 167, 114, 83, 129, 238, 81, 111, 106, 104, 58, 53, 199, 59, 246, 63, 89, 10, 40, 211, 10, 145, 31, 121, 99, 154, 97, 204, 229, 24, 57, 94, 177, 40, 82, 153, 202, 39, 237, 179, 234, 215, 101, 99, 193, 154, 100, 218, 3, 122, 62, 249, 198, 22, 134, 107, 239, 23, 209, 102, 183, 89, 236, 227, 248, 114, 5, 9, 136, 102, 42, 79, 22, 43, 154, 92, 129, 154, 172, 92, 113, 67, 154, 72, 122, 23, 118, 129, 61, 113, 248, 28, 150, 76, 167, 203, 109, 194, 4, 51, 142, 73, 98, 226, 151, 167, 148, 72 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b73f6541-460e-4d9d-97eb-1402f63df038"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 75, 78, 130, 39, 198, 88, 171, 27, 174, 62, 73, 135, 29, 148, 235, 233, 193, 189, 98, 20, 19, 112, 178, 235, 230, 157, 212, 70, 199, 83, 130, 151, 95, 64, 171, 243, 240, 192, 44, 88, 124, 18, 105, 59, 129, 121, 229, 74, 223, 103, 191, 77, 49, 35, 172, 154, 210, 47, 247, 113, 156, 209, 31, 141 }, new byte[] { 66, 83, 110, 165, 231, 175, 119, 62, 184, 86, 7, 37, 254, 68, 6, 173, 122, 1, 27, 151, 184, 167, 114, 83, 129, 238, 81, 111, 106, 104, 58, 53, 199, 59, 246, 63, 89, 10, 40, 211, 10, 145, 31, 121, 99, 154, 97, 204, 229, 24, 57, 94, 177, 40, 82, 153, 202, 39, 237, 179, 234, 215, 101, 99, 193, 154, 100, 218, 3, 122, 62, 249, 198, 22, 134, 107, 239, 23, 209, 102, 183, 89, 236, 227, 248, 114, 5, 9, 136, 102, 42, 79, 22, 43, 154, 92, 129, 154, 172, 92, 113, 67, 154, 72, 122, 23, 118, 129, 61, 113, 248, 28, 150, 76, 167, 203, 109, 194, 4, 51, 142, 73, 98, 226, 151, 167, 148, 72 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd4dd3dc-72e4-42cb-bde3-0fcb1867b10d"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 75, 78, 130, 39, 198, 88, 171, 27, 174, 62, 73, 135, 29, 148, 235, 233, 193, 189, 98, 20, 19, 112, 178, 235, 230, 157, 212, 70, 199, 83, 130, 151, 95, 64, 171, 243, 240, 192, 44, 88, 124, 18, 105, 59, 129, 121, 229, 74, 223, 103, 191, 77, 49, 35, 172, 154, 210, 47, 247, 113, 156, 209, 31, 141 }, new byte[] { 66, 83, 110, 165, 231, 175, 119, 62, 184, 86, 7, 37, 254, 68, 6, 173, 122, 1, 27, 151, 184, 167, 114, 83, 129, 238, 81, 111, 106, 104, 58, 53, 199, 59, 246, 63, 89, 10, 40, 211, 10, 145, 31, 121, 99, 154, 97, 204, 229, 24, 57, 94, 177, 40, 82, 153, 202, 39, 237, 179, 234, 215, 101, 99, 193, 154, 100, 218, 3, 122, 62, 249, 198, 22, 134, 107, 239, 23, 209, 102, 183, 89, 236, 227, 248, 114, 5, 9, 136, 102, 42, 79, 22, 43, 154, 92, 129, 154, 172, 92, 113, 67, 154, 72, 122, 23, 118, 129, 61, 113, 248, 28, 150, 76, 167, 203, 109, 194, 4, 51, 142, 73, 98, 226, 151, 167, 148, 72 } });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "Provider", "UpdatedDate" },
                values: new object[] { new Guid("b345972e-61c4-451c-82e6-e26a48393ddf"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@borusan.com", new byte[] { 75, 78, 130, 39, 198, 88, 171, 27, 174, 62, 73, 135, 29, 148, 235, 233, 193, 189, 98, 20, 19, 112, 178, 235, 230, 157, 212, 70, 199, 83, 130, 151, 95, 64, 171, 243, 240, 192, 44, 88, 124, 18, 105, 59, 129, 121, 229, 74, 223, 103, 191, 77, 49, 35, 172, 154, 210, 47, 247, 113, 156, 209, 31, 141 }, new byte[] { 66, 83, 110, 165, 231, 175, 119, 62, 184, 86, 7, 37, 254, 68, 6, 173, 122, 1, 27, 151, 184, 167, 114, 83, 129, 238, 81, 111, 106, 104, 58, 53, 199, 59, 246, 63, 89, 10, 40, 211, 10, 145, 31, 121, 99, 154, 97, 204, 229, 24, 57, 94, 177, 40, 82, 153, 202, 39, 237, 179, 234, 215, 101, 99, 193, 154, 100, 218, 3, 122, 62, 249, 198, 22, 134, 107, 239, 23, 209, 102, 183, 89, 236, 227, 248, 114, 5, 9, 136, 102, 42, 79, 22, 43, 154, 92, 129, 154, 172, 92, 113, 67, 154, 72, 122, 23, 118, 129, 61, 113, 248, 28, 150, 76, 167, 203, 109, 194, 4, 51, 142, 73, 98, 226, 151, 167, 148, 72 }, 0, null });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "LicenceId", "LocationId", "Name", "PhoneNumber", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("667742ae-ae24-4d8c-9029-57ab5ba305ba"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("d1993933-0185-4333-888c-36f226993e1c"), new Guid("4744af1a-89ba-4d1b-890c-9d3e3c755cda"), "Kececi Oto", "5556667777", null, new Guid("398b5d31-f2e2-473f-8f40-78f7e79af217") });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("2353c39c-7ebf-40e7-a9a8-1b15f616b52c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("b345972e-61c4-451c-82e6-e26a48393ddf") });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Licences_LicenceId",
                table: "Sellers",
                column: "LicenceId",
                principalTable: "Licences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Locations_LocationId",
                table: "Sellers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
