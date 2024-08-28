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
        builder.Property(s => s.AddressId).HasColumnName("AddressId").IsRequired();
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);

        builder.HasOne(p => p.Address).WithMany(p => p.Sellers).HasForeignKey(p => p.AddressId);
        builder.HasOne(p => p.User).WithOne(p => p.Seller).HasForeignKey<Seller>(p => p.UserId);

        builder.HasData(
            new Seller()
            {
                Id = new Guid("056dd418-5114-4ea1-baf3-07d4b8fc26f6"),
                UserId = new Guid("b73f6541-460e-4d9d-97eb-1402f63df038"),
                Name = "Borusan Avcılar",
                PhoneNumber = "5354567890",
                AddressId = new Guid("047c6a96-da39-4b67-b68d-1b1956ca2e7d"),
                AddressLine = "Firüzköy Yolu No: 21 Avcılar",
                LicenceNo = 0,
                ProvidedBy = "Burak",
                Latitute = "40.992769",
                Longitute = "28.716821"
            },
            new Seller()
            {
                Id = new Guid("785d6af9-4404-4d7a-ad3e-82319812b037"),
                UserId = new Guid("69bd8e0f-59d4-4532-ae32-03cec3e39158"),
                Name = "Borusan Samandıra",
                PhoneNumber = "5426543210",
                AddressId = new Guid("a48e5400-d10b-450c-817a-6a5188e13de9"),
                AddressLine = "Akpınar, Bilim Cd. No:2, 34485 Sancaktepe",
                Latitute = "40.9753623",
                Longitute = "29.2244372",
                LicenceNo = 0,
                ProvidedBy = "Burak",
            }
            );
    }
}