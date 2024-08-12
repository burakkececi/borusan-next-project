using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class view_advert_details : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                        CREATE VIEW vm_AdvertDetails AS
                        SELECT 
                                a.""Id"" AS ""AdvertId"",
                                a.""AdvertNo"" AS ""AdvertNo"",
                                c.""Id"" AS ""CarId"",
                                c.""ChassisNumber"" AS ""ChassisNumber"",
                                c.""Plate"" AS ""Plate"",
                                c.""Kilometers"" AS ""Kilometers"",
                                c.""SpareKey"" AS ""SpareKey"",
                                c.""Inquiry"" AS ""Inquiry"",
                                c.""WheelType"" AS ""WheelType"",
                                c.""SpareWheel"" AS ""SpareWheel"",
                                c.""Price"" AS ""Price"",
                                me.""Id"" AS ""ModalExtensionId"",
                                me.""Name"" AS ""ModalExtension_Name"",
                                me.""Lenght"" AS ""ModalExtension_Length"",
                                me.""Width"" AS ""ModalExtension_Width"",
                                me.""Height"" AS ""ModalExtension_Height"",
                                me.""FuelTank"" AS ""ModalExtension_FuelTank"",
                                me.""LuggageCapacity"" AS ""ModalExtension_LuggageCapacity"",
                                me.""EmptyWeight"" AS ""ModalExtension_EmptyWeight"",
                                me.""ModelYear"" AS ""ModalExtension_ModelYear"",
                                cm.""Id"" AS ""CarModelId"",
                                cm.""ModelName"" AS ""CarModel_Name"",
                                b.""Id"" AS ""BrandId"",
                                b.""Name"" AS ""Brand_Name"",
                                b.""Logo"" AS ""Brand_Logo"",
                                g.""Id"" AS ""GenerationId"",
                                g.""Name"" AS ""Generation_Name"",
                                e.""Id"" AS ""EngineId"",
                                e.""EngineNo"" AS ""Engine_EngineNo"",
                                e.""EngineCapacity"" AS ""Engine_EngineCapacity"",
                                e.""MotorPower"" AS ""Engine_MotorPower"",
                                e.""MaximumTorque"" AS ""Engine_MaximumTorque"",
                                e.""Acceleration"" AS ""Engine_Acceleration"",
                                e.""MaximumSpeed"" AS ""Engine_MaximumSpeed"",
                                e.""FuelTankVolume"" AS ""Engine_FuelTankVolume"",
                                e.""OutOfTownConsumptionRate"" AS ""Engine_OutOfTownConsumptionRate"",
                                e.""UrbanConsumptionRate"" AS ""Engine_UrbanConsumptionRate"",
                                e.""AverageConsumptionRate"" AS ""Engine_AverageConsumptionRate"",
                                ft.""Id"" AS ""FuelTypeId"",
                                ft.""Name"" AS ""FuelType_Name"",
                                col.""Id"" AS ""ColorId"",
                                col.""Name"" AS ""Color_Name"",
                                bt.""Id"" AS ""BodyTypeId"",
                                bt.""BodyName"" AS ""BodyType_Name"",
                                bt.""Door"" AS ""BodyType_Door"",
                                tr.""Id"" AS ""TransmissionId"",
                                tr.""Name"" AS ""Transmission_Name"",
                                er.""Id"" AS ""TramerId"",
                                er.""CarDamageInformationRecord"" AS ""CarDamageInformationRecord"",
                                er.""InquiryDate"" AS ""InquiryDate"",
                                cp.""Id"" AS ""ChassisPartId"",
                                cp.""IsRightChassisChanged"" AS ""ChassisPart_IsRightChassisChanged"",
                                cp.""IsLeftChassisChanged"" AS ""ChassisPart_IsLeftChassisChanged"",
                                cp.""IsFrontPanelChanged"" AS ""ChassisPart_IsFrontPanelChanged"",
                                cp.""IsBackPanelChanged"" AS ""ChassisPart_IsBackPanelChanged"",
                                bp.""Id"" AS ""BodyShellPartId"",
                                bp.""LeftFrontFender"" AS ""BodyShellPart_LeftFrontFender"",
                                bp.""LeftFrontDoor"" AS ""BodyShellPart_LeftFrontDoor"",
                                bp.""LeftRearDoor"" AS ""BodyShellPart_LeftRearDoor"",
                                bp.""LeftRearFender"" AS ""BodyShellPart_LeftRearFender"",
                                bp.""RightFrontFender"" AS ""BodyShellPart_RightFrontFender"",
                                bp.""RightFrontDoor"" AS ""BodyShellPart_RightFrontDoor"",
                                bp.""RightRearDoor"" AS ""BodyShellPart_RightRearDoor"",
                                bp.""RightRearFender"" AS ""BodyShellPart_RightRearFender"",
                                bp.""Frontbumper"" AS ""BodyShellPart_FrontBumper"",
                                bp.""RearBumper"" AS ""BodyShellPart_RearBumper"",
                                bp.""Bonnet"" AS ""BodyShellPart_Bonnet"",
                                bp.""Ceiling"" AS ""BodyShellPart_Ceiling"",
                                bp.""Luggage"" AS ""BodyShellPart_Luggage"",
                                s.""Id"" AS ""SellerId"",
                                s.""Name"" AS ""Seller_Name"",
                                s.""PhoneNumber"" AS ""Seller_PhoneNumber"",
                                l.""Id"" AS ""LicenceId"",
                                l.""LicenceNo"" AS ""Licence_LicenceNo"",
                                l.""ProvidedBy"" AS ""Licence_ProvidedBy"",
                                loc.""Id"" AS ""LocationId"",
                                loc.""City"" AS ""Location_City"",
                                loc.""Address"" AS ""Location_Address"",
                                loc.""Latitute"" AS ""Location_Latitute"",
                                loc.""Longitute"" AS ""Location_Longitute""
                                FROM ""Adverts"" a
                                JOIN ""Cars"" c ON a.""CarId"" = c.""Id""
                                LEFT JOIN ""ModalExtensions"" me ON c.""ModalExtensionId"" = me.""Id""
                                LEFT JOIN ""CarModels"" cm ON me.""CarModelId"" = cm.""Id""
                                LEFT JOIN ""Brands"" b ON cm.""BrandId"" = b.""Id""
                                LEFT JOIN ""Generations"" g ON me.""GenerationId"" = g.""Id""
                                LEFT JOIN ""Engines"" e ON c.""EngineId"" = e.""Id""
                                LEFT JOIN ""FuelTypes"" ft ON e.""FuelTypeId"" = ft.""Id""
                                LEFT JOIN ""CarColors"" col ON c.""ColorId"" = col.""Id""
                                LEFT JOIN ""BodyTypes"" bt ON c.""BodyTypeId"" = bt.""Id""
                                LEFT JOIN ""Transmissions"" tr ON c.""TransmissionId"" = tr.""Id""
                                LEFT JOIN ""ExpertizeResults"" er ON c.""TramerId"" = er.""Id""
                                LEFT JOIN ""ChassisParts"" cp ON er.""ChassisPartId"" = cp.""Id""
                                LEFT JOIN ""BodyShellParts"" bp ON er.""BodyShellPartId"" = bp.""Id""
                                LEFT JOIN ""Sellers"" s ON c.""SellerId"" = s.""Id""
                                LEFT JOIN ""Licences"" l ON s.""LicenceId"" = l.""Id""
                                LEFT JOIN ""Locations"" loc ON s.""LocationId"" = loc.""Id"";
                        ");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d4611002-39eb-4493-9483-5555f84f711e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e4cd1e5f-37b6-474d-88ba-cf6dfdca9207"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36160d4c-8a2a-4959-9769-ebf2bd812237"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 136, 91, 54, 32, 35, 31, 112, 187, 53, 76, 252, 230, 18, 141, 72, 182, 124, 48, 94, 91, 227, 248, 114, 130, 67, 208, 109, 56, 63, 237, 186, 57, 236, 63, 80, 85, 129, 247, 139, 131, 221, 6, 77, 108, 175, 118, 104, 76, 43, 4, 142, 90, 24, 106, 237, 94, 160, 15, 72, 38, 86, 121, 184, 173 }, new byte[] { 233, 210, 209, 205, 28, 172, 104, 217, 110, 193, 137, 163, 31, 120, 3, 246, 98, 10, 80, 196, 198, 50, 14, 117, 74, 54, 98, 32, 123, 89, 112, 32, 42, 5, 234, 99, 92, 113, 189, 141, 177, 14, 144, 195, 59, 247, 194, 186, 85, 159, 70, 241, 94, 3, 118, 233, 59, 229, 227, 76, 108, 211, 152, 137, 237, 67, 192, 252, 72, 208, 177, 215, 32, 16, 79, 212, 210, 5, 4, 249, 120, 117, 189, 123, 1, 108, 114, 119, 45, 139, 215, 74, 173, 154, 5, 197, 5, 11, 203, 13, 139, 185, 69, 126, 109, 61, 233, 170, 90, 252, 221, 0, 208, 206, 70, 48, 31, 101, 107, 59, 160, 188, 223, 198, 58, 144, 226, 152 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("398b5d31-f2e2-473f-8f40-78f7e79af217"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 136, 91, 54, 32, 35, 31, 112, 187, 53, 76, 252, 230, 18, 141, 72, 182, 124, 48, 94, 91, 227, 248, 114, 130, 67, 208, 109, 56, 63, 237, 186, 57, 236, 63, 80, 85, 129, 247, 139, 131, 221, 6, 77, 108, 175, 118, 104, 76, 43, 4, 142, 90, 24, 106, 237, 94, 160, 15, 72, 38, 86, 121, 184, 173 }, new byte[] { 233, 210, 209, 205, 28, 172, 104, 217, 110, 193, 137, 163, 31, 120, 3, 246, 98, 10, 80, 196, 198, 50, 14, 117, 74, 54, 98, 32, 123, 89, 112, 32, 42, 5, 234, 99, 92, 113, 189, 141, 177, 14, 144, 195, 59, 247, 194, 186, 85, 159, 70, 241, 94, 3, 118, 233, 59, 229, 227, 76, 108, 211, 152, 137, 237, 67, 192, 252, 72, 208, 177, 215, 32, 16, 79, 212, 210, 5, 4, 249, 120, 117, 189, 123, 1, 108, 114, 119, 45, 139, 215, 74, 173, 154, 5, 197, 5, 11, 203, 13, 139, 185, 69, 126, 109, 61, 233, 170, 90, 252, 221, 0, 208, 206, 70, 48, 31, 101, 107, 59, 160, 188, 223, 198, 58, 144, 226, 152 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6444d306-ab8e-4e84-a6ff-77037d68fd2e"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 136, 91, 54, 32, 35, 31, 112, 187, 53, 76, 252, 230, 18, 141, 72, 182, 124, 48, 94, 91, 227, 248, 114, 130, 67, 208, 109, 56, 63, 237, 186, 57, 236, 63, 80, 85, 129, 247, 139, 131, 221, 6, 77, 108, 175, 118, 104, 76, 43, 4, 142, 90, 24, 106, 237, 94, 160, 15, 72, 38, 86, 121, 184, 173 }, new byte[] { 233, 210, 209, 205, 28, 172, 104, 217, 110, 193, 137, 163, 31, 120, 3, 246, 98, 10, 80, 196, 198, 50, 14, 117, 74, 54, 98, 32, 123, 89, 112, 32, 42, 5, 234, 99, 92, 113, 189, 141, 177, 14, 144, 195, 59, 247, 194, 186, 85, 159, 70, 241, 94, 3, 118, 233, 59, 229, 227, 76, 108, 211, 152, 137, 237, 67, 192, 252, 72, 208, 177, 215, 32, 16, 79, 212, 210, 5, 4, 249, 120, 117, 189, 123, 1, 108, 114, 119, 45, 139, 215, 74, 173, 154, 5, 197, 5, 11, 203, 13, 139, 185, 69, 126, 109, 61, 233, 170, 90, 252, 221, 0, 208, 206, 70, 48, 31, 101, 107, 59, 160, 188, 223, 198, 58, 144, 226, 152 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd8e0f-59d4-4532-ae32-03cec3e39158"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 136, 91, 54, 32, 35, 31, 112, 187, 53, 76, 252, 230, 18, 141, 72, 182, 124, 48, 94, 91, 227, 248, 114, 130, 67, 208, 109, 56, 63, 237, 186, 57, 236, 63, 80, 85, 129, 247, 139, 131, 221, 6, 77, 108, 175, 118, 104, 76, 43, 4, 142, 90, 24, 106, 237, 94, 160, 15, 72, 38, 86, 121, 184, 173 }, new byte[] { 233, 210, 209, 205, 28, 172, 104, 217, 110, 193, 137, 163, 31, 120, 3, 246, 98, 10, 80, 196, 198, 50, 14, 117, 74, 54, 98, 32, 123, 89, 112, 32, 42, 5, 234, 99, 92, 113, 189, 141, 177, 14, 144, 195, 59, 247, 194, 186, 85, 159, 70, 241, 94, 3, 118, 233, 59, 229, 227, 76, 108, 211, 152, 137, 237, 67, 192, 252, 72, 208, 177, 215, 32, 16, 79, 212, 210, 5, 4, 249, 120, 117, 189, 123, 1, 108, 114, 119, 45, 139, 215, 74, 173, 154, 5, 197, 5, 11, 203, 13, 139, 185, 69, 126, 109, 61, 233, 170, 90, 252, 221, 0, 208, 206, 70, 48, 31, 101, 107, 59, 160, 188, 223, 198, 58, 144, 226, 152 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ada31c5d-6014-46d2-a1c3-ed8007e898cf"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 136, 91, 54, 32, 35, 31, 112, 187, 53, 76, 252, 230, 18, 141, 72, 182, 124, 48, 94, 91, 227, 248, 114, 130, 67, 208, 109, 56, 63, 237, 186, 57, 236, 63, 80, 85, 129, 247, 139, 131, 221, 6, 77, 108, 175, 118, 104, 76, 43, 4, 142, 90, 24, 106, 237, 94, 160, 15, 72, 38, 86, 121, 184, 173 }, new byte[] { 233, 210, 209, 205, 28, 172, 104, 217, 110, 193, 137, 163, 31, 120, 3, 246, 98, 10, 80, 196, 198, 50, 14, 117, 74, 54, 98, 32, 123, 89, 112, 32, 42, 5, 234, 99, 92, 113, 189, 141, 177, 14, 144, 195, 59, 247, 194, 186, 85, 159, 70, 241, 94, 3, 118, 233, 59, 229, 227, 76, 108, 211, 152, 137, 237, 67, 192, 252, 72, 208, 177, 215, 32, 16, 79, 212, 210, 5, 4, 249, 120, 117, 189, 123, 1, 108, 114, 119, 45, 139, 215, 74, 173, 154, 5, 197, 5, 11, 203, 13, 139, 185, 69, 126, 109, 61, 233, 170, 90, 252, 221, 0, 208, 206, 70, 48, 31, 101, 107, 59, 160, 188, 223, 198, 58, 144, 226, 152 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b73f6541-460e-4d9d-97eb-1402f63df038"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 136, 91, 54, 32, 35, 31, 112, 187, 53, 76, 252, 230, 18, 141, 72, 182, 124, 48, 94, 91, 227, 248, 114, 130, 67, 208, 109, 56, 63, 237, 186, 57, 236, 63, 80, 85, 129, 247, 139, 131, 221, 6, 77, 108, 175, 118, 104, 76, 43, 4, 142, 90, 24, 106, 237, 94, 160, 15, 72, 38, 86, 121, 184, 173 }, new byte[] { 233, 210, 209, 205, 28, 172, 104, 217, 110, 193, 137, 163, 31, 120, 3, 246, 98, 10, 80, 196, 198, 50, 14, 117, 74, 54, 98, 32, 123, 89, 112, 32, 42, 5, 234, 99, 92, 113, 189, 141, 177, 14, 144, 195, 59, 247, 194, 186, 85, 159, 70, 241, 94, 3, 118, 233, 59, 229, 227, 76, 108, 211, 152, 137, 237, 67, 192, 252, 72, 208, 177, 215, 32, 16, 79, 212, 210, 5, 4, 249, 120, 117, 189, 123, 1, 108, 114, 119, 45, 139, 215, 74, 173, 154, 5, 197, 5, 11, 203, 13, 139, 185, 69, 126, 109, 61, 233, 170, 90, 252, 221, 0, 208, 206, 70, 48, 31, 101, 107, 59, 160, 188, 223, 198, 58, 144, 226, 152 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd4dd3dc-72e4-42cb-bde3-0fcb1867b10d"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 136, 91, 54, 32, 35, 31, 112, 187, 53, 76, 252, 230, 18, 141, 72, 182, 124, 48, 94, 91, 227, 248, 114, 130, 67, 208, 109, 56, 63, 237, 186, 57, 236, 63, 80, 85, 129, 247, 139, 131, 221, 6, 77, 108, 175, 118, 104, 76, 43, 4, 142, 90, 24, 106, 237, 94, 160, 15, 72, 38, 86, 121, 184, 173 }, new byte[] { 233, 210, 209, 205, 28, 172, 104, 217, 110, 193, 137, 163, 31, 120, 3, 246, 98, 10, 80, 196, 198, 50, 14, 117, 74, 54, 98, 32, 123, 89, 112, 32, 42, 5, 234, 99, 92, 113, 189, 141, 177, 14, 144, 195, 59, 247, 194, 186, 85, 159, 70, 241, 94, 3, 118, 233, 59, 229, 227, 76, 108, 211, 152, 137, 237, 67, 192, 252, 72, 208, 177, 215, 32, 16, 79, 212, 210, 5, 4, 249, 120, 117, 189, 123, 1, 108, 114, 119, 45, 139, 215, 74, 173, 154, 5, 197, 5, 11, 203, 13, 139, 185, 69, 126, 109, 61, 233, 170, 90, 252, 221, 0, 208, 206, 70, 48, 31, 101, 107, 59, 160, 188, 223, 198, 58, 144, 226, 152 } });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("b479b187-e82d-4de9-b59f-10ee57e6bdcb"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@borusan.com", new byte[] { 136, 91, 54, 32, 35, 31, 112, 187, 53, 76, 252, 230, 18, 141, 72, 182, 124, 48, 94, 91, 227, 248, 114, 130, 67, 208, 109, 56, 63, 237, 186, 57, 236, 63, 80, 85, 129, 247, 139, 131, 221, 6, 77, 108, 175, 118, 104, 76, 43, 4, 142, 90, 24, 106, 237, 94, 160, 15, 72, 38, 86, 121, 184, 173 }, new byte[] { 233, 210, 209, 205, 28, 172, 104, 217, 110, 193, 137, 163, 31, 120, 3, 246, 98, 10, 80, 196, 198, 50, 14, 117, 74, 54, 98, 32, 123, 89, 112, 32, 42, 5, 234, 99, 92, 113, 189, 141, 177, 14, 144, 195, 59, 247, 194, 186, 85, 159, 70, 241, 94, 3, 118, 233, 59, 229, 227, 76, 108, 211, 152, 137, 237, 67, 192, 252, 72, 208, 177, 215, 32, 16, 79, 212, 210, 5, 4, 249, 120, 117, 189, 123, 1, 108, 114, 119, 45, 139, 215, 74, 173, 154, 5, 197, 5, 11, 203, 13, 139, 185, 69, 126, 109, 61, 233, 170, 90, 252, 221, 0, 208, 206, 70, 48, 31, 101, 107, 59, 160, 188, 223, 198, 58, 144, 226, 152 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("74a61f05-cd81-423f-a84b-9c5006587340"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("b479b187-e82d-4de9-b59f-10ee57e6bdcb") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS vm_AdvertDetails;");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("74a61f05-cd81-423f-a84b-9c5006587340"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b479b187-e82d-4de9-b59f-10ee57e6bdcb"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36160d4c-8a2a-4959-9769-ebf2bd812237"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 121, 11, 38, 238, 177, 129, 113, 132, 120, 242, 149, 237, 244, 128, 33, 234, 208, 128, 55, 75, 158, 137, 146, 179, 36, 39, 129, 37, 240, 44, 157, 44, 87, 20, 119, 210, 165, 166, 119, 198, 243, 81, 98, 219, 147, 128, 59, 119, 199, 141, 95, 150, 151, 35, 237, 69, 217, 37, 90, 246, 13, 16, 0, 236 }, new byte[] { 129, 213, 139, 19, 223, 148, 207, 23, 29, 119, 174, 93, 88, 180, 169, 136, 24, 77, 27, 2, 97, 230, 47, 250, 175, 133, 253, 77, 71, 131, 181, 247, 11, 132, 56, 108, 150, 42, 70, 95, 232, 28, 83, 109, 125, 184, 134, 72, 136, 114, 69, 189, 10, 157, 81, 24, 249, 248, 110, 127, 138, 205, 236, 17, 113, 171, 10, 87, 155, 145, 176, 213, 162, 236, 72, 194, 217, 174, 114, 181, 227, 79, 237, 200, 27, 21, 198, 248, 179, 207, 100, 227, 181, 185, 87, 179, 38, 41, 151, 243, 182, 232, 181, 129, 215, 126, 218, 147, 113, 71, 86, 239, 99, 24, 43, 31, 16, 120, 197, 133, 146, 193, 22, 213, 49, 170, 228, 159 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("398b5d31-f2e2-473f-8f40-78f7e79af217"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 121, 11, 38, 238, 177, 129, 113, 132, 120, 242, 149, 237, 244, 128, 33, 234, 208, 128, 55, 75, 158, 137, 146, 179, 36, 39, 129, 37, 240, 44, 157, 44, 87, 20, 119, 210, 165, 166, 119, 198, 243, 81, 98, 219, 147, 128, 59, 119, 199, 141, 95, 150, 151, 35, 237, 69, 217, 37, 90, 246, 13, 16, 0, 236 }, new byte[] { 129, 213, 139, 19, 223, 148, 207, 23, 29, 119, 174, 93, 88, 180, 169, 136, 24, 77, 27, 2, 97, 230, 47, 250, 175, 133, 253, 77, 71, 131, 181, 247, 11, 132, 56, 108, 150, 42, 70, 95, 232, 28, 83, 109, 125, 184, 134, 72, 136, 114, 69, 189, 10, 157, 81, 24, 249, 248, 110, 127, 138, 205, 236, 17, 113, 171, 10, 87, 155, 145, 176, 213, 162, 236, 72, 194, 217, 174, 114, 181, 227, 79, 237, 200, 27, 21, 198, 248, 179, 207, 100, 227, 181, 185, 87, 179, 38, 41, 151, 243, 182, 232, 181, 129, 215, 126, 218, 147, 113, 71, 86, 239, 99, 24, 43, 31, 16, 120, 197, 133, 146, 193, 22, 213, 49, 170, 228, 159 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6444d306-ab8e-4e84-a6ff-77037d68fd2e"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 121, 11, 38, 238, 177, 129, 113, 132, 120, 242, 149, 237, 244, 128, 33, 234, 208, 128, 55, 75, 158, 137, 146, 179, 36, 39, 129, 37, 240, 44, 157, 44, 87, 20, 119, 210, 165, 166, 119, 198, 243, 81, 98, 219, 147, 128, 59, 119, 199, 141, 95, 150, 151, 35, 237, 69, 217, 37, 90, 246, 13, 16, 0, 236 }, new byte[] { 129, 213, 139, 19, 223, 148, 207, 23, 29, 119, 174, 93, 88, 180, 169, 136, 24, 77, 27, 2, 97, 230, 47, 250, 175, 133, 253, 77, 71, 131, 181, 247, 11, 132, 56, 108, 150, 42, 70, 95, 232, 28, 83, 109, 125, 184, 134, 72, 136, 114, 69, 189, 10, 157, 81, 24, 249, 248, 110, 127, 138, 205, 236, 17, 113, 171, 10, 87, 155, 145, 176, 213, 162, 236, 72, 194, 217, 174, 114, 181, 227, 79, 237, 200, 27, 21, 198, 248, 179, 207, 100, 227, 181, 185, 87, 179, 38, 41, 151, 243, 182, 232, 181, 129, 215, 126, 218, 147, 113, 71, 86, 239, 99, 24, 43, 31, 16, 120, 197, 133, 146, 193, 22, 213, 49, 170, 228, 159 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd8e0f-59d4-4532-ae32-03cec3e39158"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 121, 11, 38, 238, 177, 129, 113, 132, 120, 242, 149, 237, 244, 128, 33, 234, 208, 128, 55, 75, 158, 137, 146, 179, 36, 39, 129, 37, 240, 44, 157, 44, 87, 20, 119, 210, 165, 166, 119, 198, 243, 81, 98, 219, 147, 128, 59, 119, 199, 141, 95, 150, 151, 35, 237, 69, 217, 37, 90, 246, 13, 16, 0, 236 }, new byte[] { 129, 213, 139, 19, 223, 148, 207, 23, 29, 119, 174, 93, 88, 180, 169, 136, 24, 77, 27, 2, 97, 230, 47, 250, 175, 133, 253, 77, 71, 131, 181, 247, 11, 132, 56, 108, 150, 42, 70, 95, 232, 28, 83, 109, 125, 184, 134, 72, 136, 114, 69, 189, 10, 157, 81, 24, 249, 248, 110, 127, 138, 205, 236, 17, 113, 171, 10, 87, 155, 145, 176, 213, 162, 236, 72, 194, 217, 174, 114, 181, 227, 79, 237, 200, 27, 21, 198, 248, 179, 207, 100, 227, 181, 185, 87, 179, 38, 41, 151, 243, 182, 232, 181, 129, 215, 126, 218, 147, 113, 71, 86, 239, 99, 24, 43, 31, 16, 120, 197, 133, 146, 193, 22, 213, 49, 170, 228, 159 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ada31c5d-6014-46d2-a1c3-ed8007e898cf"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 121, 11, 38, 238, 177, 129, 113, 132, 120, 242, 149, 237, 244, 128, 33, 234, 208, 128, 55, 75, 158, 137, 146, 179, 36, 39, 129, 37, 240, 44, 157, 44, 87, 20, 119, 210, 165, 166, 119, 198, 243, 81, 98, 219, 147, 128, 59, 119, 199, 141, 95, 150, 151, 35, 237, 69, 217, 37, 90, 246, 13, 16, 0, 236 }, new byte[] { 129, 213, 139, 19, 223, 148, 207, 23, 29, 119, 174, 93, 88, 180, 169, 136, 24, 77, 27, 2, 97, 230, 47, 250, 175, 133, 253, 77, 71, 131, 181, 247, 11, 132, 56, 108, 150, 42, 70, 95, 232, 28, 83, 109, 125, 184, 134, 72, 136, 114, 69, 189, 10, 157, 81, 24, 249, 248, 110, 127, 138, 205, 236, 17, 113, 171, 10, 87, 155, 145, 176, 213, 162, 236, 72, 194, 217, 174, 114, 181, 227, 79, 237, 200, 27, 21, 198, 248, 179, 207, 100, 227, 181, 185, 87, 179, 38, 41, 151, 243, 182, 232, 181, 129, 215, 126, 218, 147, 113, 71, 86, 239, 99, 24, 43, 31, 16, 120, 197, 133, 146, 193, 22, 213, 49, 170, 228, 159 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b73f6541-460e-4d9d-97eb-1402f63df038"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 121, 11, 38, 238, 177, 129, 113, 132, 120, 242, 149, 237, 244, 128, 33, 234, 208, 128, 55, 75, 158, 137, 146, 179, 36, 39, 129, 37, 240, 44, 157, 44, 87, 20, 119, 210, 165, 166, 119, 198, 243, 81, 98, 219, 147, 128, 59, 119, 199, 141, 95, 150, 151, 35, 237, 69, 217, 37, 90, 246, 13, 16, 0, 236 }, new byte[] { 129, 213, 139, 19, 223, 148, 207, 23, 29, 119, 174, 93, 88, 180, 169, 136, 24, 77, 27, 2, 97, 230, 47, 250, 175, 133, 253, 77, 71, 131, 181, 247, 11, 132, 56, 108, 150, 42, 70, 95, 232, 28, 83, 109, 125, 184, 134, 72, 136, 114, 69, 189, 10, 157, 81, 24, 249, 248, 110, 127, 138, 205, 236, 17, 113, 171, 10, 87, 155, 145, 176, 213, 162, 236, 72, 194, 217, 174, 114, 181, 227, 79, 237, 200, 27, 21, 198, 248, 179, 207, 100, 227, 181, 185, 87, 179, 38, 41, 151, 243, 182, 232, 181, 129, 215, 126, 218, 147, 113, 71, 86, 239, 99, 24, 43, 31, 16, 120, 197, 133, 146, 193, 22, 213, 49, 170, 228, 159 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd4dd3dc-72e4-42cb-bde3-0fcb1867b10d"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 121, 11, 38, 238, 177, 129, 113, 132, 120, 242, 149, 237, 244, 128, 33, 234, 208, 128, 55, 75, 158, 137, 146, 179, 36, 39, 129, 37, 240, 44, 157, 44, 87, 20, 119, 210, 165, 166, 119, 198, 243, 81, 98, 219, 147, 128, 59, 119, 199, 141, 95, 150, 151, 35, 237, 69, 217, 37, 90, 246, 13, 16, 0, 236 }, new byte[] { 129, 213, 139, 19, 223, 148, 207, 23, 29, 119, 174, 93, 88, 180, 169, 136, 24, 77, 27, 2, 97, 230, 47, 250, 175, 133, 253, 77, 71, 131, 181, 247, 11, 132, 56, 108, 150, 42, 70, 95, 232, 28, 83, 109, 125, 184, 134, 72, 136, 114, 69, 189, 10, 157, 81, 24, 249, 248, 110, 127, 138, 205, 236, 17, 113, 171, 10, 87, 155, 145, 176, 213, 162, 236, 72, 194, 217, 174, 114, 181, 227, 79, 237, 200, 27, 21, 198, 248, 179, 207, 100, 227, 181, 185, 87, 179, 38, 41, 151, 243, 182, 232, 181, 129, 215, 126, 218, 147, 113, 71, 86, 239, 99, 24, 43, 31, 16, 120, 197, 133, 146, 193, 22, 213, 49, 170, 228, 159 } });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("e4cd1e5f-37b6-474d-88ba-cf6dfdca9207"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@borusan.com", new byte[] { 121, 11, 38, 238, 177, 129, 113, 132, 120, 242, 149, 237, 244, 128, 33, 234, 208, 128, 55, 75, 158, 137, 146, 179, 36, 39, 129, 37, 240, 44, 157, 44, 87, 20, 119, 210, 165, 166, 119, 198, 243, 81, 98, 219, 147, 128, 59, 119, 199, 141, 95, 150, 151, 35, 237, 69, 217, 37, 90, 246, 13, 16, 0, 236 }, new byte[] { 129, 213, 139, 19, 223, 148, 207, 23, 29, 119, 174, 93, 88, 180, 169, 136, 24, 77, 27, 2, 97, 230, 47, 250, 175, 133, 253, 77, 71, 131, 181, 247, 11, 132, 56, 108, 150, 42, 70, 95, 232, 28, 83, 109, 125, 184, 134, 72, 136, 114, 69, 189, 10, 157, 81, 24, 249, 248, 110, 127, 138, 205, 236, 17, 113, 171, 10, 87, 155, 145, 176, 213, 162, 236, 72, 194, 217, 174, 114, 181, 227, 79, 237, 200, 27, 21, 198, 248, 179, 207, 100, 227, 181, 185, 87, 179, 38, 41, 151, 243, 182, 232, 181, 129, 215, 126, 218, 147, 113, 71, 86, 239, 99, 24, 43, 31, 16, 120, 197, 133, 146, 193, 22, 213, 49, 170, 228, 159 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d4611002-39eb-4493-9483-5555f84f711e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("e4cd1e5f-37b6-474d-88ba-cf6dfdca9207") });
        }
    }
}
