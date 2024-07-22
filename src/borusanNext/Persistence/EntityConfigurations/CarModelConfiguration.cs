using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
{
    public void Configure(EntityTypeBuilder<CarModel> builder)
    {
        builder.ToTable("CarModels").HasKey(cm => cm.Id);

        builder.Property(cm => cm.Id).HasColumnName("Id").IsRequired();
        builder.Property(cm => cm.BrandId).HasColumnName("BrandId").IsRequired();
        builder.Property(cm => cm.ModelName).HasColumnName("ModelName").IsRequired();
        builder.Property(cm => cm.Lenght).HasColumnName("Lenght").IsRequired();
        builder.Property(cm => cm.Width).HasColumnName("Width").IsRequired();
        builder.Property(cm => cm.Height).HasColumnName("Height").IsRequired();
        builder.Property(cm => cm.FuelTank).HasColumnName("FuelTank").IsRequired();
        builder.Property(cm => cm.LuggageCapacity).HasColumnName("LuggageCapacity").IsRequired();
        builder.Property(cm => cm.EmptyWeight).HasColumnName("EmptyWeight").IsRequired();
        builder.Property(cm => cm.ModelYear).HasColumnName("ModelYear").IsRequired();
        builder.Property(cm => cm.CarId).HasColumnName("CarId").IsRequired();
        builder.Property(cm => cm.ModalExtensionId).HasColumnName("ModalExtensionId").IsRequired();
        builder.Property(cm => cm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cm => cm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cm => cm.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cm => !cm.DeletedDate.HasValue);
    }
}