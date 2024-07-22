using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EngineConfiguration : IEntityTypeConfiguration<Engine>
{
    public void Configure(EntityTypeBuilder<Engine> builder)
    {
        builder.ToTable("Engines").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.EngineNo).HasColumnName("EngineNo").IsRequired();
        builder.Property(e => e.EngineCapacity).HasColumnName("EngineCapacity").IsRequired();
        builder.Property(e => e.MotorPower).HasColumnName("MotorPower").IsRequired();
        builder.Property(e => e.MaximumTorque).HasColumnName("MaximumTorque").IsRequired();
        builder.Property(e => e.Acceleration).HasColumnName("Acceleration").IsRequired();
        builder.Property(e => e.MaximumSpeed).HasColumnName("MaximumSpeed").IsRequired();
        builder.Property(e => e.FuelTankVolume).HasColumnName("FuelTankVolume").IsRequired();
        builder.Property(e => e.FuelTypeId).HasColumnName("FuelTypeId").IsRequired();
        builder.Property(e => e.FuelConsumptionId).HasColumnName("FuelConsumptionId").IsRequired();
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);

        builder.HasOne(p => p.FuelType).WithMany(p => p.Engines).HasForeignKey(p => p.FuelTypeId);
        builder.HasOne(p => p.FuelConsumption).WithMany(p => p.Engines).HasForeignKey(p => p.FuelConsumptionId);


    }
}