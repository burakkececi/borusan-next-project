using Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;
public class AdvertDetailsConfiguration : IEntityTypeConfiguration<AdvertDetailsReadModel>
{
    public void Configure(EntityTypeBuilder<AdvertDetailsReadModel> builder)
    {
        builder.ToView("vm_advertdetails").HasNoKey();

        builder.Property(p => p.AdvertId).HasColumnName("AdvertId");
        builder.Property(p => p.AdvertNo).HasColumnName("AdvertNo");

        builder.Property(p => p.CarId).HasColumnName("CarId");
        builder.Property(p => p.ChassisNumber).HasColumnName("ChassisNumber");
        builder.Property(p => p.Plate).HasColumnName("Plate");
        builder.Property(p => p.Kilometers).HasColumnName("Kilometers");
        builder.Property(p => p.SpareKey).HasColumnName("SpareKey");
        builder.Property(p => p.Inquiry).HasColumnName("Inquiry");
        builder.Property(p => p.WheelType).HasColumnName("WheelType");
        builder.Property(p => p.SpareWheel).HasColumnName("SpareWheel");
        builder.Property(p => p.Price).HasColumnName("Price");

        builder.Property(p => p.ModalExtensionId).HasColumnName("ModalExtensionId");
        builder.Property(p => p.ModalExtension_Name).HasColumnName("ModalExtension_Name");
        builder.Property(p => p.ModalExtension_Length).HasColumnName("ModalExtension_Length");
        builder.Property(p => p.ModalExtension_Width).HasColumnName("ModalExtension_Width");
        builder.Property(p => p.ModalExtension_Height).HasColumnName("ModalExtension_Height");
        builder.Property(p => p.ModalExtension_FuelTank).HasColumnName("ModalExtension_FuelTank");
        builder.Property(p => p.ModalExtension_LuggageCapacity).HasColumnName("ModalExtension_LuggageCapacity");
        builder.Property(p => p.ModalExtension_EmptyWeight).HasColumnName("ModalExtension_EmptyWeight");
        builder.Property(p => p.ModalExtension_ModelYear).HasColumnName("ModalExtension_ModelYear");

        builder.Property(p => p.CarModelId).HasColumnName("CarModelId");
        builder.Property(p => p.CarModel_Name).HasColumnName("CarModel_Name");

        builder.Property(p => p.BrandId).HasColumnName("BrandId");
        builder.Property(p => p.Brand_Name).HasColumnName("Brand_Name");
        builder.Property(p => p.Brand_Logo).HasColumnName("Brand_Logo");

        builder.Property(p => p.GenerationId).HasColumnName("GenerationId");
        builder.Property(p => p.Generation_Name).HasColumnName("Generation_Name");

        builder.Property(p => p.EngineId).HasColumnName("EngineId");
        builder.Property(p => p.Engine_EngineNo).HasColumnName("Engine_EngineNo");
        builder.Property(p => p.Engine_EngineCapacity).HasColumnName("Engine_EngineCapacity");
        builder.Property(p => p.Engine_MotorPower).HasColumnName("Engine_MotorPower");
        builder.Property(p => p.Engine_MaximumTorque).HasColumnName("Engine_MaximumTorque");
        builder.Property(p => p.Engine_Acceleration).HasColumnName("Engine_Acceleration");
        builder.Property(p => p.Engine_MaximumSpeed).HasColumnName("Engine_MaximumSpeed");
        builder.Property(p => p.Engine_FuelTankVolume).HasColumnName("Engine_FuelTankVolume");
        builder.Property(p => p.Engine_OutOfTownConsumptionRate).HasColumnName("Engine_OutOfTownConsumptionRate");
        builder.Property(p => p.Engine_UrbanConsumptionRate).HasColumnName("Engine_UrbanConsumptionRate");
        builder.Property(p => p.Engine_AverageConsumptionRate).HasColumnName("Engine_AverageConsumptionRate");

        builder.Property(p => p.FuelTypeId).HasColumnName("FuelTypeId");
        builder.Property(p => p.FuelType_Name).HasColumnName("FuelType_Name");

        builder.Property(p => p.ColorId).HasColumnName("ColorId");
        builder.Property(p => p.Color_Name).HasColumnName("Color_Name");

        builder.Property(p => p.BodyTypeId).HasColumnName("BodyTypeId");
        builder.Property(p => p.BodyType_Name).HasColumnName("BodyType_Name");
        builder.Property(p => p.BodyType_Door).HasColumnName("BodyType_Door");

        builder.Property(p => p.TransmissionId).HasColumnName("TransmissionId");
        builder.Property(p => p.Transmission_Name).HasColumnName("Transmission_Name");

        builder.Property(p => p.TramerId).HasColumnName("TramerId");
        builder.Property(p => p.CarDamageInformationRecord).HasColumnName("CarDamageInformationRecord");
        builder.Property(p => p.InquiryDate).HasColumnName("InquiryDate");

        builder.Property(p => p.ChassisPartId).HasColumnName("ChassisPartId");
        builder.Property(p => p.ChassisPart_IsRightChassisChanged).HasColumnName("ChassisPart_IsRightChassisChanged");
        builder.Property(p => p.ChassisPart_IsLeftChassisChanged).HasColumnName("ChassisPart_IsLeftChassisChanged");
        builder.Property(p => p.ChassisPart_IsFrontPanelChanged).HasColumnName("ChassisPart_IsFrontPanelChanged");
        builder.Property(p => p.ChassisPart_IsBackPanelChanged).HasColumnName("ChassisPart_IsBackPanelChanged");

        builder.Property(p => p.BodyShellPartId).HasColumnName("BodyShellPartId");
        builder.Property(p => p.BodyShellPart_LeftFrontFender).HasColumnName("BodyShellPart_LeftFrontFender");
        builder.Property(p => p.BodyShellPart_LeftFrontDoor).HasColumnName("BodyShellPart_LeftFrontDoor");
        builder.Property(p => p.BodyShellPart_LeftRearDoor).HasColumnName("BodyShellPart_LeftRearDoor");
        builder.Property(p => p.BodyShellPart_LeftRearFender).HasColumnName("BodyShellPart_LeftRearFender");
        builder.Property(p => p.BodyShellPart_RightFrontFender).HasColumnName("BodyShellPart_RightFrontFender");
        builder.Property(p => p.BodyShellPart_RightFrontDoor).HasColumnName("BodyShellPart_RightFrontDoor");
        builder.Property(p => p.BodyShellPart_RightRearDoor).HasColumnName("BodyShellPart_RightRearDoor");
        builder.Property(p => p.BodyShellPart_RightRearFender).HasColumnName("BodyShellPart_RightRearFender");
        builder.Property(p => p.BodyShellPart_FrontBumper).HasColumnName("BodyShellPart_FrontBumper");
        builder.Property(p => p.BodyShellPart_RearBumper).HasColumnName("BodyShellPart_RearBumper");
        builder.Property(p => p.BodyShellPart_Bonnet).HasColumnName("BodyShellPart_Bonnet");
        builder.Property(p => p.BodyShellPart_Ceiling).HasColumnName("BodyShellPart_Ceiling");
        builder.Property(p => p.BodyShellPart_Luggage).HasColumnName("BodyShellPart_Luggage");

        builder.Property(p => p.SellerId).HasColumnName("SellerId");
        builder.Property(p => p.Seller_Name).HasColumnName("Seller_Name");
        builder.Property(p => p.Seller_PhoneNumber).HasColumnName("Seller_PhoneNumber");

    }
}
