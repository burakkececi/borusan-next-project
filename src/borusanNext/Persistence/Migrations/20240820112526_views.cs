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
                keyValue: new Guid("70cf7672-2f94-4025-ae23-d9a876d61037"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7d9e3a9f-3dc4-45c4-91c1-37c59f4fd8c7"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36160d4c-8a2a-4959-9769-ebf2bd812237"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 134, 247, 126, 240, 207, 178, 113, 251, 149, 251, 175, 200, 121, 217, 5, 225, 233, 198, 77, 84, 150, 126, 3, 194, 182, 140, 221, 93, 239, 67, 203, 169, 62, 200, 81, 143, 86, 20, 72, 7, 191, 84, 113, 151, 254, 226, 120, 159, 44, 11, 145, 21, 200, 140, 250, 187, 174, 25, 95, 23, 120, 116, 253, 106 }, new byte[] { 66, 174, 142, 46, 118, 147, 217, 222, 145, 61, 90, 26, 74, 15, 109, 105, 80, 209, 224, 198, 154, 87, 139, 34, 238, 234, 188, 31, 128, 88, 23, 151, 47, 189, 208, 49, 73, 142, 150, 81, 45, 235, 86, 78, 159, 190, 1, 170, 224, 19, 249, 157, 28, 131, 27, 140, 153, 41, 220, 99, 53, 255, 27, 105, 188, 70, 158, 30, 252, 102, 127, 130, 125, 16, 157, 19, 254, 86, 237, 144, 73, 9, 32, 176, 112, 197, 109, 128, 61, 247, 79, 179, 99, 106, 0, 247, 101, 141, 192, 47, 125, 133, 145, 59, 92, 30, 5, 87, 122, 246, 118, 213, 192, 16, 126, 17, 180, 44, 66, 239, 62, 97, 166, 29, 179, 244, 75, 87 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("398b5d31-f2e2-473f-8f40-78f7e79af217"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 134, 247, 126, 240, 207, 178, 113, 251, 149, 251, 175, 200, 121, 217, 5, 225, 233, 198, 77, 84, 150, 126, 3, 194, 182, 140, 221, 93, 239, 67, 203, 169, 62, 200, 81, 143, 86, 20, 72, 7, 191, 84, 113, 151, 254, 226, 120, 159, 44, 11, 145, 21, 200, 140, 250, 187, 174, 25, 95, 23, 120, 116, 253, 106 }, new byte[] { 66, 174, 142, 46, 118, 147, 217, 222, 145, 61, 90, 26, 74, 15, 109, 105, 80, 209, 224, 198, 154, 87, 139, 34, 238, 234, 188, 31, 128, 88, 23, 151, 47, 189, 208, 49, 73, 142, 150, 81, 45, 235, 86, 78, 159, 190, 1, 170, 224, 19, 249, 157, 28, 131, 27, 140, 153, 41, 220, 99, 53, 255, 27, 105, 188, 70, 158, 30, 252, 102, 127, 130, 125, 16, 157, 19, 254, 86, 237, 144, 73, 9, 32, 176, 112, 197, 109, 128, 61, 247, 79, 179, 99, 106, 0, 247, 101, 141, 192, 47, 125, 133, 145, 59, 92, 30, 5, 87, 122, 246, 118, 213, 192, 16, 126, 17, 180, 44, 66, 239, 62, 97, 166, 29, 179, 244, 75, 87 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6444d306-ab8e-4e84-a6ff-77037d68fd2e"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 134, 247, 126, 240, 207, 178, 113, 251, 149, 251, 175, 200, 121, 217, 5, 225, 233, 198, 77, 84, 150, 126, 3, 194, 182, 140, 221, 93, 239, 67, 203, 169, 62, 200, 81, 143, 86, 20, 72, 7, 191, 84, 113, 151, 254, 226, 120, 159, 44, 11, 145, 21, 200, 140, 250, 187, 174, 25, 95, 23, 120, 116, 253, 106 }, new byte[] { 66, 174, 142, 46, 118, 147, 217, 222, 145, 61, 90, 26, 74, 15, 109, 105, 80, 209, 224, 198, 154, 87, 139, 34, 238, 234, 188, 31, 128, 88, 23, 151, 47, 189, 208, 49, 73, 142, 150, 81, 45, 235, 86, 78, 159, 190, 1, 170, 224, 19, 249, 157, 28, 131, 27, 140, 153, 41, 220, 99, 53, 255, 27, 105, 188, 70, 158, 30, 252, 102, 127, 130, 125, 16, 157, 19, 254, 86, 237, 144, 73, 9, 32, 176, 112, 197, 109, 128, 61, 247, 79, 179, 99, 106, 0, 247, 101, 141, 192, 47, 125, 133, 145, 59, 92, 30, 5, 87, 122, 246, 118, 213, 192, 16, 126, 17, 180, 44, 66, 239, 62, 97, 166, 29, 179, 244, 75, 87 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd8e0f-59d4-4532-ae32-03cec3e39158"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 134, 247, 126, 240, 207, 178, 113, 251, 149, 251, 175, 200, 121, 217, 5, 225, 233, 198, 77, 84, 150, 126, 3, 194, 182, 140, 221, 93, 239, 67, 203, 169, 62, 200, 81, 143, 86, 20, 72, 7, 191, 84, 113, 151, 254, 226, 120, 159, 44, 11, 145, 21, 200, 140, 250, 187, 174, 25, 95, 23, 120, 116, 253, 106 }, new byte[] { 66, 174, 142, 46, 118, 147, 217, 222, 145, 61, 90, 26, 74, 15, 109, 105, 80, 209, 224, 198, 154, 87, 139, 34, 238, 234, 188, 31, 128, 88, 23, 151, 47, 189, 208, 49, 73, 142, 150, 81, 45, 235, 86, 78, 159, 190, 1, 170, 224, 19, 249, 157, 28, 131, 27, 140, 153, 41, 220, 99, 53, 255, 27, 105, 188, 70, 158, 30, 252, 102, 127, 130, 125, 16, 157, 19, 254, 86, 237, 144, 73, 9, 32, 176, 112, 197, 109, 128, 61, 247, 79, 179, 99, 106, 0, 247, 101, 141, 192, 47, 125, 133, 145, 59, 92, 30, 5, 87, 122, 246, 118, 213, 192, 16, 126, 17, 180, 44, 66, 239, 62, 97, 166, 29, 179, 244, 75, 87 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ada31c5d-6014-46d2-a1c3-ed8007e898cf"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 134, 247, 126, 240, 207, 178, 113, 251, 149, 251, 175, 200, 121, 217, 5, 225, 233, 198, 77, 84, 150, 126, 3, 194, 182, 140, 221, 93, 239, 67, 203, 169, 62, 200, 81, 143, 86, 20, 72, 7, 191, 84, 113, 151, 254, 226, 120, 159, 44, 11, 145, 21, 200, 140, 250, 187, 174, 25, 95, 23, 120, 116, 253, 106 }, new byte[] { 66, 174, 142, 46, 118, 147, 217, 222, 145, 61, 90, 26, 74, 15, 109, 105, 80, 209, 224, 198, 154, 87, 139, 34, 238, 234, 188, 31, 128, 88, 23, 151, 47, 189, 208, 49, 73, 142, 150, 81, 45, 235, 86, 78, 159, 190, 1, 170, 224, 19, 249, 157, 28, 131, 27, 140, 153, 41, 220, 99, 53, 255, 27, 105, 188, 70, 158, 30, 252, 102, 127, 130, 125, 16, 157, 19, 254, 86, 237, 144, 73, 9, 32, 176, 112, 197, 109, 128, 61, 247, 79, 179, 99, 106, 0, 247, 101, 141, 192, 47, 125, 133, 145, 59, 92, 30, 5, 87, 122, 246, 118, 213, 192, 16, 126, 17, 180, 44, 66, 239, 62, 97, 166, 29, 179, 244, 75, 87 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b73f6541-460e-4d9d-97eb-1402f63df038"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 134, 247, 126, 240, 207, 178, 113, 251, 149, 251, 175, 200, 121, 217, 5, 225, 233, 198, 77, 84, 150, 126, 3, 194, 182, 140, 221, 93, 239, 67, 203, 169, 62, 200, 81, 143, 86, 20, 72, 7, 191, 84, 113, 151, 254, 226, 120, 159, 44, 11, 145, 21, 200, 140, 250, 187, 174, 25, 95, 23, 120, 116, 253, 106 }, new byte[] { 66, 174, 142, 46, 118, 147, 217, 222, 145, 61, 90, 26, 74, 15, 109, 105, 80, 209, 224, 198, 154, 87, 139, 34, 238, 234, 188, 31, 128, 88, 23, 151, 47, 189, 208, 49, 73, 142, 150, 81, 45, 235, 86, 78, 159, 190, 1, 170, 224, 19, 249, 157, 28, 131, 27, 140, 153, 41, 220, 99, 53, 255, 27, 105, 188, 70, 158, 30, 252, 102, 127, 130, 125, 16, 157, 19, 254, 86, 237, 144, 73, 9, 32, 176, 112, 197, 109, 128, 61, 247, 79, 179, 99, 106, 0, 247, 101, 141, 192, 47, 125, 133, 145, 59, 92, 30, 5, 87, 122, 246, 118, 213, 192, 16, 126, 17, 180, 44, 66, 239, 62, 97, 166, 29, 179, 244, 75, 87 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd4dd3dc-72e4-42cb-bde3-0fcb1867b10d"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 134, 247, 126, 240, 207, 178, 113, 251, 149, 251, 175, 200, 121, 217, 5, 225, 233, 198, 77, 84, 150, 126, 3, 194, 182, 140, 221, 93, 239, 67, 203, 169, 62, 200, 81, 143, 86, 20, 72, 7, 191, 84, 113, 151, 254, 226, 120, 159, 44, 11, 145, 21, 200, 140, 250, 187, 174, 25, 95, 23, 120, 116, 253, 106 }, new byte[] { 66, 174, 142, 46, 118, 147, 217, 222, 145, 61, 90, 26, 74, 15, 109, 105, 80, 209, 224, 198, 154, 87, 139, 34, 238, 234, 188, 31, 128, 88, 23, 151, 47, 189, 208, 49, 73, 142, 150, 81, 45, 235, 86, 78, 159, 190, 1, 170, 224, 19, 249, 157, 28, 131, 27, 140, 153, 41, 220, 99, 53, 255, 27, 105, 188, 70, 158, 30, 252, 102, 127, 130, 125, 16, 157, 19, 254, 86, 237, 144, 73, 9, 32, 176, 112, 197, 109, 128, 61, 247, 79, 179, 99, 106, 0, 247, 101, 141, 192, 47, 125, 133, 145, 59, 92, 30, 5, 87, 122, 246, 118, 213, 192, 16, 126, 17, 180, 44, 66, 239, 62, 97, 166, 29, 179, 244, 75, 87 } });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("c9c05de8-481d-48ff-9d87-37063870d41d"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@borusan.com", new byte[] { 134, 247, 126, 240, 207, 178, 113, 251, 149, 251, 175, 200, 121, 217, 5, 225, 233, 198, 77, 84, 150, 126, 3, 194, 182, 140, 221, 93, 239, 67, 203, 169, 62, 200, 81, 143, 86, 20, 72, 7, 191, 84, 113, 151, 254, 226, 120, 159, 44, 11, 145, 21, 200, 140, 250, 187, 174, 25, 95, 23, 120, 116, 253, 106 }, new byte[] { 66, 174, 142, 46, 118, 147, 217, 222, 145, 61, 90, 26, 74, 15, 109, 105, 80, 209, 224, 198, 154, 87, 139, 34, 238, 234, 188, 31, 128, 88, 23, 151, 47, 189, 208, 49, 73, 142, 150, 81, 45, 235, 86, 78, 159, 190, 1, 170, 224, 19, 249, 157, 28, 131, 27, 140, 153, 41, 220, 99, 53, 255, 27, 105, 188, 70, 158, 30, 252, 102, 127, 130, 125, 16, 157, 19, 254, 86, 237, 144, 73, 9, 32, 176, 112, 197, 109, 128, 61, 247, 79, 179, 99, 106, 0, 247, 101, 141, 192, 47, 125, 133, 145, 59, 92, 30, 5, 87, 122, 246, 118, 213, 192, 16, 126, 17, 180, 44, 66, 239, 62, 97, 166, 29, 179, 244, 75, 87 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("0cf7c4fa-d857-4de9-adc5-bb1296251400"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("c9c05de8-481d-48ff-9d87-37063870d41d") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS vm_AdvertDetails;");
            migrationBuilder.Sql("DROP VIEW IF EXISTS vm_CarModelDetails;");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0cf7c4fa-d857-4de9-adc5-bb1296251400"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c9c05de8-481d-48ff-9d87-37063870d41d"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36160d4c-8a2a-4959-9769-ebf2bd812237"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 194, 106, 134, 72, 142, 183, 165, 5, 174, 71, 119, 160, 35, 108, 101, 184, 180, 107, 9, 45, 25, 156, 224, 218, 64, 117, 98, 61, 69, 231, 185, 37, 175, 241, 43, 87, 171, 234, 242, 87, 203, 100, 246, 237, 123, 221, 235, 116, 172, 38, 58, 65, 6, 10, 126, 51, 135, 181, 116, 210, 49, 209, 34, 83 }, new byte[] { 58, 75, 225, 195, 230, 87, 223, 137, 60, 227, 111, 107, 32, 33, 30, 133, 204, 16, 252, 133, 43, 235, 88, 241, 38, 125, 208, 166, 185, 147, 82, 149, 129, 136, 40, 149, 77, 17, 10, 142, 241, 176, 229, 139, 153, 45, 187, 104, 149, 169, 140, 132, 128, 82, 160, 130, 175, 221, 68, 191, 32, 51, 134, 234, 188, 102, 57, 39, 145, 54, 129, 64, 137, 86, 85, 181, 204, 147, 0, 35, 208, 122, 92, 105, 206, 18, 120, 184, 0, 184, 250, 130, 216, 19, 4, 192, 194, 220, 44, 162, 10, 250, 236, 150, 101, 148, 67, 48, 160, 75, 151, 86, 107, 92, 14, 213, 1, 111, 81, 109, 132, 126, 69, 4, 50, 120, 26, 211 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("398b5d31-f2e2-473f-8f40-78f7e79af217"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 194, 106, 134, 72, 142, 183, 165, 5, 174, 71, 119, 160, 35, 108, 101, 184, 180, 107, 9, 45, 25, 156, 224, 218, 64, 117, 98, 61, 69, 231, 185, 37, 175, 241, 43, 87, 171, 234, 242, 87, 203, 100, 246, 237, 123, 221, 235, 116, 172, 38, 58, 65, 6, 10, 126, 51, 135, 181, 116, 210, 49, 209, 34, 83 }, new byte[] { 58, 75, 225, 195, 230, 87, 223, 137, 60, 227, 111, 107, 32, 33, 30, 133, 204, 16, 252, 133, 43, 235, 88, 241, 38, 125, 208, 166, 185, 147, 82, 149, 129, 136, 40, 149, 77, 17, 10, 142, 241, 176, 229, 139, 153, 45, 187, 104, 149, 169, 140, 132, 128, 82, 160, 130, 175, 221, 68, 191, 32, 51, 134, 234, 188, 102, 57, 39, 145, 54, 129, 64, 137, 86, 85, 181, 204, 147, 0, 35, 208, 122, 92, 105, 206, 18, 120, 184, 0, 184, 250, 130, 216, 19, 4, 192, 194, 220, 44, 162, 10, 250, 236, 150, 101, 148, 67, 48, 160, 75, 151, 86, 107, 92, 14, 213, 1, 111, 81, 109, 132, 126, 69, 4, 50, 120, 26, 211 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6444d306-ab8e-4e84-a6ff-77037d68fd2e"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 194, 106, 134, 72, 142, 183, 165, 5, 174, 71, 119, 160, 35, 108, 101, 184, 180, 107, 9, 45, 25, 156, 224, 218, 64, 117, 98, 61, 69, 231, 185, 37, 175, 241, 43, 87, 171, 234, 242, 87, 203, 100, 246, 237, 123, 221, 235, 116, 172, 38, 58, 65, 6, 10, 126, 51, 135, 181, 116, 210, 49, 209, 34, 83 }, new byte[] { 58, 75, 225, 195, 230, 87, 223, 137, 60, 227, 111, 107, 32, 33, 30, 133, 204, 16, 252, 133, 43, 235, 88, 241, 38, 125, 208, 166, 185, 147, 82, 149, 129, 136, 40, 149, 77, 17, 10, 142, 241, 176, 229, 139, 153, 45, 187, 104, 149, 169, 140, 132, 128, 82, 160, 130, 175, 221, 68, 191, 32, 51, 134, 234, 188, 102, 57, 39, 145, 54, 129, 64, 137, 86, 85, 181, 204, 147, 0, 35, 208, 122, 92, 105, 206, 18, 120, 184, 0, 184, 250, 130, 216, 19, 4, 192, 194, 220, 44, 162, 10, 250, 236, 150, 101, 148, 67, 48, 160, 75, 151, 86, 107, 92, 14, 213, 1, 111, 81, 109, 132, 126, 69, 4, 50, 120, 26, 211 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd8e0f-59d4-4532-ae32-03cec3e39158"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 194, 106, 134, 72, 142, 183, 165, 5, 174, 71, 119, 160, 35, 108, 101, 184, 180, 107, 9, 45, 25, 156, 224, 218, 64, 117, 98, 61, 69, 231, 185, 37, 175, 241, 43, 87, 171, 234, 242, 87, 203, 100, 246, 237, 123, 221, 235, 116, 172, 38, 58, 65, 6, 10, 126, 51, 135, 181, 116, 210, 49, 209, 34, 83 }, new byte[] { 58, 75, 225, 195, 230, 87, 223, 137, 60, 227, 111, 107, 32, 33, 30, 133, 204, 16, 252, 133, 43, 235, 88, 241, 38, 125, 208, 166, 185, 147, 82, 149, 129, 136, 40, 149, 77, 17, 10, 142, 241, 176, 229, 139, 153, 45, 187, 104, 149, 169, 140, 132, 128, 82, 160, 130, 175, 221, 68, 191, 32, 51, 134, 234, 188, 102, 57, 39, 145, 54, 129, 64, 137, 86, 85, 181, 204, 147, 0, 35, 208, 122, 92, 105, 206, 18, 120, 184, 0, 184, 250, 130, 216, 19, 4, 192, 194, 220, 44, 162, 10, 250, 236, 150, 101, 148, 67, 48, 160, 75, 151, 86, 107, 92, 14, 213, 1, 111, 81, 109, 132, 126, 69, 4, 50, 120, 26, 211 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ada31c5d-6014-46d2-a1c3-ed8007e898cf"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 194, 106, 134, 72, 142, 183, 165, 5, 174, 71, 119, 160, 35, 108, 101, 184, 180, 107, 9, 45, 25, 156, 224, 218, 64, 117, 98, 61, 69, 231, 185, 37, 175, 241, 43, 87, 171, 234, 242, 87, 203, 100, 246, 237, 123, 221, 235, 116, 172, 38, 58, 65, 6, 10, 126, 51, 135, 181, 116, 210, 49, 209, 34, 83 }, new byte[] { 58, 75, 225, 195, 230, 87, 223, 137, 60, 227, 111, 107, 32, 33, 30, 133, 204, 16, 252, 133, 43, 235, 88, 241, 38, 125, 208, 166, 185, 147, 82, 149, 129, 136, 40, 149, 77, 17, 10, 142, 241, 176, 229, 139, 153, 45, 187, 104, 149, 169, 140, 132, 128, 82, 160, 130, 175, 221, 68, 191, 32, 51, 134, 234, 188, 102, 57, 39, 145, 54, 129, 64, 137, 86, 85, 181, 204, 147, 0, 35, 208, 122, 92, 105, 206, 18, 120, 184, 0, 184, 250, 130, 216, 19, 4, 192, 194, 220, 44, 162, 10, 250, 236, 150, 101, 148, 67, 48, 160, 75, 151, 86, 107, 92, 14, 213, 1, 111, 81, 109, 132, 126, 69, 4, 50, 120, 26, 211 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b73f6541-460e-4d9d-97eb-1402f63df038"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 194, 106, 134, 72, 142, 183, 165, 5, 174, 71, 119, 160, 35, 108, 101, 184, 180, 107, 9, 45, 25, 156, 224, 218, 64, 117, 98, 61, 69, 231, 185, 37, 175, 241, 43, 87, 171, 234, 242, 87, 203, 100, 246, 237, 123, 221, 235, 116, 172, 38, 58, 65, 6, 10, 126, 51, 135, 181, 116, 210, 49, 209, 34, 83 }, new byte[] { 58, 75, 225, 195, 230, 87, 223, 137, 60, 227, 111, 107, 32, 33, 30, 133, 204, 16, 252, 133, 43, 235, 88, 241, 38, 125, 208, 166, 185, 147, 82, 149, 129, 136, 40, 149, 77, 17, 10, 142, 241, 176, 229, 139, 153, 45, 187, 104, 149, 169, 140, 132, 128, 82, 160, 130, 175, 221, 68, 191, 32, 51, 134, 234, 188, 102, 57, 39, 145, 54, 129, 64, 137, 86, 85, 181, 204, 147, 0, 35, 208, 122, 92, 105, 206, 18, 120, 184, 0, 184, 250, 130, 216, 19, 4, 192, 194, 220, 44, 162, 10, 250, 236, 150, 101, 148, 67, 48, 160, 75, 151, 86, 107, 92, 14, 213, 1, 111, 81, 109, 132, 126, 69, 4, 50, 120, 26, 211 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd4dd3dc-72e4-42cb-bde3-0fcb1867b10d"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 194, 106, 134, 72, 142, 183, 165, 5, 174, 71, 119, 160, 35, 108, 101, 184, 180, 107, 9, 45, 25, 156, 224, 218, 64, 117, 98, 61, 69, 231, 185, 37, 175, 241, 43, 87, 171, 234, 242, 87, 203, 100, 246, 237, 123, 221, 235, 116, 172, 38, 58, 65, 6, 10, 126, 51, 135, 181, 116, 210, 49, 209, 34, 83 }, new byte[] { 58, 75, 225, 195, 230, 87, 223, 137, 60, 227, 111, 107, 32, 33, 30, 133, 204, 16, 252, 133, 43, 235, 88, 241, 38, 125, 208, 166, 185, 147, 82, 149, 129, 136, 40, 149, 77, 17, 10, 142, 241, 176, 229, 139, 153, 45, 187, 104, 149, 169, 140, 132, 128, 82, 160, 130, 175, 221, 68, 191, 32, 51, 134, 234, 188, 102, 57, 39, 145, 54, 129, 64, 137, 86, 85, 181, 204, 147, 0, 35, 208, 122, 92, 105, 206, 18, 120, 184, 0, 184, 250, 130, 216, 19, 4, 192, 194, 220, 44, 162, 10, 250, 236, 150, 101, 148, 67, 48, 160, 75, 151, 86, 107, 92, 14, 213, 1, 111, 81, 109, 132, 126, 69, 4, 50, 120, 26, 211 } });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("7d9e3a9f-3dc4-45c4-91c1-37c59f4fd8c7"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@borusan.com", new byte[] { 194, 106, 134, 72, 142, 183, 165, 5, 174, 71, 119, 160, 35, 108, 101, 184, 180, 107, 9, 45, 25, 156, 224, 218, 64, 117, 98, 61, 69, 231, 185, 37, 175, 241, 43, 87, 171, 234, 242, 87, 203, 100, 246, 237, 123, 221, 235, 116, 172, 38, 58, 65, 6, 10, 126, 51, 135, 181, 116, 210, 49, 209, 34, 83 }, new byte[] { 58, 75, 225, 195, 230, 87, 223, 137, 60, 227, 111, 107, 32, 33, 30, 133, 204, 16, 252, 133, 43, 235, 88, 241, 38, 125, 208, 166, 185, 147, 82, 149, 129, 136, 40, 149, 77, 17, 10, 142, 241, 176, 229, 139, 153, 45, 187, 104, 149, 169, 140, 132, 128, 82, 160, 130, 175, 221, 68, 191, 32, 51, 134, 234, 188, 102, 57, 39, 145, 54, 129, 64, 137, 86, 85, 181, 204, 147, 0, 35, 208, 122, 92, 105, 206, 18, 120, 184, 0, 184, 250, 130, 216, 19, 4, 192, 194, 220, 44, 162, 10, 250, 236, 150, 101, 148, 67, 48, 160, 75, 151, 86, 107, 92, 14, 213, 1, 111, 81, 109, 132, 126, 69, 4, 50, 120, 26, 211 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("70cf7672-2f94-4025-ae23-d9a876d61037"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("7d9e3a9f-3dc4-45c4-91c1-37c59f4fd8c7") });
        }
    }
}
