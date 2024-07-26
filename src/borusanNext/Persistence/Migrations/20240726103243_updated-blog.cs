using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedblog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6fefe86a-cd17-4b6c-84b0-9a1b0a242190"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22546cfa-ebb3-4274-8a30-ad0e025c560c"));

            migrationBuilder.AddColumn<string>(
                name: "Banner",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 216, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blogs.Admin", null },
                    { 217, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blogs.Read", null },
                    { 218, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blogs.Write", null },
                    { 219, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blogs.Create", null },
                    { 220, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blogs.Update", null },
                    { 221, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blogs.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("aec28949-414d-47a0-b3b5-13c6848de1e4"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 173, 140, 241, 91, 136, 3, 101, 145, 147, 233, 94, 233, 250, 57, 174, 226, 17, 191, 224, 153, 10, 8, 208, 224, 171, 9, 43, 22, 44, 31, 113, 80, 132, 0, 216, 225, 127, 75, 136, 225, 42, 133, 77, 181, 128, 105, 189, 252, 214, 230, 238, 208, 55, 198, 72, 253, 69, 11, 150, 113, 103, 159, 250, 65 }, new byte[] { 224, 217, 115, 253, 47, 218, 34, 99, 90, 175, 92, 197, 31, 67, 109, 138, 190, 173, 25, 75, 15, 183, 199, 65, 214, 105, 106, 223, 9, 99, 74, 3, 93, 97, 216, 111, 131, 142, 96, 159, 44, 13, 21, 24, 140, 161, 153, 121, 149, 140, 161, 134, 126, 128, 85, 89, 116, 52, 179, 84, 142, 72, 255, 221, 89, 131, 89, 66, 0, 108, 83, 14, 236, 149, 163, 175, 227, 113, 159, 74, 84, 104, 213, 188, 183, 48, 34, 242, 235, 255, 187, 33, 132, 203, 66, 87, 43, 34, 233, 151, 239, 151, 128, 102, 229, 186, 78, 176, 125, 67, 190, 40, 222, 62, 57, 104, 237, 72, 62, 249, 128, 81, 79, 200, 231, 57, 44, 186 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("3c131ffa-f05d-4c03-b25a-d937ca94c8a7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("aec28949-414d-47a0-b3b5-13c6848de1e4") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                keyValue: new Guid("3c131ffa-f05d-4c03-b25a-d937ca94c8a7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aec28949-414d-47a0-b3b5-13c6848de1e4"));

            migrationBuilder.DropColumn(
                name: "Banner",
                table: "Blogs");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("22546cfa-ebb3-4274-8a30-ad0e025c560c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 122, 186, 244, 117, 138, 157, 187, 91, 167, 190, 240, 93, 148, 7, 150, 169, 47, 212, 210, 50, 176, 251, 232, 79, 148, 33, 18, 82, 219, 21, 239, 239, 58, 175, 32, 13, 42, 168, 183, 205, 119, 164, 100, 28, 117, 92, 194, 36, 242, 161, 62, 220, 128, 138, 19, 99, 219, 144, 221, 230, 228, 244, 47, 3 }, new byte[] { 29, 181, 27, 93, 250, 127, 241, 10, 26, 124, 249, 54, 63, 32, 45, 247, 238, 39, 88, 145, 218, 180, 91, 237, 126, 42, 1, 89, 52, 47, 227, 251, 69, 179, 148, 105, 148, 163, 33, 133, 50, 133, 175, 193, 218, 123, 10, 94, 53, 91, 235, 234, 255, 69, 84, 54, 132, 223, 121, 214, 241, 181, 247, 78, 127, 21, 213, 180, 164, 240, 94, 75, 115, 186, 35, 196, 37, 39, 42, 22, 143, 249, 239, 140, 227, 140, 77, 250, 30, 36, 38, 157, 3, 130, 37, 47, 137, 161, 103, 237, 207, 186, 134, 185, 249, 112, 169, 57, 172, 144, 8, 215, 251, 228, 135, 200, 58, 7, 0, 52, 154, 87, 180, 17, 27, 35, 138, 82 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("6fefe86a-cd17-4b6c-84b0-9a1b0a242190"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("22546cfa-ebb3-4274-8a30-ad0e025c560c") });
        }
    }
}
