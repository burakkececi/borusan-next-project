using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addadvertImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c4ce34d8-4ad1-4ed1-8f4c-b20968aee1fd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5ed5d6a8-2ef6-4d35-952f-198796a9a6cc"));

            migrationBuilder.DropColumn(
                name: "PublishedDate",
                table: "Adverts");

            migrationBuilder.RenameColumn(
                name: "Photos",
                table: "Adverts",
                newName: "FeaturedImageURL");

            migrationBuilder.CreateTable(
                name: "AdvertImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 204, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adverts.Admin", null },
                    { 205, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adverts.Read", null },
                    { 206, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adverts.Write", null },
                    { 207, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adverts.Create", null },
                    { 208, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adverts.Update", null },
                    { 209, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adverts.Delete", null },
                    { 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AdvertImages.Admin", null },
                    { 211, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AdvertImages.Read", null },
                    { 212, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AdvertImages.Write", null },
                    { 213, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AdvertImages.Create", null },
                    { 214, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AdvertImages.Update", null },
                    { 215, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AdvertImages.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("22546cfa-ebb3-4274-8a30-ad0e025c560c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 122, 186, 244, 117, 138, 157, 187, 91, 167, 190, 240, 93, 148, 7, 150, 169, 47, 212, 210, 50, 176, 251, 232, 79, 148, 33, 18, 82, 219, 21, 239, 239, 58, 175, 32, 13, 42, 168, 183, 205, 119, 164, 100, 28, 117, 92, 194, 36, 242, 161, 62, 220, 128, 138, 19, 99, 219, 144, 221, 230, 228, 244, 47, 3 }, new byte[] { 29, 181, 27, 93, 250, 127, 241, 10, 26, 124, 249, 54, 63, 32, 45, 247, 238, 39, 88, 145, 218, 180, 91, 237, 126, 42, 1, 89, 52, 47, 227, 251, 69, 179, 148, 105, 148, 163, 33, 133, 50, 133, 175, 193, 218, 123, 10, 94, 53, 91, 235, 234, 255, 69, 84, 54, 132, 223, 121, 214, 241, 181, 247, 78, 127, 21, 213, 180, 164, 240, 94, 75, 115, 186, 35, 196, 37, 39, 42, 22, 143, 249, 239, 140, 227, 140, 77, 250, 30, 36, 38, 157, 3, 130, 37, 47, 137, 161, 103, 237, 207, 186, 134, 185, 249, 112, 169, 57, 172, 144, 8, 215, 251, 228, 135, 200, 58, 7, 0, 52, 154, 87, 180, 17, 27, 35, 138, 82 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("6fefe86a-cd17-4b6c-84b0-9a1b0a242190"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("22546cfa-ebb3-4274-8a30-ad0e025c560c") });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertImages_AdvertId",
                table: "AdvertImages",
                column: "AdvertId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertImages");

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
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6fefe86a-cd17-4b6c-84b0-9a1b0a242190"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22546cfa-ebb3-4274-8a30-ad0e025c560c"));

            migrationBuilder.RenameColumn(
                name: "FeaturedImageURL",
                table: "Adverts",
                newName: "Photos");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedDate",
                table: "Adverts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("5ed5d6a8-2ef6-4d35-952f-198796a9a6cc"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 92, 66, 184, 228, 216, 32, 236, 112, 225, 134, 56, 177, 127, 11, 106, 224, 246, 96, 234, 50, 156, 53, 150, 77, 164, 223, 23, 150, 31, 145, 134, 175, 144, 63, 13, 215, 106, 17, 87, 233, 40, 145, 39, 204, 52, 176, 40, 34, 169, 247, 247, 4, 149, 24, 248, 26, 50, 56, 143, 79, 184, 230, 105, 157 }, new byte[] { 113, 152, 124, 254, 143, 16, 80, 120, 21, 78, 243, 114, 174, 6, 19, 6, 229, 228, 44, 25, 10, 250, 71, 144, 70, 0, 189, 151, 32, 125, 105, 155, 217, 48, 235, 194, 215, 134, 3, 79, 56, 191, 62, 244, 203, 217, 131, 157, 72, 244, 186, 113, 182, 214, 192, 77, 30, 176, 68, 54, 160, 18, 102, 147, 199, 9, 108, 109, 15, 42, 187, 215, 81, 198, 112, 150, 182, 192, 232, 251, 43, 239, 128, 247, 98, 154, 176, 163, 197, 38, 221, 92, 111, 248, 104, 163, 71, 83, 190, 83, 120, 42, 154, 123, 231, 158, 140, 33, 81, 8, 45, 124, 77, 204, 104, 183, 190, 71, 54, 174, 116, 1, 157, 139, 210, 208, 8, 179 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("c4ce34d8-4ad1-4ed1-8f4c-b20968aee1fd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("5ed5d6a8-2ef6-4d35-952f-198796a9a6cc") });
        }
    }
}
