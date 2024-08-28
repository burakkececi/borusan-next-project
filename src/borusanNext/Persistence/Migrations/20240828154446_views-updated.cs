using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class viewsupdated : Migration
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
                    s.""AddressId"" AS ""Seller_AddressId"",
                    s.""Latitute"" AS ""Seller_Latitude"",
                    s.""Longitute"" AS ""Seller_Longitude"",
                    s.""LicenceNo"" AS ""Seller_LicenceNo"",
                    s.""ProvidedBy"" AS ""Seller_ProvidedBy"",
                    s.""AddressLine"" AS ""Seller_AddressLine"",
                    sa.""City"" AS ""Seller_City"",
                    sa.""District"" AS ""Seller_District""
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
                    LEFT JOIN ""Addresses"" sa ON s.""AddressId"" = sa.""Id""
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
                keyValue: new Guid("5f72a330-a581-4b88-92bc-b93e42dc82bc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("784f958c-a60b-4805-af3b-7c219a7a953f"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36160d4c-8a2a-4959-9769-ebf2bd812237"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 160, 165, 76, 88, 136, 171, 91, 201, 145, 174, 68, 151, 240, 113, 193, 47, 67, 243, 39, 197, 198, 9, 4, 195, 236, 150, 247, 6, 236, 220, 144, 39, 65, 117, 230, 177, 70, 217, 219, 49, 137, 202, 173, 224, 160, 249, 108, 108, 134, 179, 72, 84, 98, 132, 199, 224, 214, 134, 244, 43, 158, 194, 53, 92 }, new byte[] { 42, 122, 49, 55, 2, 69, 88, 235, 117, 93, 49, 211, 252, 167, 224, 130, 1, 58, 57, 66, 96, 180, 19, 10, 204, 36, 61, 175, 55, 8, 140, 178, 190, 37, 101, 250, 229, 158, 23, 2, 147, 77, 117, 162, 31, 10, 242, 58, 227, 72, 255, 17, 202, 130, 74, 35, 7, 200, 167, 32, 217, 223, 242, 128, 63, 238, 210, 121, 8, 177, 155, 230, 7, 187, 199, 68, 160, 130, 211, 95, 51, 27, 95, 53, 75, 183, 203, 140, 187, 206, 132, 134, 130, 169, 59, 78, 194, 253, 202, 196, 251, 124, 136, 132, 38, 183, 236, 188, 150, 200, 90, 192, 165, 27, 92, 68, 144, 198, 119, 3, 196, 186, 75, 152, 221, 56, 229, 50 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("398b5d31-f2e2-473f-8f40-78f7e79af217"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 160, 165, 76, 88, 136, 171, 91, 201, 145, 174, 68, 151, 240, 113, 193, 47, 67, 243, 39, 197, 198, 9, 4, 195, 236, 150, 247, 6, 236, 220, 144, 39, 65, 117, 230, 177, 70, 217, 219, 49, 137, 202, 173, 224, 160, 249, 108, 108, 134, 179, 72, 84, 98, 132, 199, 224, 214, 134, 244, 43, 158, 194, 53, 92 }, new byte[] { 42, 122, 49, 55, 2, 69, 88, 235, 117, 93, 49, 211, 252, 167, 224, 130, 1, 58, 57, 66, 96, 180, 19, 10, 204, 36, 61, 175, 55, 8, 140, 178, 190, 37, 101, 250, 229, 158, 23, 2, 147, 77, 117, 162, 31, 10, 242, 58, 227, 72, 255, 17, 202, 130, 74, 35, 7, 200, 167, 32, 217, 223, 242, 128, 63, 238, 210, 121, 8, 177, 155, 230, 7, 187, 199, 68, 160, 130, 211, 95, 51, 27, 95, 53, 75, 183, 203, 140, 187, 206, 132, 134, 130, 169, 59, 78, 194, 253, 202, 196, 251, 124, 136, 132, 38, 183, 236, 188, 150, 200, 90, 192, 165, 27, 92, 68, 144, 198, 119, 3, 196, 186, 75, 152, 221, 56, 229, 50 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6444d306-ab8e-4e84-a6ff-77037d68fd2e"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 160, 165, 76, 88, 136, 171, 91, 201, 145, 174, 68, 151, 240, 113, 193, 47, 67, 243, 39, 197, 198, 9, 4, 195, 236, 150, 247, 6, 236, 220, 144, 39, 65, 117, 230, 177, 70, 217, 219, 49, 137, 202, 173, 224, 160, 249, 108, 108, 134, 179, 72, 84, 98, 132, 199, 224, 214, 134, 244, 43, 158, 194, 53, 92 }, new byte[] { 42, 122, 49, 55, 2, 69, 88, 235, 117, 93, 49, 211, 252, 167, 224, 130, 1, 58, 57, 66, 96, 180, 19, 10, 204, 36, 61, 175, 55, 8, 140, 178, 190, 37, 101, 250, 229, 158, 23, 2, 147, 77, 117, 162, 31, 10, 242, 58, 227, 72, 255, 17, 202, 130, 74, 35, 7, 200, 167, 32, 217, 223, 242, 128, 63, 238, 210, 121, 8, 177, 155, 230, 7, 187, 199, 68, 160, 130, 211, 95, 51, 27, 95, 53, 75, 183, 203, 140, 187, 206, 132, 134, 130, 169, 59, 78, 194, 253, 202, 196, 251, 124, 136, 132, 38, 183, 236, 188, 150, 200, 90, 192, 165, 27, 92, 68, 144, 198, 119, 3, 196, 186, 75, 152, 221, 56, 229, 50 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd8e0f-59d4-4532-ae32-03cec3e39158"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 160, 165, 76, 88, 136, 171, 91, 201, 145, 174, 68, 151, 240, 113, 193, 47, 67, 243, 39, 197, 198, 9, 4, 195, 236, 150, 247, 6, 236, 220, 144, 39, 65, 117, 230, 177, 70, 217, 219, 49, 137, 202, 173, 224, 160, 249, 108, 108, 134, 179, 72, 84, 98, 132, 199, 224, 214, 134, 244, 43, 158, 194, 53, 92 }, new byte[] { 42, 122, 49, 55, 2, 69, 88, 235, 117, 93, 49, 211, 252, 167, 224, 130, 1, 58, 57, 66, 96, 180, 19, 10, 204, 36, 61, 175, 55, 8, 140, 178, 190, 37, 101, 250, 229, 158, 23, 2, 147, 77, 117, 162, 31, 10, 242, 58, 227, 72, 255, 17, 202, 130, 74, 35, 7, 200, 167, 32, 217, 223, 242, 128, 63, 238, 210, 121, 8, 177, 155, 230, 7, 187, 199, 68, 160, 130, 211, 95, 51, 27, 95, 53, 75, 183, 203, 140, 187, 206, 132, 134, 130, 169, 59, 78, 194, 253, 202, 196, 251, 124, 136, 132, 38, 183, 236, 188, 150, 200, 90, 192, 165, 27, 92, 68, 144, 198, 119, 3, 196, 186, 75, 152, 221, 56, 229, 50 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ada31c5d-6014-46d2-a1c3-ed8007e898cf"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 160, 165, 76, 88, 136, 171, 91, 201, 145, 174, 68, 151, 240, 113, 193, 47, 67, 243, 39, 197, 198, 9, 4, 195, 236, 150, 247, 6, 236, 220, 144, 39, 65, 117, 230, 177, 70, 217, 219, 49, 137, 202, 173, 224, 160, 249, 108, 108, 134, 179, 72, 84, 98, 132, 199, 224, 214, 134, 244, 43, 158, 194, 53, 92 }, new byte[] { 42, 122, 49, 55, 2, 69, 88, 235, 117, 93, 49, 211, 252, 167, 224, 130, 1, 58, 57, 66, 96, 180, 19, 10, 204, 36, 61, 175, 55, 8, 140, 178, 190, 37, 101, 250, 229, 158, 23, 2, 147, 77, 117, 162, 31, 10, 242, 58, 227, 72, 255, 17, 202, 130, 74, 35, 7, 200, 167, 32, 217, 223, 242, 128, 63, 238, 210, 121, 8, 177, 155, 230, 7, 187, 199, 68, 160, 130, 211, 95, 51, 27, 95, 53, 75, 183, 203, 140, 187, 206, 132, 134, 130, 169, 59, 78, 194, 253, 202, 196, 251, 124, 136, 132, 38, 183, 236, 188, 150, 200, 90, 192, 165, 27, 92, 68, 144, 198, 119, 3, 196, 186, 75, 152, 221, 56, 229, 50 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b73f6541-460e-4d9d-97eb-1402f63df038"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 160, 165, 76, 88, 136, 171, 91, 201, 145, 174, 68, 151, 240, 113, 193, 47, 67, 243, 39, 197, 198, 9, 4, 195, 236, 150, 247, 6, 236, 220, 144, 39, 65, 117, 230, 177, 70, 217, 219, 49, 137, 202, 173, 224, 160, 249, 108, 108, 134, 179, 72, 84, 98, 132, 199, 224, 214, 134, 244, 43, 158, 194, 53, 92 }, new byte[] { 42, 122, 49, 55, 2, 69, 88, 235, 117, 93, 49, 211, 252, 167, 224, 130, 1, 58, 57, 66, 96, 180, 19, 10, 204, 36, 61, 175, 55, 8, 140, 178, 190, 37, 101, 250, 229, 158, 23, 2, 147, 77, 117, 162, 31, 10, 242, 58, 227, 72, 255, 17, 202, 130, 74, 35, 7, 200, 167, 32, 217, 223, 242, 128, 63, 238, 210, 121, 8, 177, 155, 230, 7, 187, 199, 68, 160, 130, 211, 95, 51, 27, 95, 53, 75, 183, 203, 140, 187, 206, 132, 134, 130, 169, 59, 78, 194, 253, 202, 196, 251, 124, 136, 132, 38, 183, 236, 188, 150, 200, 90, 192, 165, 27, 92, 68, 144, 198, 119, 3, 196, 186, 75, 152, 221, 56, 229, 50 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd4dd3dc-72e4-42cb-bde3-0fcb1867b10d"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 160, 165, 76, 88, 136, 171, 91, 201, 145, 174, 68, 151, 240, 113, 193, 47, 67, 243, 39, 197, 198, 9, 4, 195, 236, 150, 247, 6, 236, 220, 144, 39, 65, 117, 230, 177, 70, 217, 219, 49, 137, 202, 173, 224, 160, 249, 108, 108, 134, 179, 72, 84, 98, 132, 199, 224, 214, 134, 244, 43, 158, 194, 53, 92 }, new byte[] { 42, 122, 49, 55, 2, 69, 88, 235, 117, 93, 49, 211, 252, 167, 224, 130, 1, 58, 57, 66, 96, 180, 19, 10, 204, 36, 61, 175, 55, 8, 140, 178, 190, 37, 101, 250, 229, 158, 23, 2, 147, 77, 117, 162, 31, 10, 242, 58, 227, 72, 255, 17, 202, 130, 74, 35, 7, 200, 167, 32, 217, 223, 242, 128, 63, 238, 210, 121, 8, 177, 155, 230, 7, 187, 199, 68, 160, 130, 211, 95, 51, 27, 95, 53, 75, 183, 203, 140, 187, 206, 132, 134, 130, 169, 59, 78, 194, 253, 202, 196, 251, 124, 136, 132, 38, 183, 236, 188, 150, 200, 90, 192, 165, 27, 92, 68, 144, 198, 119, 3, 196, 186, 75, 152, 221, 56, 229, 50 } });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "Provider", "UpdatedDate" },
                values: new object[] { new Guid("36c92202-8530-43ff-8ea1-f04ab132c569"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@borusan.com", new byte[] { 160, 165, 76, 88, 136, 171, 91, 201, 145, 174, 68, 151, 240, 113, 193, 47, 67, 243, 39, 197, 198, 9, 4, 195, 236, 150, 247, 6, 236, 220, 144, 39, 65, 117, 230, 177, 70, 217, 219, 49, 137, 202, 173, 224, 160, 249, 108, 108, 134, 179, 72, 84, 98, 132, 199, 224, 214, 134, 244, 43, 158, 194, 53, 92 }, new byte[] { 42, 122, 49, 55, 2, 69, 88, 235, 117, 93, 49, 211, 252, 167, 224, 130, 1, 58, 57, 66, 96, 180, 19, 10, 204, 36, 61, 175, 55, 8, 140, 178, 190, 37, 101, 250, 229, 158, 23, 2, 147, 77, 117, 162, 31, 10, 242, 58, 227, 72, 255, 17, 202, 130, 74, 35, 7, 200, 167, 32, 217, 223, 242, 128, 63, 238, 210, 121, 8, 177, 155, 230, 7, 187, 199, 68, 160, 130, 211, 95, 51, 27, 95, 53, 75, 183, 203, 140, 187, 206, 132, 134, 130, 169, 59, 78, 194, 253, 202, 196, 251, 124, 136, 132, 38, 183, 236, 188, 150, 200, 90, 192, 165, 27, 92, 68, 144, 198, 119, 3, 196, 186, 75, 152, 221, 56, 229, 50 }, 0, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("62c8a9db-7fff-4662-80e8-62630595fa91"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("36c92202-8530-43ff-8ea1-f04ab132c569") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS vm_AdvertDetails;");
            migrationBuilder.Sql("DROP VIEW IF EXISTS vm_CarModelDetails;");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("62c8a9db-7fff-4662-80e8-62630595fa91"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36c92202-8530-43ff-8ea1-f04ab132c569"));

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
        }
    }
}
