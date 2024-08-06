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
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);

        builder.HasOne(p => p.FuelType).WithMany(p => p.Engines).HasForeignKey(p => p.FuelTypeId);

        builder.HasData(
            new Engine()
            {
                Id = new Guid("12f9441e-92f2-4333-9e55-b1131c1bfde3"),
                EngineNo = "ENG123456789",
                EngineCapacity = 2000,
                MotorPower = 250,
                MaximumTorque = 350,
                Acceleration = 5.5,
                MaximumSpeed = 240,
                FuelTankVolume = 60,
                OutOfTownConsumptionRate = 3.4,
                UrbanConsumptionRate = 2.8,
                AverageConsumptionRate = 3.0,
                FuelTypeId = new Guid("55126902-8144-4e5a-9b4f-06cc32304d57"),
            },
            new Engine()
            {
                Id = new Guid("f235cb8f-559a-4659-8bba-8fba8b0737d6"),
                EngineNo = "ENG987654321",
                EngineCapacity = 1500,
                MotorPower = 180,
                MaximumTorque = 250,
                Acceleration = 7.0,
                MaximumSpeed = 220,
                FuelTankVolume = 50,
                OutOfTownConsumptionRate = 3.4,
                UrbanConsumptionRate = 3.0,
                AverageConsumptionRate = 3.2,
                FuelTypeId = new Guid("5e44df51-9db5-46cc-b9ab-7c64a491e2fe"),
            },
            new Engine()
            {
                Id = new Guid("0106e5db-0b88-4231-9cc0-263868fb5c01"),
                EngineNo = "ENG456789123",
                EngineCapacity = 1800,
                MotorPower = 200,
                MaximumTorque = 300,
                Acceleration = 6.0,
                MaximumSpeed = 230,
                FuelTankVolume = 55,
                OutOfTownConsumptionRate = 3.5,
                UrbanConsumptionRate = 2.9,
                AverageConsumptionRate = 3.1,
                FuelTypeId = new Guid("7c27ae08-d686-43b7-9fc2-5a9df75963de"),
            }
            );
    }
}