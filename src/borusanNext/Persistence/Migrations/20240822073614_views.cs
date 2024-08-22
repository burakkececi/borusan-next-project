using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class views : Migration
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
        LEFT JOIN ""Engines"" e ON me.""EngineId"" = e.""Id""
        LEFT JOIN ""FuelTypes"" ft ON e.""FuelTypeId"" = ft.""Id""
        LEFT JOIN ""CarColors"" col ON c.""ColorId"" = col.""Id""
        LEFT JOIN ""BodyTypes"" bt ON me.""BodyTypeId"" = bt.""Id""
        LEFT JOIN ""Transmissions"" tr ON me.""TransmissionId"" = tr.""Id""
        LEFT JOIN ""ExpertizeResults"" er ON c.""TramerId"" = er.""Id""
        LEFT JOIN ""ChassisParts"" cp ON er.""ChassisPartId"" = cp.""Id""
        LEFT JOIN ""BodyShellParts"" bp ON er.""BodyShellPartId"" = bp.""Id""
        LEFT JOIN ""Sellers"" s ON c.""SellerId"" = s.""Id""
        LEFT JOIN ""Licences"" l ON s.""LicenceId"" = l.""Id""
        LEFT JOIN ""Locations"" loc ON s.""LocationId"" = loc.""Id"";
");

            migrationBuilder.Sql(@"
CREATE VIEW vm_CarModelDetails AS
SELECT 
        me.""Id"" AS ""Id"",
        me.""Name"" AS ""ModelExtensionName"",
        me.""Lenght"" AS ""Length"",
        me.""Width"" AS ""Width"",
        me.""Height"" AS ""Height"",
        me.""FuelTank"" AS ""FuelTank"",
        me.""LuggageCapacity"" AS ""LuggageCapacity"",
        me.""EmptyWeight"" AS ""EmptyWeight"",
        me.""ModelYear"" AS ""ModelYear"",
        cm.""Id"" AS ""CarModelId"",
        cm.""ModelName"" AS ""CarModelName"",
        b.""Id"" AS ""BrandId"",
        b.""Name"" AS ""BrandName"",
        b.""Logo"" AS ""BrandLogo"",
        g.""Id"" AS ""GenerationId"",
        g.""Name"" AS ""GenerationName"",
        e.""Id"" AS ""EngineId"",
        e.""EngineNo"" AS ""EngineNo"",
        e.""EngineCapacity"" AS ""EngineCapacity"",
        e.""MotorPower"" AS ""MotorPower"",
        e.""MaximumTorque"" AS ""MaximumTorque"",
        e.""Acceleration"" AS ""Acceleration"",
        e.""MaximumSpeed"" AS ""MaximumSpeed"",
        e.""FuelTankVolume"" AS ""FuelTankVolume"",
        e.""OutOfTownConsumptionRate"" AS ""OutOfTownConsumptionRate"",
        e.""UrbanConsumptionRate"" AS ""UrbanConsumptionRate"",
        e.""AverageConsumptionRate"" AS ""AverageConsumptionRate"",
        ft.""Name"" AS ""FuelTypeName"",
        bt.""Id"" AS ""BodyTypeId"",
        bt.""BodyName"" AS ""BodyTypeName"",
        bt.""Door"" AS ""BodyTypeDoor"",
        tr.""Id"" AS ""TransmissionId"",
        tr.""Name"" AS ""TransmissionName""
        FROM ""ModalExtensions"" me
        LEFT JOIN ""CarModels"" cm ON me.""CarModelId"" = cm.""Id""
        LEFT JOIN ""Brands"" b ON cm.""BrandId"" = b.""Id""
        LEFT JOIN ""Generations"" g ON me.""GenerationId"" = g.""Id""
        LEFT JOIN ""Engines"" e ON me.""EngineId"" = e.""Id""
        LEFT JOIN ""FuelTypes"" ft ON e.""FuelTypeId"" = ft.""Id""
        LEFT JOIN ""BodyTypes"" bt ON me.""BodyTypeId"" = bt.""Id""
        LEFT JOIN ""Transmissions"" tr ON me.""TransmissionId"" = tr.""Id""
");
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("878ab7a5-2f51-44ad-9a7e-12490985862d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f626ed3d-5324-4dcd-844b-e9167c5e7a34"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36160d4c-8a2a-4959-9769-ebf2bd812237"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 25, 234, 134, 123, 13, 6, 200, 234, 232, 170, 218, 128, 2, 253, 161, 26, 85, 97, 33, 253, 180, 16, 124, 230, 124, 44, 183, 244, 233, 249, 189, 213, 139, 60, 198, 185, 162, 209, 130, 203, 113, 146, 108, 160, 224, 55, 57, 137, 220, 68, 203, 130, 124, 226, 252, 27, 215, 190, 219, 163, 151, 46, 27, 40 }, new byte[] { 208, 202, 206, 22, 125, 26, 143, 65, 148, 198, 140, 6, 83, 21, 125, 175, 179, 175, 92, 202, 170, 150, 23, 240, 31, 64, 18, 116, 11, 138, 9, 133, 178, 103, 73, 22, 118, 220, 43, 203, 145, 120, 78, 159, 220, 111, 186, 232, 170, 64, 10, 105, 132, 146, 189, 141, 230, 82, 185, 81, 154, 137, 109, 69, 150, 150, 18, 47, 50, 31, 201, 26, 59, 135, 113, 7, 192, 222, 122, 89, 32, 245, 58, 94, 139, 136, 74, 250, 77, 55, 169, 103, 75, 65, 178, 4, 124, 8, 168, 5, 101, 96, 36, 121, 181, 58, 71, 107, 178, 97, 226, 117, 40, 208, 187, 189, 201, 156, 191, 95, 200, 188, 160, 47, 178, 75, 134, 37 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("398b5d31-f2e2-473f-8f40-78f7e79af217"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 25, 234, 134, 123, 13, 6, 200, 234, 232, 170, 218, 128, 2, 253, 161, 26, 85, 97, 33, 253, 180, 16, 124, 230, 124, 44, 183, 244, 233, 249, 189, 213, 139, 60, 198, 185, 162, 209, 130, 203, 113, 146, 108, 160, 224, 55, 57, 137, 220, 68, 203, 130, 124, 226, 252, 27, 215, 190, 219, 163, 151, 46, 27, 40 }, new byte[] { 208, 202, 206, 22, 125, 26, 143, 65, 148, 198, 140, 6, 83, 21, 125, 175, 179, 175, 92, 202, 170, 150, 23, 240, 31, 64, 18, 116, 11, 138, 9, 133, 178, 103, 73, 22, 118, 220, 43, 203, 145, 120, 78, 159, 220, 111, 186, 232, 170, 64, 10, 105, 132, 146, 189, 141, 230, 82, 185, 81, 154, 137, 109, 69, 150, 150, 18, 47, 50, 31, 201, 26, 59, 135, 113, 7, 192, 222, 122, 89, 32, 245, 58, 94, 139, 136, 74, 250, 77, 55, 169, 103, 75, 65, 178, 4, 124, 8, 168, 5, 101, 96, 36, 121, 181, 58, 71, 107, 178, 97, 226, 117, 40, 208, 187, 189, 201, 156, 191, 95, 200, 188, 160, 47, 178, 75, 134, 37 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6444d306-ab8e-4e84-a6ff-77037d68fd2e"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 25, 234, 134, 123, 13, 6, 200, 234, 232, 170, 218, 128, 2, 253, 161, 26, 85, 97, 33, 253, 180, 16, 124, 230, 124, 44, 183, 244, 233, 249, 189, 213, 139, 60, 198, 185, 162, 209, 130, 203, 113, 146, 108, 160, 224, 55, 57, 137, 220, 68, 203, 130, 124, 226, 252, 27, 215, 190, 219, 163, 151, 46, 27, 40 }, new byte[] { 208, 202, 206, 22, 125, 26, 143, 65, 148, 198, 140, 6, 83, 21, 125, 175, 179, 175, 92, 202, 170, 150, 23, 240, 31, 64, 18, 116, 11, 138, 9, 133, 178, 103, 73, 22, 118, 220, 43, 203, 145, 120, 78, 159, 220, 111, 186, 232, 170, 64, 10, 105, 132, 146, 189, 141, 230, 82, 185, 81, 154, 137, 109, 69, 150, 150, 18, 47, 50, 31, 201, 26, 59, 135, 113, 7, 192, 222, 122, 89, 32, 245, 58, 94, 139, 136, 74, 250, 77, 55, 169, 103, 75, 65, 178, 4, 124, 8, 168, 5, 101, 96, 36, 121, 181, 58, 71, 107, 178, 97, 226, 117, 40, 208, 187, 189, 201, 156, 191, 95, 200, 188, 160, 47, 178, 75, 134, 37 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd8e0f-59d4-4532-ae32-03cec3e39158"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 25, 234, 134, 123, 13, 6, 200, 234, 232, 170, 218, 128, 2, 253, 161, 26, 85, 97, 33, 253, 180, 16, 124, 230, 124, 44, 183, 244, 233, 249, 189, 213, 139, 60, 198, 185, 162, 209, 130, 203, 113, 146, 108, 160, 224, 55, 57, 137, 220, 68, 203, 130, 124, 226, 252, 27, 215, 190, 219, 163, 151, 46, 27, 40 }, new byte[] { 208, 202, 206, 22, 125, 26, 143, 65, 148, 198, 140, 6, 83, 21, 125, 175, 179, 175, 92, 202, 170, 150, 23, 240, 31, 64, 18, 116, 11, 138, 9, 133, 178, 103, 73, 22, 118, 220, 43, 203, 145, 120, 78, 159, 220, 111, 186, 232, 170, 64, 10, 105, 132, 146, 189, 141, 230, 82, 185, 81, 154, 137, 109, 69, 150, 150, 18, 47, 50, 31, 201, 26, 59, 135, 113, 7, 192, 222, 122, 89, 32, 245, 58, 94, 139, 136, 74, 250, 77, 55, 169, 103, 75, 65, 178, 4, 124, 8, 168, 5, 101, 96, 36, 121, 181, 58, 71, 107, 178, 97, 226, 117, 40, 208, 187, 189, 201, 156, 191, 95, 200, 188, 160, 47, 178, 75, 134, 37 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ada31c5d-6014-46d2-a1c3-ed8007e898cf"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 25, 234, 134, 123, 13, 6, 200, 234, 232, 170, 218, 128, 2, 253, 161, 26, 85, 97, 33, 253, 180, 16, 124, 230, 124, 44, 183, 244, 233, 249, 189, 213, 139, 60, 198, 185, 162, 209, 130, 203, 113, 146, 108, 160, 224, 55, 57, 137, 220, 68, 203, 130, 124, 226, 252, 27, 215, 190, 219, 163, 151, 46, 27, 40 }, new byte[] { 208, 202, 206, 22, 125, 26, 143, 65, 148, 198, 140, 6, 83, 21, 125, 175, 179, 175, 92, 202, 170, 150, 23, 240, 31, 64, 18, 116, 11, 138, 9, 133, 178, 103, 73, 22, 118, 220, 43, 203, 145, 120, 78, 159, 220, 111, 186, 232, 170, 64, 10, 105, 132, 146, 189, 141, 230, 82, 185, 81, 154, 137, 109, 69, 150, 150, 18, 47, 50, 31, 201, 26, 59, 135, 113, 7, 192, 222, 122, 89, 32, 245, 58, 94, 139, 136, 74, 250, 77, 55, 169, 103, 75, 65, 178, 4, 124, 8, 168, 5, 101, 96, 36, 121, 181, 58, 71, 107, 178, 97, 226, 117, 40, 208, 187, 189, 201, 156, 191, 95, 200, 188, 160, 47, 178, 75, 134, 37 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b73f6541-460e-4d9d-97eb-1402f63df038"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 25, 234, 134, 123, 13, 6, 200, 234, 232, 170, 218, 128, 2, 253, 161, 26, 85, 97, 33, 253, 180, 16, 124, 230, 124, 44, 183, 244, 233, 249, 189, 213, 139, 60, 198, 185, 162, 209, 130, 203, 113, 146, 108, 160, 224, 55, 57, 137, 220, 68, 203, 130, 124, 226, 252, 27, 215, 190, 219, 163, 151, 46, 27, 40 }, new byte[] { 208, 202, 206, 22, 125, 26, 143, 65, 148, 198, 140, 6, 83, 21, 125, 175, 179, 175, 92, 202, 170, 150, 23, 240, 31, 64, 18, 116, 11, 138, 9, 133, 178, 103, 73, 22, 118, 220, 43, 203, 145, 120, 78, 159, 220, 111, 186, 232, 170, 64, 10, 105, 132, 146, 189, 141, 230, 82, 185, 81, 154, 137, 109, 69, 150, 150, 18, 47, 50, 31, 201, 26, 59, 135, 113, 7, 192, 222, 122, 89, 32, 245, 58, 94, 139, 136, 74, 250, 77, 55, 169, 103, 75, 65, 178, 4, 124, 8, 168, 5, 101, 96, 36, 121, 181, 58, 71, 107, 178, 97, 226, 117, 40, 208, 187, 189, 201, 156, 191, 95, 200, 188, 160, 47, 178, 75, 134, 37 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd4dd3dc-72e4-42cb-bde3-0fcb1867b10d"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 25, 234, 134, 123, 13, 6, 200, 234, 232, 170, 218, 128, 2, 253, 161, 26, 85, 97, 33, 253, 180, 16, 124, 230, 124, 44, 183, 244, 233, 249, 189, 213, 139, 60, 198, 185, 162, 209, 130, 203, 113, 146, 108, 160, 224, 55, 57, 137, 220, 68, 203, 130, 124, 226, 252, 27, 215, 190, 219, 163, 151, 46, 27, 40 }, new byte[] { 208, 202, 206, 22, 125, 26, 143, 65, 148, 198, 140, 6, 83, 21, 125, 175, 179, 175, 92, 202, 170, 150, 23, 240, 31, 64, 18, 116, 11, 138, 9, 133, 178, 103, 73, 22, 118, 220, 43, 203, 145, 120, 78, 159, 220, 111, 186, 232, 170, 64, 10, 105, 132, 146, 189, 141, 230, 82, 185, 81, 154, 137, 109, 69, 150, 150, 18, 47, 50, 31, 201, 26, 59, 135, 113, 7, 192, 222, 122, 89, 32, 245, 58, 94, 139, 136, 74, 250, 77, 55, 169, 103, 75, 65, 178, 4, 124, 8, 168, 5, 101, 96, 36, 121, 181, 58, 71, 107, 178, 97, 226, 117, 40, 208, 187, 189, 201, 156, 191, 95, 200, 188, 160, 47, 178, 75, 134, 37 } });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("20021ebd-8c68-445f-aae6-4594b21a7c46"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@borusan.com", new byte[] { 25, 234, 134, 123, 13, 6, 200, 234, 232, 170, 218, 128, 2, 253, 161, 26, 85, 97, 33, 253, 180, 16, 124, 230, 124, 44, 183, 244, 233, 249, 189, 213, 139, 60, 198, 185, 162, 209, 130, 203, 113, 146, 108, 160, 224, 55, 57, 137, 220, 68, 203, 130, 124, 226, 252, 27, 215, 190, 219, 163, 151, 46, 27, 40 }, new byte[] { 208, 202, 206, 22, 125, 26, 143, 65, 148, 198, 140, 6, 83, 21, 125, 175, 179, 175, 92, 202, 170, 150, 23, 240, 31, 64, 18, 116, 11, 138, 9, 133, 178, 103, 73, 22, 118, 220, 43, 203, 145, 120, 78, 159, 220, 111, 186, 232, 170, 64, 10, 105, 132, 146, 189, 141, 230, 82, 185, 81, 154, 137, 109, 69, 150, 150, 18, 47, 50, 31, 201, 26, 59, 135, 113, 7, 192, 222, 122, 89, 32, 245, 58, 94, 139, 136, 74, 250, 77, 55, 169, 103, 75, 65, 178, 4, 124, 8, 168, 5, 101, 96, 36, 121, 181, 58, 71, 107, 178, 97, 226, 117, 40, 208, 187, 189, 201, 156, 191, 95, 200, 188, 160, 47, 178, 75, 134, 37 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("efc0eb49-205a-43d2-b5c4-4be65ad6acad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("20021ebd-8c68-445f-aae6-4594b21a7c46") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS vm_AdvertDetails;");
            migrationBuilder.Sql("DROP VIEW IF EXISTS vm_CarModelDetails;");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("efc0eb49-205a-43d2-b5c4-4be65ad6acad"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20021ebd-8c68-445f-aae6-4594b21a7c46"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36160d4c-8a2a-4959-9769-ebf2bd812237"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 5, 69, 51, 39, 8, 217, 21, 205, 136, 82, 170, 31, 71, 133, 164, 233, 27, 25, 30, 4, 254, 103, 145, 180, 5, 167, 149, 105, 141, 220, 130, 194, 147, 120, 22, 233, 118, 140, 57, 185, 150, 201, 229, 62, 67, 221, 254, 189, 103, 49, 19, 161, 84, 13, 201, 177, 107, 122, 11, 69, 38, 100, 42, 83 }, new byte[] { 97, 72, 138, 232, 213, 8, 43, 100, 152, 59, 200, 207, 125, 224, 169, 227, 126, 79, 248, 122, 39, 51, 200, 143, 86, 33, 30, 226, 185, 84, 181, 223, 246, 55, 127, 121, 250, 192, 77, 38, 58, 237, 102, 105, 88, 135, 109, 30, 152, 44, 12, 252, 107, 98, 45, 62, 102, 207, 240, 113, 40, 57, 118, 53, 190, 124, 73, 141, 20, 118, 167, 172, 218, 62, 185, 118, 206, 253, 1, 103, 84, 99, 117, 208, 149, 130, 95, 86, 202, 1, 240, 239, 128, 216, 64, 46, 87, 45, 67, 228, 31, 85, 239, 172, 241, 117, 112, 153, 53, 87, 73, 228, 88, 156, 63, 67, 247, 46, 54, 93, 104, 23, 123, 153, 117, 105, 178, 65 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("398b5d31-f2e2-473f-8f40-78f7e79af217"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 5, 69, 51, 39, 8, 217, 21, 205, 136, 82, 170, 31, 71, 133, 164, 233, 27, 25, 30, 4, 254, 103, 145, 180, 5, 167, 149, 105, 141, 220, 130, 194, 147, 120, 22, 233, 118, 140, 57, 185, 150, 201, 229, 62, 67, 221, 254, 189, 103, 49, 19, 161, 84, 13, 201, 177, 107, 122, 11, 69, 38, 100, 42, 83 }, new byte[] { 97, 72, 138, 232, 213, 8, 43, 100, 152, 59, 200, 207, 125, 224, 169, 227, 126, 79, 248, 122, 39, 51, 200, 143, 86, 33, 30, 226, 185, 84, 181, 223, 246, 55, 127, 121, 250, 192, 77, 38, 58, 237, 102, 105, 88, 135, 109, 30, 152, 44, 12, 252, 107, 98, 45, 62, 102, 207, 240, 113, 40, 57, 118, 53, 190, 124, 73, 141, 20, 118, 167, 172, 218, 62, 185, 118, 206, 253, 1, 103, 84, 99, 117, 208, 149, 130, 95, 86, 202, 1, 240, 239, 128, 216, 64, 46, 87, 45, 67, 228, 31, 85, 239, 172, 241, 117, 112, 153, 53, 87, 73, 228, 88, 156, 63, 67, 247, 46, 54, 93, 104, 23, 123, 153, 117, 105, 178, 65 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6444d306-ab8e-4e84-a6ff-77037d68fd2e"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 5, 69, 51, 39, 8, 217, 21, 205, 136, 82, 170, 31, 71, 133, 164, 233, 27, 25, 30, 4, 254, 103, 145, 180, 5, 167, 149, 105, 141, 220, 130, 194, 147, 120, 22, 233, 118, 140, 57, 185, 150, 201, 229, 62, 67, 221, 254, 189, 103, 49, 19, 161, 84, 13, 201, 177, 107, 122, 11, 69, 38, 100, 42, 83 }, new byte[] { 97, 72, 138, 232, 213, 8, 43, 100, 152, 59, 200, 207, 125, 224, 169, 227, 126, 79, 248, 122, 39, 51, 200, 143, 86, 33, 30, 226, 185, 84, 181, 223, 246, 55, 127, 121, 250, 192, 77, 38, 58, 237, 102, 105, 88, 135, 109, 30, 152, 44, 12, 252, 107, 98, 45, 62, 102, 207, 240, 113, 40, 57, 118, 53, 190, 124, 73, 141, 20, 118, 167, 172, 218, 62, 185, 118, 206, 253, 1, 103, 84, 99, 117, 208, 149, 130, 95, 86, 202, 1, 240, 239, 128, 216, 64, 46, 87, 45, 67, 228, 31, 85, 239, 172, 241, 117, 112, 153, 53, 87, 73, 228, 88, 156, 63, 67, 247, 46, 54, 93, 104, 23, 123, 153, 117, 105, 178, 65 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd8e0f-59d4-4532-ae32-03cec3e39158"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 5, 69, 51, 39, 8, 217, 21, 205, 136, 82, 170, 31, 71, 133, 164, 233, 27, 25, 30, 4, 254, 103, 145, 180, 5, 167, 149, 105, 141, 220, 130, 194, 147, 120, 22, 233, 118, 140, 57, 185, 150, 201, 229, 62, 67, 221, 254, 189, 103, 49, 19, 161, 84, 13, 201, 177, 107, 122, 11, 69, 38, 100, 42, 83 }, new byte[] { 97, 72, 138, 232, 213, 8, 43, 100, 152, 59, 200, 207, 125, 224, 169, 227, 126, 79, 248, 122, 39, 51, 200, 143, 86, 33, 30, 226, 185, 84, 181, 223, 246, 55, 127, 121, 250, 192, 77, 38, 58, 237, 102, 105, 88, 135, 109, 30, 152, 44, 12, 252, 107, 98, 45, 62, 102, 207, 240, 113, 40, 57, 118, 53, 190, 124, 73, 141, 20, 118, 167, 172, 218, 62, 185, 118, 206, 253, 1, 103, 84, 99, 117, 208, 149, 130, 95, 86, 202, 1, 240, 239, 128, 216, 64, 46, 87, 45, 67, 228, 31, 85, 239, 172, 241, 117, 112, 153, 53, 87, 73, 228, 88, 156, 63, 67, 247, 46, 54, 93, 104, 23, 123, 153, 117, 105, 178, 65 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ada31c5d-6014-46d2-a1c3-ed8007e898cf"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 5, 69, 51, 39, 8, 217, 21, 205, 136, 82, 170, 31, 71, 133, 164, 233, 27, 25, 30, 4, 254, 103, 145, 180, 5, 167, 149, 105, 141, 220, 130, 194, 147, 120, 22, 233, 118, 140, 57, 185, 150, 201, 229, 62, 67, 221, 254, 189, 103, 49, 19, 161, 84, 13, 201, 177, 107, 122, 11, 69, 38, 100, 42, 83 }, new byte[] { 97, 72, 138, 232, 213, 8, 43, 100, 152, 59, 200, 207, 125, 224, 169, 227, 126, 79, 248, 122, 39, 51, 200, 143, 86, 33, 30, 226, 185, 84, 181, 223, 246, 55, 127, 121, 250, 192, 77, 38, 58, 237, 102, 105, 88, 135, 109, 30, 152, 44, 12, 252, 107, 98, 45, 62, 102, 207, 240, 113, 40, 57, 118, 53, 190, 124, 73, 141, 20, 118, 167, 172, 218, 62, 185, 118, 206, 253, 1, 103, 84, 99, 117, 208, 149, 130, 95, 86, 202, 1, 240, 239, 128, 216, 64, 46, 87, 45, 67, 228, 31, 85, 239, 172, 241, 117, 112, 153, 53, 87, 73, 228, 88, 156, 63, 67, 247, 46, 54, 93, 104, 23, 123, 153, 117, 105, 178, 65 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b73f6541-460e-4d9d-97eb-1402f63df038"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 5, 69, 51, 39, 8, 217, 21, 205, 136, 82, 170, 31, 71, 133, 164, 233, 27, 25, 30, 4, 254, 103, 145, 180, 5, 167, 149, 105, 141, 220, 130, 194, 147, 120, 22, 233, 118, 140, 57, 185, 150, 201, 229, 62, 67, 221, 254, 189, 103, 49, 19, 161, 84, 13, 201, 177, 107, 122, 11, 69, 38, 100, 42, 83 }, new byte[] { 97, 72, 138, 232, 213, 8, 43, 100, 152, 59, 200, 207, 125, 224, 169, 227, 126, 79, 248, 122, 39, 51, 200, 143, 86, 33, 30, 226, 185, 84, 181, 223, 246, 55, 127, 121, 250, 192, 77, 38, 58, 237, 102, 105, 88, 135, 109, 30, 152, 44, 12, 252, 107, 98, 45, 62, 102, 207, 240, 113, 40, 57, 118, 53, 190, 124, 73, 141, 20, 118, 167, 172, 218, 62, 185, 118, 206, 253, 1, 103, 84, 99, 117, 208, 149, 130, 95, 86, 202, 1, 240, 239, 128, 216, 64, 46, 87, 45, 67, 228, 31, 85, 239, 172, 241, 117, 112, 153, 53, 87, 73, 228, 88, 156, 63, 67, 247, 46, 54, 93, 104, 23, 123, 153, 117, 105, 178, 65 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd4dd3dc-72e4-42cb-bde3-0fcb1867b10d"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 5, 69, 51, 39, 8, 217, 21, 205, 136, 82, 170, 31, 71, 133, 164, 233, 27, 25, 30, 4, 254, 103, 145, 180, 5, 167, 149, 105, 141, 220, 130, 194, 147, 120, 22, 233, 118, 140, 57, 185, 150, 201, 229, 62, 67, 221, 254, 189, 103, 49, 19, 161, 84, 13, 201, 177, 107, 122, 11, 69, 38, 100, 42, 83 }, new byte[] { 97, 72, 138, 232, 213, 8, 43, 100, 152, 59, 200, 207, 125, 224, 169, 227, 126, 79, 248, 122, 39, 51, 200, 143, 86, 33, 30, 226, 185, 84, 181, 223, 246, 55, 127, 121, 250, 192, 77, 38, 58, 237, 102, 105, 88, 135, 109, 30, 152, 44, 12, 252, 107, 98, 45, 62, 102, 207, 240, 113, 40, 57, 118, 53, 190, 124, 73, 141, 20, 118, 167, 172, 218, 62, 185, 118, 206, 253, 1, 103, 84, 99, 117, 208, 149, 130, 95, 86, 202, 1, 240, 239, 128, 216, 64, 46, 87, 45, 67, 228, 31, 85, 239, 172, 241, 117, 112, 153, 53, 87, 73, 228, 88, 156, 63, 67, 247, 46, 54, 93, 104, 23, 123, 153, 117, 105, 178, 65 } });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("f626ed3d-5324-4dcd-844b-e9167c5e7a34"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@borusan.com", new byte[] { 5, 69, 51, 39, 8, 217, 21, 205, 136, 82, 170, 31, 71, 133, 164, 233, 27, 25, 30, 4, 254, 103, 145, 180, 5, 167, 149, 105, 141, 220, 130, 194, 147, 120, 22, 233, 118, 140, 57, 185, 150, 201, 229, 62, 67, 221, 254, 189, 103, 49, 19, 161, 84, 13, 201, 177, 107, 122, 11, 69, 38, 100, 42, 83 }, new byte[] { 97, 72, 138, 232, 213, 8, 43, 100, 152, 59, 200, 207, 125, 224, 169, 227, 126, 79, 248, 122, 39, 51, 200, 143, 86, 33, 30, 226, 185, 84, 181, 223, 246, 55, 127, 121, 250, 192, 77, 38, 58, 237, 102, 105, 88, 135, 109, 30, 152, 44, 12, 252, 107, 98, 45, 62, 102, 207, 240, 113, 40, 57, 118, 53, 190, 124, 73, 141, 20, 118, 167, 172, 218, 62, 185, 118, 206, 253, 1, 103, 84, 99, 117, 208, 149, 130, 95, 86, 202, 1, 240, 239, 128, 216, 64, 46, 87, 45, 67, 228, 31, 85, 239, 172, 241, 117, 112, 153, 53, 87, 73, 228, 88, 156, 63, 67, 247, 46, 54, 93, 104, 23, 123, 153, 117, 105, 178, 65 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("878ab7a5-2f51-44ad-9a7e-12490985862d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f626ed3d-5324-4dcd-844b-e9167c5e7a34") });
        }
    }
}
