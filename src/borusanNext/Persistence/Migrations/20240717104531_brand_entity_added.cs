using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class brand_entity_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6cf530f2-cf6b-44b5-9e01-c30c712171ee"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1943a5ba-0cce-41bd-96e2-d894b2f92021"));

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("06f82cd6-f15a-4a38-b99d-80d1a4cb9b20"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 232, 187, 102, 215, 56, 98, 32, 244, 239, 5, 54, 96, 33, 248, 173, 210, 238, 195, 170, 13, 192, 2, 158, 88, 127, 40, 180, 74, 236, 109, 133, 68, 144, 54, 28, 62, 172, 194, 67, 143, 225, 65, 8, 214, 89, 38, 67, 128, 76, 118, 67, 174, 0, 213, 55, 216, 149, 130, 151, 215, 108, 30, 243, 158 }, new byte[] { 66, 157, 146, 145, 198, 251, 152, 140, 103, 232, 5, 161, 188, 208, 31, 219, 47, 208, 77, 51, 223, 243, 39, 169, 60, 255, 101, 98, 74, 184, 162, 98, 37, 146, 221, 46, 134, 13, 71, 245, 242, 78, 221, 7, 102, 112, 98, 105, 94, 20, 131, 241, 181, 194, 92, 18, 52, 59, 198, 89, 70, 75, 67, 100, 177, 197, 14, 102, 20, 43, 85, 64, 17, 240, 60, 206, 77, 160, 80, 166, 23, 79, 132, 144, 218, 236, 181, 94, 29, 183, 101, 8, 227, 199, 231, 153, 138, 63, 32, 155, 230, 21, 229, 210, 162, 89, 40, 252, 162, 85, 66, 155, 93, 165, 23, 108, 14, 2, 194, 249, 76, 94, 163, 210, 137, 32, 210, 49 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("bb95ff8d-1b9c-46b0-b47a-3b508875d2a9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("06f82cd6-f15a-4a38-b99d-80d1a4cb9b20") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("bb95ff8d-1b9c-46b0-b47a-3b508875d2a9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("06f82cd6-f15a-4a38-b99d-80d1a4cb9b20"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("1943a5ba-0cce-41bd-96e2-d894b2f92021"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 130, 229, 124, 175, 24, 133, 170, 118, 245, 72, 103, 139, 218, 86, 214, 196, 215, 102, 104, 89, 19, 197, 36, 164, 248, 196, 147, 209, 250, 208, 106, 47, 62, 36, 76, 142, 195, 34, 16, 71, 151, 147, 137, 141, 69, 103, 180, 51, 13, 210, 164, 216, 111, 69, 108, 24, 168, 129, 205, 40, 113, 119, 230, 182 }, new byte[] { 33, 66, 35, 187, 216, 58, 170, 84, 179, 31, 178, 161, 103, 246, 174, 199, 30, 136, 129, 121, 81, 251, 187, 179, 150, 57, 60, 196, 159, 210, 41, 7, 80, 88, 102, 107, 100, 214, 252, 103, 112, 61, 85, 48, 194, 37, 190, 137, 60, 189, 247, 171, 35, 185, 151, 119, 215, 181, 65, 69, 206, 133, 198, 160, 239, 178, 76, 250, 70, 7, 23, 154, 94, 179, 151, 224, 238, 113, 23, 67, 248, 9, 144, 193, 50, 129, 167, 250, 110, 132, 255, 121, 230, 11, 91, 53, 50, 32, 199, 134, 187, 14, 223, 231, 136, 233, 76, 50, 75, 250, 76, 18, 33, 216, 207, 136, 203, 1, 156, 25, 231, 164, 173, 53, 123, 10, 24, 9 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("6cf530f2-cf6b-44b5-9e01-c30c712171ee"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("1943a5ba-0cce-41bd-96e2-d894b2f92021") });
        }
    }
}
