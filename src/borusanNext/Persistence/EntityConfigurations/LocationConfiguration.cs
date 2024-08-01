using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations").HasKey(l => l.Id);

        builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
        builder.Property(l => l.Name).HasColumnName("Name").IsRequired();
        builder.Property(l => l.City).HasColumnName("City").IsRequired();
        builder.Property(l => l.Address).HasColumnName("Address").IsRequired();
        builder.Property(l => l.Latitute).HasColumnName("Latitute").IsRequired();
        builder.Property(l => l.Longitute).HasColumnName("Longitute").IsRequired();
        builder.Property(l => l.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(l => l.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(l => l.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(l => !l.DeletedDate.HasValue);
    }
}