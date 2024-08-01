using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.ChassisNumber).HasColumnName("ChassisNumber").IsRequired();
        builder.Property(c => c.Plate).HasColumnName("Plate").IsRequired();
        builder.Property(c => c.Kilometers).HasColumnName("Kilometers").IsRequired();
        builder.Property(c => c.SpareKey).HasColumnName("SpareKey").IsRequired();
        builder.Property(c => c.Inquiry).HasColumnName("Inquiry").IsRequired();
        builder.Property(c => c.WheelType).HasColumnName("WheelType").IsRequired();
        builder.Property(c => c.SpareWheel).HasColumnName("SpareWheel").IsRequired();
        builder.Property(c => c.Price).HasColumnName("Price").HasPrecision(18,2).IsRequired();
        builder.Property(c => c.CarModelId).HasColumnName("CarModelId").IsRequired();
        builder.Property(c => c.ColorId).HasColumnName("ColorId").IsRequired();
        builder.Property(c => c.EngineId).HasColumnName("EngineId").IsRequired();
        builder.Property(c => c.BodyTypeId).HasColumnName("BodyTypeId").IsRequired();
        builder.Property(c => c.TransmissionId).HasColumnName("TransmissionId").IsRequired();
        builder.Property(c => c.TramerId).HasColumnName("TramerId").IsRequired();
        builder.Property(c => c.SellerId).HasColumnName("SellerId").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasOne(p => p.ExpertizeResult).WithOne(p => p.Car).HasForeignKey<Car>(p => p.TramerId);
        builder.HasOne(p => p.CarModel).WithMany(p => p.Cars).HasForeignKey(p => p.CarModelId);
        builder.HasOne(p => p.Engine).WithMany(p => p.Cars).HasForeignKey(p => p.EngineId);
        builder.HasOne(p => p.BodyType).WithMany(p => p.Cars).HasForeignKey(p => p.BodyTypeId);
        builder.HasOne(p => p.Transmission).WithMany(p => p.Cars).HasForeignKey(p => p.TransmissionId);
        builder.HasOne(p => p.Color).WithMany(p => p.Cars).HasForeignKey(p => p.ColorId);
        builder.HasOne(p => p.Seller).WithMany(p => p.Cars).HasForeignKey(p => p.SellerId);
    }
}