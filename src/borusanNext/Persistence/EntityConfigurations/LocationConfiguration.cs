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
        builder.Property(l => l.City).HasColumnName("City").IsRequired();
        builder.Property(l => l.Address).HasColumnName("Address").IsRequired();
        builder.Property(l => l.Latitute).HasColumnName("Latitute").IsRequired();
        builder.Property(l => l.Longitute).HasColumnName("Longitute").IsRequired();
        builder.Property(l => l.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(l => l.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(l => l.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(l => !l.DeletedDate.HasValue);

        builder.HasData(
            new Location()
            {
                Id = new Guid("59a7ddc2-3920-4652-9543-797fbd1d3d38"),
                City = "Istanbul",
                Address = "Firüzköy Yolu No: 21 Avcılar",
                Latitute = "40.992769",
                Longitute = "28.716821"
            },
            new Location()
            {
                Id = new Guid("2f565ad5-7ae1-42ad-82f2-96944052aa27"),
                City = "Istanbul",
                Address = "Akpınar, Bilim Cd. No:2, 34485 Sancaktepe",
                Latitute = "40.9753623",
                Longitute = "29.2244372"
            },
            new Location()
            {
                Id = new Guid("4744af1a-89ba-4d1b-890c-9d3e3c755cda"),
                City = "Istanbul",
                Address = "Firüzköy Yolu No: 21 Avcılar",
                Latitute = "40.992769",
                Longitute = "28.716821"
            }
            );
    }
}