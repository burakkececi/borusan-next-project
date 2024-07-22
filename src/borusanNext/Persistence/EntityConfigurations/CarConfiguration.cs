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
        builder.Property(c => c.Price).HasColumnName("Price").IsRequired();
        builder.Property(c => c.CarModelId).HasColumnName("CarModelId").IsRequired();
        builder.Property(c => c.ColorId).HasColumnName("ColorId").IsRequired();
        builder.Property(c => c.EngineId).HasColumnName("EngineId").IsRequired();
        builder.Property(c => c.BodyTypeId).HasColumnName("BodyTypeId").IsRequired();
        builder.Property(c => c.TransmissionId).HasColumnName("TransmissionId").IsRequired();
        builder.Property(c => c.TramerId).HasColumnName("TramerId").IsRequired();
        builder.Property(c => c.AdvertId).HasColumnName("AdvertId").IsRequired();
        builder.Property(c => c.SellerId).HasColumnName("SellerId").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}