using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedgenerationImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3c131ffa-f05d-4c03-b25a-d937ca94c8a7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aec28949-414d-47a0-b3b5-13c6848de1e4"));

            migrationBuilder.CreateTable(
                name: "GenerationImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenerationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 222, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GenerationImages.Admin", null },
                    { 223, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GenerationImages.Read", null },
                    { 224, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GenerationImages.Write", null },
                    { 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GenerationImages.Create", null },
                    { 226, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GenerationImages.Update", null },
                    { 227, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "GenerationImages.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("d6ba2834-2bc7-46b0-84bf-6c980dad3946"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 167, 46, 108, 29, 197, 162, 75, 51, 147, 50, 83, 244, 62, 133, 7, 31, 175, 2, 177, 196, 199, 249, 158, 242, 4, 192, 177, 136, 169, 151, 118, 228, 205, 50, 239, 163, 22, 233, 222, 35, 211, 222, 196, 149, 63, 151, 128, 167, 227, 6, 196, 94, 180, 186, 197, 222, 8, 184, 159, 0, 143, 158, 219, 210 }, new byte[] { 136, 175, 40, 222, 178, 0, 57, 16, 164, 219, 27, 180, 146, 12, 134, 178, 98, 190, 245, 126, 128, 99, 176, 182, 185, 213, 171, 223, 134, 180, 205, 214, 49, 25, 66, 16, 33, 235, 102, 187, 231, 57, 154, 17, 69, 74, 78, 182, 18, 184, 38, 122, 17, 98, 19, 88, 204, 147, 235, 48, 217, 243, 180, 119, 221, 226, 167, 147, 59, 226, 232, 207, 228, 140, 1, 143, 65, 130, 192, 235, 151, 192, 59, 206, 243, 16, 134, 133, 111, 66, 17, 55, 82, 76, 220, 66, 37, 13, 51, 135, 130, 138, 89, 57, 24, 255, 79, 252, 223, 35, 45, 107, 82, 147, 57, 41, 71, 20, 187, 64, 138, 26, 34, 94, 8, 83, 16, 185 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d504d39c-de10-4d88-bbc5-bc4217f03b41"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("d6ba2834-2bc7-46b0-84bf-6c980dad3946") });

            migrationBuilder.CreateIndex(
                name: "IX_GenerationImages_GenerationId",
                table: "GenerationImages",
                column: "GenerationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenerationImages");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d504d39c-de10-4d88-bbc5-bc4217f03b41"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d6ba2834-2bc7-46b0-84bf-6c980dad3946"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("aec28949-414d-47a0-b3b5-13c6848de1e4"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 173, 140, 241, 91, 136, 3, 101, 145, 147, 233, 94, 233, 250, 57, 174, 226, 17, 191, 224, 153, 10, 8, 208, 224, 171, 9, 43, 22, 44, 31, 113, 80, 132, 0, 216, 225, 127, 75, 136, 225, 42, 133, 77, 181, 128, 105, 189, 252, 214, 230, 238, 208, 55, 198, 72, 253, 69, 11, 150, 113, 103, 159, 250, 65 }, new byte[] { 224, 217, 115, 253, 47, 218, 34, 99, 90, 175, 92, 197, 31, 67, 109, 138, 190, 173, 25, 75, 15, 183, 199, 65, 214, 105, 106, 223, 9, 99, 74, 3, 93, 97, 216, 111, 131, 142, 96, 159, 44, 13, 21, 24, 140, 161, 153, 121, 149, 140, 161, 134, 126, 128, 85, 89, 116, 52, 179, 84, 142, 72, 255, 221, 89, 131, 89, 66, 0, 108, 83, 14, 236, 149, 163, 175, 227, 113, 159, 74, 84, 104, 213, 188, 183, 48, 34, 242, 235, 255, 187, 33, 132, 203, 66, 87, 43, 34, 233, 151, 239, 151, 128, 102, 229, 186, 78, 176, 125, 67, 190, 40, 222, 62, 57, 104, 237, 72, 62, 249, 128, 81, 79, 200, 231, 57, 44, 186 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("3c131ffa-f05d-4c03-b25a-d937ca94c8a7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("aec28949-414d-47a0-b3b5-13c6848de1e4") });
        }
    }
}
