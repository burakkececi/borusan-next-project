using Domain.Entities;
using Domain.Enums;

namespace Application.Models;
public class AdvertDetailsReadModel
{
    public Guid AdvertId { get; set; }
    public int AdvertNo { get; set; }

    public Guid CarId { get; set; }
    public string ChassisNumber { get; set; }
    public string Plate { get; set; }
    public int Kilometers { get; set; }
    public bool SpareKey { get; set; }
    public DateTime Inquiry { get; set; }
    public string WheelType { get; set; }
    public bool SpareWheel { get; set; }
    public decimal Price { get; set; }

    public Guid ModalExtensionId { get; set; }
    public string ModalExtension_Name { get; set; }
    public double ModalExtension_Length { get; set; }
    public double ModalExtension_Width { get; set; }
    public double ModalExtension_Height { get; set; }
    public double ModalExtension_FuelTank { get; set; }
    public double ModalExtension_LuggageCapacity { get; set; }
    public double ModalExtension_EmptyWeight { get; set; }
    public int ModalExtension_ModelYear { get; set; }

    public Guid CarModelId { get; set; }
    public string CarModel_Name { get; set; }

    public Guid BrandId { get; set; }
    public string Brand_Name { get; set; }
    public string Brand_Logo { get; set; }

    public Guid GenerationId { get; set; }
    public string Generation_Name { get; set; }

    public Guid EngineId { get; set; }
    public string Engine_EngineNo { get; set; }
    public int Engine_EngineCapacity { get; set; }
    public int Engine_MotorPower { get; set; }
    public int Engine_MaximumTorque { get; set; }
    public double Engine_Acceleration { get; set; }
    public int Engine_MaximumSpeed { get; set; }
    public int Engine_FuelTankVolume { get; set; }
    public double Engine_OutOfTownConsumptionRate { get; set; }
    public double Engine_UrbanConsumptionRate { get; set; }
    public double Engine_AverageConsumptionRate { get; set; }

    public Guid FuelTypeId { get; set; }
    public string FuelType_Name { get; set; }

    public Guid ColorId { get; set; }
    public string Color_Name { get; set; }

    public Guid BodyTypeId { get; set; }
    public string BodyType_Name { get; set; }
    public string BodyType_Door { get; set; }

    public Guid TransmissionId { get; set; }
    public string Transmission_Name { get; set; }

    public Guid TramerId { get; set; }
    public int CarDamageInformationRecord { get; set; }
    public DateTime InquiryDate { get; set; }

    public Guid ChassisPartId { get; set; }
    public bool ChassisPart_IsRightChassisChanged { get; set; }
    public bool ChassisPart_IsLeftChassisChanged { get; set; }
    public bool ChassisPart_IsFrontPanelChanged { get; set; }
    public bool ChassisPart_IsBackPanelChanged { get; set; }

    public Guid BodyShellPartId { get; set; }
    public ExpertizeCondition BodyShellPart_LeftFrontFender { get; set; }
    public ExpertizeCondition BodyShellPart_LeftFrontDoor { get; set; }
    public ExpertizeCondition BodyShellPart_LeftRearDoor { get; set; }
    public ExpertizeCondition BodyShellPart_LeftRearFender { get; set; }
    public ExpertizeCondition BodyShellPart_RightFrontFender { get; set; }
    public ExpertizeCondition BodyShellPart_RightFrontDoor { get; set; }
    public ExpertizeCondition BodyShellPart_RightRearDoor { get; set; }
    public ExpertizeCondition BodyShellPart_RightRearFender { get; set; }
    public ExpertizeCondition BodyShellPart_FrontBumper { get; set; }
    public ExpertizeCondition BodyShellPart_RearBumper { get; set; }
    public ExpertizeCondition BodyShellPart_Bonnet { get; set; }
    public ExpertizeCondition BodyShellPart_Ceiling { get; set; }
    public ExpertizeCondition BodyShellPart_Luggage { get; set; }

    public Guid SellerId { get; set; }
    public string Seller_Name { get; set; }
    public string Seller_PhoneNumber { get; set; }

    public Guid LicenceId { get; set; }
    public int Licence_LicenceNo { get; set; }
    public string Licence_ProvidedBy { get; set; }

    public Guid LocationId { get; set; }
    public string Location_City { get; set; }
    public string Location_Address { get; set; }
    public string Location_Latitute { get; set; }
    public string Location_Longitute { get; set; }
}
