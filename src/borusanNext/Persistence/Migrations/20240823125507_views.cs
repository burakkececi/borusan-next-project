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
                keyValue: new Guid("d9a4aff6-9c81-45d7-ace0-4a1c2d4a2d2e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cb72bc53-4095-42e6-a158-ee2fabebfc30"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36160d4c-8a2a-4959-9769-ebf2bd812237"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 46, 178, 0, 123, 7, 53, 67, 127, 154, 155, 255, 147, 242, 211, 16, 74, 183, 20, 17, 62, 196, 135, 166, 233, 29, 249, 2, 120, 197, 51, 183, 119, 161, 32, 155, 198, 101, 127, 228, 157, 135, 151, 96, 152, 149, 32, 151, 49, 46, 187, 1, 21, 78, 184, 65, 65, 138, 165, 200, 245, 1, 13, 166, 155 }, new byte[] { 127, 93, 203, 2, 24, 185, 41, 107, 5, 92, 250, 145, 170, 93, 123, 50, 73, 50, 173, 103, 217, 125, 195, 242, 223, 255, 81, 22, 87, 120, 89, 50, 133, 5, 65, 121, 192, 97, 146, 181, 12, 75, 125, 249, 194, 237, 63, 173, 87, 223, 248, 25, 118, 87, 28, 107, 111, 94, 189, 109, 216, 54, 133, 171, 195, 87, 204, 227, 145, 27, 34, 69, 140, 4, 143, 58, 220, 240, 16, 127, 63, 0, 247, 211, 62, 19, 222, 225, 213, 0, 152, 126, 207, 117, 184, 28, 42, 246, 154, 242, 34, 76, 50, 29, 190, 252, 133, 91, 69, 123, 217, 18, 191, 163, 90, 6, 120, 54, 118, 91, 227, 16, 99, 202, 62, 210, 90, 145 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("398b5d31-f2e2-473f-8f40-78f7e79af217"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 46, 178, 0, 123, 7, 53, 67, 127, 154, 155, 255, 147, 242, 211, 16, 74, 183, 20, 17, 62, 196, 135, 166, 233, 29, 249, 2, 120, 197, 51, 183, 119, 161, 32, 155, 198, 101, 127, 228, 157, 135, 151, 96, 152, 149, 32, 151, 49, 46, 187, 1, 21, 78, 184, 65, 65, 138, 165, 200, 245, 1, 13, 166, 155 }, new byte[] { 127, 93, 203, 2, 24, 185, 41, 107, 5, 92, 250, 145, 170, 93, 123, 50, 73, 50, 173, 103, 217, 125, 195, 242, 223, 255, 81, 22, 87, 120, 89, 50, 133, 5, 65, 121, 192, 97, 146, 181, 12, 75, 125, 249, 194, 237, 63, 173, 87, 223, 248, 25, 118, 87, 28, 107, 111, 94, 189, 109, 216, 54, 133, 171, 195, 87, 204, 227, 145, 27, 34, 69, 140, 4, 143, 58, 220, 240, 16, 127, 63, 0, 247, 211, 62, 19, 222, 225, 213, 0, 152, 126, 207, 117, 184, 28, 42, 246, 154, 242, 34, 76, 50, 29, 190, 252, 133, 91, 69, 123, 217, 18, 191, 163, 90, 6, 120, 54, 118, 91, 227, 16, 99, 202, 62, 210, 90, 145 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6444d306-ab8e-4e84-a6ff-77037d68fd2e"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 46, 178, 0, 123, 7, 53, 67, 127, 154, 155, 255, 147, 242, 211, 16, 74, 183, 20, 17, 62, 196, 135, 166, 233, 29, 249, 2, 120, 197, 51, 183, 119, 161, 32, 155, 198, 101, 127, 228, 157, 135, 151, 96, 152, 149, 32, 151, 49, 46, 187, 1, 21, 78, 184, 65, 65, 138, 165, 200, 245, 1, 13, 166, 155 }, new byte[] { 127, 93, 203, 2, 24, 185, 41, 107, 5, 92, 250, 145, 170, 93, 123, 50, 73, 50, 173, 103, 217, 125, 195, 242, 223, 255, 81, 22, 87, 120, 89, 50, 133, 5, 65, 121, 192, 97, 146, 181, 12, 75, 125, 249, 194, 237, 63, 173, 87, 223, 248, 25, 118, 87, 28, 107, 111, 94, 189, 109, 216, 54, 133, 171, 195, 87, 204, 227, 145, 27, 34, 69, 140, 4, 143, 58, 220, 240, 16, 127, 63, 0, 247, 211, 62, 19, 222, 225, 213, 0, 152, 126, 207, 117, 184, 28, 42, 246, 154, 242, 34, 76, 50, 29, 190, 252, 133, 91, 69, 123, 217, 18, 191, 163, 90, 6, 120, 54, 118, 91, 227, 16, 99, 202, 62, 210, 90, 145 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd8e0f-59d4-4532-ae32-03cec3e39158"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 46, 178, 0, 123, 7, 53, 67, 127, 154, 155, 255, 147, 242, 211, 16, 74, 183, 20, 17, 62, 196, 135, 166, 233, 29, 249, 2, 120, 197, 51, 183, 119, 161, 32, 155, 198, 101, 127, 228, 157, 135, 151, 96, 152, 149, 32, 151, 49, 46, 187, 1, 21, 78, 184, 65, 65, 138, 165, 200, 245, 1, 13, 166, 155 }, new byte[] { 127, 93, 203, 2, 24, 185, 41, 107, 5, 92, 250, 145, 170, 93, 123, 50, 73, 50, 173, 103, 217, 125, 195, 242, 223, 255, 81, 22, 87, 120, 89, 50, 133, 5, 65, 121, 192, 97, 146, 181, 12, 75, 125, 249, 194, 237, 63, 173, 87, 223, 248, 25, 118, 87, 28, 107, 111, 94, 189, 109, 216, 54, 133, 171, 195, 87, 204, 227, 145, 27, 34, 69, 140, 4, 143, 58, 220, 240, 16, 127, 63, 0, 247, 211, 62, 19, 222, 225, 213, 0, 152, 126, 207, 117, 184, 28, 42, 246, 154, 242, 34, 76, 50, 29, 190, 252, 133, 91, 69, 123, 217, 18, 191, 163, 90, 6, 120, 54, 118, 91, 227, 16, 99, 202, 62, 210, 90, 145 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ada31c5d-6014-46d2-a1c3-ed8007e898cf"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 46, 178, 0, 123, 7, 53, 67, 127, 154, 155, 255, 147, 242, 211, 16, 74, 183, 20, 17, 62, 196, 135, 166, 233, 29, 249, 2, 120, 197, 51, 183, 119, 161, 32, 155, 198, 101, 127, 228, 157, 135, 151, 96, 152, 149, 32, 151, 49, 46, 187, 1, 21, 78, 184, 65, 65, 138, 165, 200, 245, 1, 13, 166, 155 }, new byte[] { 127, 93, 203, 2, 24, 185, 41, 107, 5, 92, 250, 145, 170, 93, 123, 50, 73, 50, 173, 103, 217, 125, 195, 242, 223, 255, 81, 22, 87, 120, 89, 50, 133, 5, 65, 121, 192, 97, 146, 181, 12, 75, 125, 249, 194, 237, 63, 173, 87, 223, 248, 25, 118, 87, 28, 107, 111, 94, 189, 109, 216, 54, 133, 171, 195, 87, 204, 227, 145, 27, 34, 69, 140, 4, 143, 58, 220, 240, 16, 127, 63, 0, 247, 211, 62, 19, 222, 225, 213, 0, 152, 126, 207, 117, 184, 28, 42, 246, 154, 242, 34, 76, 50, 29, 190, 252, 133, 91, 69, 123, 217, 18, 191, 163, 90, 6, 120, 54, 118, 91, 227, 16, 99, 202, 62, 210, 90, 145 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b73f6541-460e-4d9d-97eb-1402f63df038"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 46, 178, 0, 123, 7, 53, 67, 127, 154, 155, 255, 147, 242, 211, 16, 74, 183, 20, 17, 62, 196, 135, 166, 233, 29, 249, 2, 120, 197, 51, 183, 119, 161, 32, 155, 198, 101, 127, 228, 157, 135, 151, 96, 152, 149, 32, 151, 49, 46, 187, 1, 21, 78, 184, 65, 65, 138, 165, 200, 245, 1, 13, 166, 155 }, new byte[] { 127, 93, 203, 2, 24, 185, 41, 107, 5, 92, 250, 145, 170, 93, 123, 50, 73, 50, 173, 103, 217, 125, 195, 242, 223, 255, 81, 22, 87, 120, 89, 50, 133, 5, 65, 121, 192, 97, 146, 181, 12, 75, 125, 249, 194, 237, 63, 173, 87, 223, 248, 25, 118, 87, 28, 107, 111, 94, 189, 109, 216, 54, 133, 171, 195, 87, 204, 227, 145, 27, 34, 69, 140, 4, 143, 58, 220, 240, 16, 127, 63, 0, 247, 211, 62, 19, 222, 225, 213, 0, 152, 126, 207, 117, 184, 28, 42, 246, 154, 242, 34, 76, 50, 29, 190, 252, 133, 91, 69, 123, 217, 18, 191, 163, 90, 6, 120, 54, 118, 91, 227, 16, 99, 202, 62, 210, 90, 145 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd4dd3dc-72e4-42cb-bde3-0fcb1867b10d"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 46, 178, 0, 123, 7, 53, 67, 127, 154, 155, 255, 147, 242, 211, 16, 74, 183, 20, 17, 62, 196, 135, 166, 233, 29, 249, 2, 120, 197, 51, 183, 119, 161, 32, 155, 198, 101, 127, 228, 157, 135, 151, 96, 152, 149, 32, 151, 49, 46, 187, 1, 21, 78, 184, 65, 65, 138, 165, 200, 245, 1, 13, 166, 155 }, new byte[] { 127, 93, 203, 2, 24, 185, 41, 107, 5, 92, 250, 145, 170, 93, 123, 50, 73, 50, 173, 103, 217, 125, 195, 242, 223, 255, 81, 22, 87, 120, 89, 50, 133, 5, 65, 121, 192, 97, 146, 181, 12, 75, 125, 249, 194, 237, 63, 173, 87, 223, 248, 25, 118, 87, 28, 107, 111, 94, 189, 109, 216, 54, 133, 171, 195, 87, 204, 227, 145, 27, 34, 69, 140, 4, 143, 58, 220, 240, 16, 127, 63, 0, 247, 211, 62, 19, 222, 225, 213, 0, 152, 126, 207, 117, 184, 28, 42, 246, 154, 242, 34, 76, 50, 29, 190, 252, 133, 91, 69, 123, 217, 18, 191, 163, 90, 6, 120, 54, 118, 91, 227, 16, 99, 202, 62, 210, 90, 145 } });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("e569b1ff-c7be-4fba-a991-623cd615ec1d"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@borusan.com", new byte[] { 46, 178, 0, 123, 7, 53, 67, 127, 154, 155, 255, 147, 242, 211, 16, 74, 183, 20, 17, 62, 196, 135, 166, 233, 29, 249, 2, 120, 197, 51, 183, 119, 161, 32, 155, 198, 101, 127, 228, 157, 135, 151, 96, 152, 149, 32, 151, 49, 46, 187, 1, 21, 78, 184, 65, 65, 138, 165, 200, 245, 1, 13, 166, 155 }, new byte[] { 127, 93, 203, 2, 24, 185, 41, 107, 5, 92, 250, 145, 170, 93, 123, 50, 73, 50, 173, 103, 217, 125, 195, 242, 223, 255, 81, 22, 87, 120, 89, 50, 133, 5, 65, 121, 192, 97, 146, 181, 12, 75, 125, 249, 194, 237, 63, 173, 87, 223, 248, 25, 118, 87, 28, 107, 111, 94, 189, 109, 216, 54, 133, 171, 195, 87, 204, 227, 145, 27, 34, 69, 140, 4, 143, 58, 220, 240, 16, 127, 63, 0, 247, 211, 62, 19, 222, 225, 213, 0, 152, 126, 207, 117, 184, 28, 42, 246, 154, 242, 34, 76, 50, 29, 190, 252, 133, 91, 69, 123, 217, 18, 191, 163, 90, 6, 120, 54, 118, 91, 227, 16, 99, 202, 62, 210, 90, 145 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("05e060e8-3f90-4089-9304-f98fcde2da09"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("e569b1ff-c7be-4fba-a991-623cd615ec1d") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("DROP VIEW IF EXISTS vm_AdvertDetails;");
            migrationBuilder.Sql("DROP VIEW IF EXISTS vm_CarModelDetails;");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("05e060e8-3f90-4089-9304-f98fcde2da09"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e569b1ff-c7be-4fba-a991-623cd615ec1d"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36160d4c-8a2a-4959-9769-ebf2bd812237"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 0, 222, 42, 60, 56, 3, 154, 52, 233, 218, 245, 241, 246, 222, 120, 69, 180, 79, 1, 45, 18, 201, 12, 247, 166, 72, 130, 220, 210, 76, 15, 185, 41, 42, 136, 171, 95, 246, 99, 132, 231, 225, 121, 71, 154, 109, 110, 212, 204, 39, 205, 152, 107, 80, 49, 187, 236, 133, 143, 174, 57, 106, 44 }, new byte[] { 171, 242, 187, 121, 229, 66, 103, 182, 229, 240, 227, 173, 131, 93, 217, 68, 197, 54, 233, 168, 40, 249, 236, 159, 225, 114, 134, 43, 75, 169, 81, 234, 30, 187, 19, 107, 248, 1, 156, 14, 208, 138, 34, 52, 32, 30, 193, 196, 45, 169, 144, 115, 254, 46, 34, 81, 75, 99, 203, 14, 117, 195, 228, 19, 66, 143, 217, 134, 56, 179, 157, 91, 15, 240, 221, 242, 152, 132, 176, 237, 86, 104, 252, 129, 140, 179, 227, 119, 47, 198, 23, 82, 176, 223, 102, 186, 235, 135, 35, 87, 204, 230, 235, 50, 130, 80, 11, 173, 80, 10, 250, 126, 172, 56, 203, 128, 53, 219, 87, 155, 183, 139, 48, 48, 9, 123, 149, 87 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("398b5d31-f2e2-473f-8f40-78f7e79af217"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 0, 222, 42, 60, 56, 3, 154, 52, 233, 218, 245, 241, 246, 222, 120, 69, 180, 79, 1, 45, 18, 201, 12, 247, 166, 72, 130, 220, 210, 76, 15, 185, 41, 42, 136, 171, 95, 246, 99, 132, 231, 225, 121, 71, 154, 109, 110, 212, 204, 39, 205, 152, 107, 80, 49, 187, 236, 133, 143, 174, 57, 106, 44 }, new byte[] { 171, 242, 187, 121, 229, 66, 103, 182, 229, 240, 227, 173, 131, 93, 217, 68, 197, 54, 233, 168, 40, 249, 236, 159, 225, 114, 134, 43, 75, 169, 81, 234, 30, 187, 19, 107, 248, 1, 156, 14, 208, 138, 34, 52, 32, 30, 193, 196, 45, 169, 144, 115, 254, 46, 34, 81, 75, 99, 203, 14, 117, 195, 228, 19, 66, 143, 217, 134, 56, 179, 157, 91, 15, 240, 221, 242, 152, 132, 176, 237, 86, 104, 252, 129, 140, 179, 227, 119, 47, 198, 23, 82, 176, 223, 102, 186, 235, 135, 35, 87, 204, 230, 235, 50, 130, 80, 11, 173, 80, 10, 250, 126, 172, 56, 203, 128, 53, 219, 87, 155, 183, 139, 48, 48, 9, 123, 149, 87 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6444d306-ab8e-4e84-a6ff-77037d68fd2e"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 0, 222, 42, 60, 56, 3, 154, 52, 233, 218, 245, 241, 246, 222, 120, 69, 180, 79, 1, 45, 18, 201, 12, 247, 166, 72, 130, 220, 210, 76, 15, 185, 41, 42, 136, 171, 95, 246, 99, 132, 231, 225, 121, 71, 154, 109, 110, 212, 204, 39, 205, 152, 107, 80, 49, 187, 236, 133, 143, 174, 57, 106, 44 }, new byte[] { 171, 242, 187, 121, 229, 66, 103, 182, 229, 240, 227, 173, 131, 93, 217, 68, 197, 54, 233, 168, 40, 249, 236, 159, 225, 114, 134, 43, 75, 169, 81, 234, 30, 187, 19, 107, 248, 1, 156, 14, 208, 138, 34, 52, 32, 30, 193, 196, 45, 169, 144, 115, 254, 46, 34, 81, 75, 99, 203, 14, 117, 195, 228, 19, 66, 143, 217, 134, 56, 179, 157, 91, 15, 240, 221, 242, 152, 132, 176, 237, 86, 104, 252, 129, 140, 179, 227, 119, 47, 198, 23, 82, 176, 223, 102, 186, 235, 135, 35, 87, 204, 230, 235, 50, 130, 80, 11, 173, 80, 10, 250, 126, 172, 56, 203, 128, 53, 219, 87, 155, 183, 139, 48, 48, 9, 123, 149, 87 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd8e0f-59d4-4532-ae32-03cec3e39158"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 0, 222, 42, 60, 56, 3, 154, 52, 233, 218, 245, 241, 246, 222, 120, 69, 180, 79, 1, 45, 18, 201, 12, 247, 166, 72, 130, 220, 210, 76, 15, 185, 41, 42, 136, 171, 95, 246, 99, 132, 231, 225, 121, 71, 154, 109, 110, 212, 204, 39, 205, 152, 107, 80, 49, 187, 236, 133, 143, 174, 57, 106, 44 }, new byte[] { 171, 242, 187, 121, 229, 66, 103, 182, 229, 240, 227, 173, 131, 93, 217, 68, 197, 54, 233, 168, 40, 249, 236, 159, 225, 114, 134, 43, 75, 169, 81, 234, 30, 187, 19, 107, 248, 1, 156, 14, 208, 138, 34, 52, 32, 30, 193, 196, 45, 169, 144, 115, 254, 46, 34, 81, 75, 99, 203, 14, 117, 195, 228, 19, 66, 143, 217, 134, 56, 179, 157, 91, 15, 240, 221, 242, 152, 132, 176, 237, 86, 104, 252, 129, 140, 179, 227, 119, 47, 198, 23, 82, 176, 223, 102, 186, 235, 135, 35, 87, 204, 230, 235, 50, 130, 80, 11, 173, 80, 10, 250, 126, 172, 56, 203, 128, 53, 219, 87, 155, 183, 139, 48, 48, 9, 123, 149, 87 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ada31c5d-6014-46d2-a1c3-ed8007e898cf"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 0, 222, 42, 60, 56, 3, 154, 52, 233, 218, 245, 241, 246, 222, 120, 69, 180, 79, 1, 45, 18, 201, 12, 247, 166, 72, 130, 220, 210, 76, 15, 185, 41, 42, 136, 171, 95, 246, 99, 132, 231, 225, 121, 71, 154, 109, 110, 212, 204, 39, 205, 152, 107, 80, 49, 187, 236, 133, 143, 174, 57, 106, 44 }, new byte[] { 171, 242, 187, 121, 229, 66, 103, 182, 229, 240, 227, 173, 131, 93, 217, 68, 197, 54, 233, 168, 40, 249, 236, 159, 225, 114, 134, 43, 75, 169, 81, 234, 30, 187, 19, 107, 248, 1, 156, 14, 208, 138, 34, 52, 32, 30, 193, 196, 45, 169, 144, 115, 254, 46, 34, 81, 75, 99, 203, 14, 117, 195, 228, 19, 66, 143, 217, 134, 56, 179, 157, 91, 15, 240, 221, 242, 152, 132, 176, 237, 86, 104, 252, 129, 140, 179, 227, 119, 47, 198, 23, 82, 176, 223, 102, 186, 235, 135, 35, 87, 204, 230, 235, 50, 130, 80, 11, 173, 80, 10, 250, 126, 172, 56, 203, 128, 53, 219, 87, 155, 183, 139, 48, 48, 9, 123, 149, 87 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b73f6541-460e-4d9d-97eb-1402f63df038"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 0, 222, 42, 60, 56, 3, 154, 52, 233, 218, 245, 241, 246, 222, 120, 69, 180, 79, 1, 45, 18, 201, 12, 247, 166, 72, 130, 220, 210, 76, 15, 185, 41, 42, 136, 171, 95, 246, 99, 132, 231, 225, 121, 71, 154, 109, 110, 212, 204, 39, 205, 152, 107, 80, 49, 187, 236, 133, 143, 174, 57, 106, 44 }, new byte[] { 171, 242, 187, 121, 229, 66, 103, 182, 229, 240, 227, 173, 131, 93, 217, 68, 197, 54, 233, 168, 40, 249, 236, 159, 225, 114, 134, 43, 75, 169, 81, 234, 30, 187, 19, 107, 248, 1, 156, 14, 208, 138, 34, 52, 32, 30, 193, 196, 45, 169, 144, 115, 254, 46, 34, 81, 75, 99, 203, 14, 117, 195, 228, 19, 66, 143, 217, 134, 56, 179, 157, 91, 15, 240, 221, 242, 152, 132, 176, 237, 86, 104, 252, 129, 140, 179, 227, 119, 47, 198, 23, 82, 176, 223, 102, 186, 235, 135, 35, 87, 204, 230, 235, 50, 130, 80, 11, 173, 80, 10, 250, 126, 172, 56, 203, 128, 53, 219, 87, 155, 183, 139, 48, 48, 9, 123, 149, 87 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd4dd3dc-72e4-42cb-bde3-0fcb1867b10d"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 0, 222, 42, 60, 56, 3, 154, 52, 233, 218, 245, 241, 246, 222, 120, 69, 180, 79, 1, 45, 18, 201, 12, 247, 166, 72, 130, 220, 210, 76, 15, 185, 41, 42, 136, 171, 95, 246, 99, 132, 231, 225, 121, 71, 154, 109, 110, 212, 204, 39, 205, 152, 107, 80, 49, 187, 236, 133, 143, 174, 57, 106, 44 }, new byte[] { 171, 242, 187, 121, 229, 66, 103, 182, 229, 240, 227, 173, 131, 93, 217, 68, 197, 54, 233, 168, 40, 249, 236, 159, 225, 114, 134, 43, 75, 169, 81, 234, 30, 187, 19, 107, 248, 1, 156, 14, 208, 138, 34, 52, 32, 30, 193, 196, 45, 169, 144, 115, 254, 46, 34, 81, 75, 99, 203, 14, 117, 195, 228, 19, 66, 143, 217, 134, 56, 179, 157, 91, 15, 240, 221, 242, 152, 132, 176, 237, 86, 104, 252, 129, 140, 179, 227, 119, 47, 198, 23, 82, 176, 223, 102, 186, 235, 135, 35, 87, 204, 230, 235, 50, 130, 80, 11, 173, 80, 10, 250, 126, 172, 56, 203, 128, 53, 219, 87, 155, 183, 139, 48, 48, 9, 123, 149, 87 } });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("cb72bc53-4095-42e6-a158-ee2fabebfc30"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@borusan.com", new byte[] { 12, 0, 222, 42, 60, 56, 3, 154, 52, 233, 218, 245, 241, 246, 222, 120, 69, 180, 79, 1, 45, 18, 201, 12, 247, 166, 72, 130, 220, 210, 76, 15, 185, 41, 42, 136, 171, 95, 246, 99, 132, 231, 225, 121, 71, 154, 109, 110, 212, 204, 39, 205, 152, 107, 80, 49, 187, 236, 133, 143, 174, 57, 106, 44 }, new byte[] { 171, 242, 187, 121, 229, 66, 103, 182, 229, 240, 227, 173, 131, 93, 217, 68, 197, 54, 233, 168, 40, 249, 236, 159, 225, 114, 134, 43, 75, 169, 81, 234, 30, 187, 19, 107, 248, 1, 156, 14, 208, 138, 34, 52, 32, 30, 193, 196, 45, 169, 144, 115, 254, 46, 34, 81, 75, 99, 203, 14, 117, 195, 228, 19, 66, 143, 217, 134, 56, 179, 157, 91, 15, 240, 221, 242, 152, 132, 176, 237, 86, 104, 252, 129, 140, 179, 227, 119, 47, 198, 23, 82, 176, 223, 102, 186, 235, 135, 35, 87, 204, 230, 235, 50, 130, 80, 11, 173, 80, 10, 250, 126, 172, 56, 203, 128, 53, 219, 87, 155, 183, 139, 48, 48, 9, 123, 149, 87 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d9a4aff6-9c81-45d7-ace0-4a1c2d4a2d2e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("cb72bc53-4095-42e6-a158-ee2fabebfc30") });
        }
    }
}
