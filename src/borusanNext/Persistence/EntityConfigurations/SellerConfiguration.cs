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

        builder.HasData(
            new Seller()
            {
                Id = new Guid("056dd418-5114-4ea1-baf3-07d4b8fc26f6"),
                UserId = new Guid("b73f6541-460e-4d9d-97eb-1402f63df038"),
                Name = "Borusan Avcılar",
                PhoneNumber = "5354567890",
                LicenceId = new Guid("7f30d80f-3a7b-429c-81a5-0c9507839691"),
                LocationId = new Guid("59a7ddc2-3920-4652-9543-797fbd1d3d38"),
            },
            new Seller()
            {
                Id = new Guid("785d6af9-4404-4d7a-ad3e-82319812b037"),
                UserId = new Guid("69bd8e0f-59d4-4532-ae32-03cec3e39158"),
                Name = "Borusan Samandıra",
                PhoneNumber = "5426543210",
                LicenceId = new Guid("e99ccd48-51a3-46c0-b539-a28cec7d214c"),
                LocationId = new Guid("2f565ad5-7ae1-42ad-82f2-96944052aa27"),
            },
            new Seller()
            {
                Id = new Guid("667742ae-ae24-4d8c-9029-57ab5ba305ba"),
                UserId = new Guid("398b5d31-f2e2-473f-8f40-78f7e79af217"),
                Name = "Kececi Oto",
                PhoneNumber = "5556667777",
                LicenceId = new Guid("d1993933-0185-4333-888c-36f226993e1c"),
                LocationId = new Guid("4744af1a-89ba-4d1b-890c-9d3e3c755cda"),
            }
            );
    }
}