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
    }
}