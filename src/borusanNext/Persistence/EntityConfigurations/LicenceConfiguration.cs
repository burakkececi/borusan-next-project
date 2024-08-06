using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LicenceConfiguration : IEntityTypeConfiguration<Licence>
{
    public void Configure(EntityTypeBuilder<Licence> builder)
    {
        builder.ToTable("Licences").HasKey(l => l.Id);

        builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
        builder.Property(l => l.LicenceNo).HasColumnName("LicenceNo").IsRequired();
        builder.Property(l => l.ProvidedBy).HasColumnName("ProvidedBy").IsRequired();
        builder.Property(l => l.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(l => l.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(l => l.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(l => !l.DeletedDate.HasValue);

        builder.HasData(
            new Licence()
            {
                Id = new Guid("7f30d80f-3a7b-429c-81a5-0c9507839691"),
                LicenceNo = 3401870,
                ProvidedBy = "Borusan Otomotiv"
            },
            new Licence()
            {
                Id = new Guid("e99ccd48-51a3-46c0-b539-a28cec7d214c"),
                LicenceNo = 6401872,
                ProvidedBy = "Borusan Otomotiv"
            },
            new Licence()
            {
                Id = new Guid("d1993933-0185-4333-888c-36f226993e1c"),
                LicenceNo = 3501870,
                ProvidedBy = "Borusan Otomotiv"
            }
            );
    }
}