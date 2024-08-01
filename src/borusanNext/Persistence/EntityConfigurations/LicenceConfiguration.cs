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
        builder.Property(l => l.LicenceOwner).HasColumnName("LicenceOwner").IsRequired();
        builder.Property(l => l.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(l => l.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(l => l.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(l => !l.DeletedDate.HasValue);
    }
}