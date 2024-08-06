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

        builder.HasData(
                new CarModel()
                {
                    Id = new Guid("86a6edf9-745f-4a0f-9413-110b4cd6bfb6"),
                    ModelName = "520i",
                    BrandId = new Guid("c571076a-f830-4682-bfb3-5ca69537ee41"),
                },
                new CarModel()
                {
                    Id = new Guid("534e852f-1bcf-4ae3-9ae4-4b5976bdfd87"),
                    ModelName = "Range Rover",
                    BrandId = new Guid("0f1e4581-6b0b-4b9f-a4ab-3b292c082456"),
                },
                new CarModel()
                {
                    Id = new Guid("1c852177-9ca6-4ff6-af49-eb88c0f72cff"),
                    ModelName = "Cooper Countryman",
                    BrandId = new Guid("96ec5f7f-8b0f-41b9-9694-e9968fd49f7a"),
                }
            );
    }
}