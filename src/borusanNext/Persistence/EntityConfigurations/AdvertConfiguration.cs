using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AdvertConfiguration : IEntityTypeConfiguration<Advert>
{
    public void Configure(EntityTypeBuilder<Advert> builder)
    {
        builder.ToTable("Adverts").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.AdvertNo).HasColumnName("AdvertNo").IsRequired();
        builder.Property(a => a.CarId).HasColumnName("CarId").IsRequired();
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

        builder.HasOne(p => p.Car).WithOne(p => p.Advert).HasForeignKey<Advert>(p => p.CarId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(p => p.AdvertImages).WithOne(p => p.Advert).HasForeignKey(p => p.AdvertId);

        builder.HasData(
                            new Advert()
                            {
                                Id = new("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"),
                                CarId = new("948018bd-0032-4a6e-928b-c1e6beb2e76b"),
                                AdvertNo = 000001
                            },
                            new Advert()
                            {
                                Id = new("87b836e5-0f84-4bc0-8825-0a3c50277385"),
                                CarId = new("12f8c123-4b6d-4a1e-928b-c1e6beb2e6f1"),
                                AdvertNo = 000002
                            }
                       );
    }
}