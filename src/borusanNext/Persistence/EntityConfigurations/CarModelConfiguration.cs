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
        builder.Property(cm => cm.ModelName).HasColumnName("ModelName").IsRequired();
        builder.Property(cm => cm.BrandId).HasColumnName("BrandId").IsRequired();
        builder.Property(cm => cm.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(cm => cm.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(cm => cm.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(cm => !cm.DeletedDate.HasValue);
        builder.HasOne(p => p.Brand).WithMany(p => p.CarModels).HasForeignKey(p => p.BrandId);
    }
}