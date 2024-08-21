using Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;
public class CarModelDetailsConfiguration : IEntityTypeConfiguration<CarModelDetailsReadModel>
{
    public void Configure(EntityTypeBuilder<CarModelDetailsReadModel> builder)
    {
        builder.ToView("vm_carmodeldetails").HasNoKey();

        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.ModalExtensionName).HasColumnName("ModelExtensionName");
        builder.Property(p => p.Length).HasColumnName("Length");
        builder.Property(p => p.Width).HasColumnName("Width");
        builder.Property(p => p.Height).HasColumnName("Height");
        builder.Property(p => p.FuelTank).HasColumnName("FuelTank");
        builder.Property(p => p.LuggageCapacity).HasColumnName("LuggageCapacity");
        builder.Property(p => p.EmptyWeight).HasColumnName("EmptyWeight");
        builder.Property(p => p.ModelYear).HasColumnName("ModelYear");

        builder.Property(p => p.CarModelId).HasColumnName("CarModelId");
        builder.Property(p => p.CarModelName).HasColumnName("CarModelName");

        builder.Property(p => p.BrandId).HasColumnName("BrandId");
        builder.Property(p => p.BrandName).HasColumnName("BrandName");
        builder.Property(p => p.BrandLogo).HasColumnName("BrandLogo");

        builder.Property(p => p.GenerationId).HasColumnName("GenerationId");
        builder.Property(p => p.GenerationName).HasColumnName("GenerationName");

        builder.Property(p => p.EngineId).HasColumnName("EngineId");
        builder.Property(p => p.EngineNo).HasColumnName("EngineNo");
        builder.Property(p => p.EngineCapacity).HasColumnName("EngineCapacity");
        builder.Property(p => p.MotorPower).HasColumnName("MotorPower");
        builder.Property(p => p.MaximumTorque).HasColumnName("MaximumTorque");
        builder.Property(p => p.Acceleration).HasColumnName("Acceleration");
        builder.Property(p => p.MaximumSpeed).HasColumnName("MaximumSpeed");
        builder.Property(p => p.FuelTankVolume).HasColumnName("FuelTankVolume");
        builder.Property(p => p.OutOfTownConsumptionRate).HasColumnName("OutOfTownConsumptionRate");
        builder.Property(p => p.UrbanConsumptionRate).HasColumnName("UrbanConsumptionRate");
        builder.Property(p => p.AverageConsumptionRate).HasColumnName("AverageConsumptionRate");

        builder.Property(p => p.FuelTypeName).HasColumnName("FuelTypeName");

        builder.Property(p => p.BodyTypeId).HasColumnName("BodyTypeId");
        builder.Property(p => p.BodyTypeName).HasColumnName("BodyTypeName");
        builder.Property(p => p.BodyTypeDoor).HasColumnName("BodyTypeDoor");

        builder.Property(p => p.TransmissionId).HasColumnName("TransmissionId");
        builder.Property(p => p.TransmissionName).HasColumnName("TransmissionName");

    }
}
