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
    }
}