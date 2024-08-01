using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FuelConsumptionConfiguration : IEntityTypeConfiguration<FuelConsumption>
{
    public void Configure(EntityTypeBuilder<FuelConsumption> builder)
    {
        builder.ToTable("FuelConsumptions").HasKey(fc => fc.Id);

        builder.Property(fc => fc.Id).HasColumnName("Id").IsRequired();
        builder.Property(fc => fc.OutOfTown).HasColumnName("OutOfTown").IsRequired();
        builder.Property(fc => fc.Urban).HasColumnName("Urban").IsRequired();
        builder.Property(fc => fc.Average).HasColumnName("Average").IsRequired();
        builder.Property(fc => fc.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(fc => fc.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(fc => fc.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(fc => !fc.DeletedDate.HasValue);
    }
}