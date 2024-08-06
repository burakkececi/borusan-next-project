using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FuelTypeConfiguration : IEntityTypeConfiguration<FuelType>
{
    public void Configure(EntityTypeBuilder<FuelType> builder)
    {
        builder.ToTable("FuelTypes").HasKey(ft => ft.Id);

        builder.Property(ft => ft.Id).HasColumnName("Id").IsRequired();
        builder.Property(ft => ft.Name).HasColumnName("Name").IsRequired();
        builder.Property(ft => ft.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(ft => ft.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(ft => ft.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(ft => !ft.DeletedDate.HasValue);

        builder.HasData(
            new FuelType()
            {
                Id = new Guid("7c27ae08-d686-43b7-9fc2-5a9df75963de"),
                Name = "Electric"
            },
            new FuelType()
            {
                Id = new Guid("5e44df51-9db5-46cc-b9ab-7c64a491e2fe"),
                Name = "Diesel"
            },
            new FuelType()
            {
                Id = new Guid("55126902-8144-4e5a-9b4f-06cc32304d57"),
                Name = "Petrol"
            }
            );
    }
}