using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ChassisPartConfiguration : IEntityTypeConfiguration<ChassisPart>
{
    public void Configure(EntityTypeBuilder<ChassisPart> builder)
    {
        builder.ToTable("ChassisParts").HasKey(cp => cp.Id);

        builder.Property(cp => cp.Id).HasColumnName("Id").IsRequired();
        builder.Property(cp => cp.IsRightChassisChanged).HasColumnName("IsRightChassisChanged").IsRequired();
        builder.Property(cp => cp.IsLeftChassisChanged).HasColumnName("IsLeftChassisChanged").IsRequired();
        builder.Property(cp => cp.IsFrontPanelChanged).HasColumnName("IsFrontPanelChanged").IsRequired();
        builder.Property(cp => cp.IsBackPanelChanged).HasColumnName("IsBackPanelChanged").IsRequired();
        builder.Property(cp => cp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cp => cp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cp => cp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cp => !cp.DeletedDate.HasValue);
    }
}