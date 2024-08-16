using Domain.Entities;
using Domain.Enums;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Cars.Queries.GetList;

public class GetListCarListItemDto : IDto
{
    public Guid Id { get; set; }
    public string ChassisNumber { get; set; }
    public string Plate { get; set; }
    public int Kilometers { get; set; }
    public bool SpareKey { get; set; }
    public DateTime Inquiry { get; set; }
    public string WheelType { get; set; }
    public bool SpareWheel { get; set; }
    public decimal Price { get; set; }

    public Guid BrandId { get; set; }
    public string BrandName { get; set; }
    public string BrandLogo { get; set; }

    public Guid GenerationId { get; set; }
    public string GenerationName { get; set; }

    public Guid ModalExtensionId { get; set; }
    public string ModalExtensionName { get; set; }
    public double ModalExtensionLenght { get; set; }
    public double ModalExtensionWidth { get; set; }
    public double ModalExtensionHeight { get; set; }
    public double ModalExtensionFuelTank { get; set; }
    public double ModalExtensionLuggageCapacity { get; set; }
    public double ModalExtensionEmptyWeight { get; set; }
    public int ModalExtensionModelYear { get; set; }

    public Guid CarModelId { get; set; }
    public string CarModelName { get; set; }

    public Guid ColorId { get; set; }
    public string ColorName { get; set; }

    public Guid EngineId { get; set; }
    public string EngineNo { get; set; }
    public int EngineCapacity { get; set; }
    public int EngineMotorPower { get; set; }
    public int EngineMaximumTorque { get; set; }
    public double EngineAcceleration { get; set; }
    public int EngineMaximumSpeed { get; set; }
    public int EngineFuelTankVolume { get; set; }
    public double EngineOutOfTownConsumptionRate { get; set; }
    public double EngineUrbanConsumptionRate { get; set; }
    public double EngineAverageConsumptionRate { get; set; }
    public Guid FuelTypeId { get; set; }
    public string FuelTypeName { get; set; }

    public Guid BodyTypeId { get; set; }
    public string BodyTypeBodyName { get; set; }
    public string BodyTypeDoor { get; set; }

    public Guid TransmissionId { get; set; }
    public string TransmissionName { get; set; }

    public Guid ExpertizeResultId { get; set; }
    public int ExpertizeResultCarDamageInformationRecord { get; set; }
    public DateTime ExpertizeResultInquiryDate { get; set; }
    public Guid ExpertizeResultChassisPartId { get; set; }
    public Guid ExpertizeResultBodyShellPartId { get; set; }
    public bool ChassisPartIsRightChassisChanged { get; set; }
    public bool ChassisPartIsLeftChassisChanged { get; set; }
    public bool ChassisPartIsFrontPanelChanged { get; set; }
    public bool ChassisPartIsBackPanelChanged { get; set; }
    public ExpertizeCondition BodyShellPartLeftFrontFender { get; set; }
    public ExpertizeCondition BodyShellPartLeftFrontDoor { get; set; }
    public ExpertizeCondition BodyShellPartLeftRearDoor { get; set; }
    public ExpertizeCondition BodyShellPartLeftRearFender { get; set; }
    public ExpertizeCondition BodyShellPartRightFrontFender { get; set; }
    public ExpertizeCondition BodyShellPartRightFrontDoor { get; set; }
    public ExpertizeCondition BodyShellPartRightRearDoor { get; set; }
    public ExpertizeCondition BodyShellPartRightRearFender { get; set; }
    public ExpertizeCondition BodyShellPartFrontbumper { get; set; }
    public ExpertizeCondition BodyShellPartRearBumper { get; set; }
    public ExpertizeCondition BodyShellPartBonnet { get; set; }
    public ExpertizeCondition BodyShellPartCeiling { get; set; }
    public ExpertizeCondition BodyShellPartLuggage { get; set; }

    public Guid SellerId { get; set; }
    public Guid SellerUserId { get; set; }
    public string SellerName { get; set; }
    public string SellerPhoneNumber { get; set; }
    public Guid SellerLicenceId { get; set; }
    public Guid SellerLocationId { get; set; }
    public int LicenceLicenceNo { get; set; }
    public string LicenceProvidedBy { get; set; }
    public string LocationCity { get; set; }
    public string LocationAddress { get; set; }
    public string LocationLatitute { get; set; }
    public string LocationLongitute { get; set; }

}