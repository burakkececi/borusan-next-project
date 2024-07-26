using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class added_car_favorite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3677f4d8-3a5e-478c-82b1-a5da0ac29163"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("80fc3ceb-65f4-446c-b48e-82c7a8e016c4"));

            migrationBuilder.CreateTable(
                name: "CustomerFavorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 216, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Admin", null },
                    { 217, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Read", null },
                    { 218, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Write", null },
                    { 219, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Create", null },
                    { 220, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Update", null },
                    { 221, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CustomerFavorites.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("ee03510b-a86d-42b8-9dfb-f24142ebd2c3"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 47, 87, 141, 63, 133, 66, 37, 148, 53, 233, 7, 207, 205, 5, 55, 95, 239, 5, 195, 56, 89, 81, 47, 19, 125, 100, 89, 107, 180, 9, 162, 59, 128, 165, 114, 70, 249, 227, 245, 207, 185, 62, 136, 218, 34, 168, 212, 161, 141, 55, 140, 214, 35, 135, 183, 156, 101, 150, 246, 125, 224, 118, 157, 26 }, new byte[] { 121, 26, 75, 246, 104, 126, 6, 152, 73, 197, 204, 13, 139, 33, 80, 57, 88, 231, 17, 142, 91, 216, 218, 223, 176, 251, 161, 242, 45, 199, 78, 21, 12, 162, 77, 242, 133, 193, 23, 249, 74, 252, 82, 191, 218, 162, 172, 160, 44, 205, 78, 71, 25, 96, 112, 225, 71, 243, 64, 172, 140, 107, 19, 51, 4, 166, 25, 79, 33, 132, 236, 149, 71, 11, 157, 211, 66, 3, 243, 155, 155, 198, 113, 252, 161, 59, 171, 132, 221, 226, 249, 242, 15, 87, 42, 235, 115, 16, 24, 98, 218, 110, 212, 217, 198, 167, 103, 119, 253, 232, 208, 245, 88, 161, 13, 68, 152, 33, 243, 197, 72, 117, 250, 163, 244, 56, 83, 138 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("1bbce3da-fdfe-4ae6-a3a7-71d217344ff0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("ee03510b-a86d-42b8-9dfb-f24142ebd2c3") });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFavorites_AdvertId",
                table: "CustomerFavorites",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFavorites_CustomerId",
                table: "CustomerFavorites",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerFavorites");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1bbce3da-fdfe-4ae6-a3a7-71d217344ff0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ee03510b-a86d-42b8-9dfb-f24142ebd2c3"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("80fc3ceb-65f4-446c-b48e-82c7a8e016c4"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 27, 118, 45, 36, 1, 254, 12, 77, 1, 138, 184, 53, 224, 212, 221, 162, 13, 124, 194, 215, 62, 4, 33, 174, 182, 199, 139, 213, 174, 248, 151, 74, 54, 46, 18, 32, 241, 190, 99, 219, 96, 0, 13, 25, 14, 113, 255, 126, 43, 97, 8, 41, 249, 180, 208, 53, 164, 131, 222, 240, 212, 133, 114, 178 }, new byte[] { 24, 59, 19, 95, 136, 1, 178, 3, 210, 10, 14, 177, 99, 171, 247, 187, 28, 21, 33, 49, 103, 158, 81, 219, 55, 42, 17, 254, 204, 134, 247, 178, 212, 235, 106, 92, 27, 77, 209, 239, 5, 35, 2, 178, 181, 176, 91, 38, 53, 179, 12, 227, 197, 204, 190, 203, 180, 6, 109, 220, 47, 85, 30, 168, 253, 111, 134, 211, 117, 118, 45, 231, 185, 154, 177, 239, 252, 159, 6, 33, 210, 250, 78, 92, 186, 115, 178, 224, 119, 163, 135, 175, 15, 44, 38, 214, 226, 104, 31, 79, 127, 103, 98, 99, 247, 54, 178, 191, 160, 152, 254, 240, 41, 83, 164, 177, 33, 106, 195, 131, 176, 191, 235, 107, 42, 196, 150, 77 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("3677f4d8-3a5e-478c-82b1-a5da0ac29163"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("80fc3ceb-65f4-446c-b48e-82c7a8e016c4") });
        }
    }
}
