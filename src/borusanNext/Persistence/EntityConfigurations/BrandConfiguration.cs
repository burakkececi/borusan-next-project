using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.Logo).HasColumnName("Logo").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        builder.HasData(
            new Brand()
            {
                Id = new Guid("c571076a-f830-4682-bfb3-5ca69537ee41"),
                Name = "BMW",
                Logo = "https://res.cloudinary.com/dl0cotczj/image/upload/v1722869825/cpoit6q62nuhyb9byxkn.png"
            },
            new Brand()
            {
                Id = new Guid("0f1e4581-6b0b-4b9f-a4ab-3b292c082456"),
                Name = "Land Rover",
                Logo = "https://res.cloudinary.com/dl0cotczj/image/upload/v1722869832/vqmnm1pnw8ny9rdyku28.svg"
            },
            new Brand()
            {
                Id = new Guid("96ec5f7f-8b0f-41b9-9694-e9968fd49f7a"),
                Name = "MINI",
                Logo = "https://res.cloudinary.com/dl0cotczj/image/upload/v1724597194/szhvy5qofpb482r5yazn.png"
            }
            );
    }
}