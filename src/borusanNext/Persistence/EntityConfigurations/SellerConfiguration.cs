using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.ToTable("Sellers").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(s => s.Name).HasColumnName("Name").IsRequired();
        builder.Property(s => s.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
        builder.Property(s => s.LicenceId).HasColumnName("LicenceId").IsRequired();
        builder.Property(s => s.LocationId).HasColumnName("LocationId").IsRequired();
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);

        builder.HasOne(p => p.Location).WithOne(p => p.Seller).HasForeignKey<Seller>(p => p.LocationId);
        builder.HasOne(p => p.Licence).WithOne(p => p.Seller).HasForeignKey<Seller>(p => p.LicenceId);
        builder.HasOne(p => p.User).WithOne(p => p.Seller).HasForeignKey<Seller>(p => p.UserId);
    }
}