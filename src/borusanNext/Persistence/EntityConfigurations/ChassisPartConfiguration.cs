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
        builder.Property(cp => cp.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(cp => cp.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(cp => cp.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(cp => !cp.DeletedDate.HasValue);

        builder.HasData(
            new ChassisPart()
            {
                Id = new Guid("e59f7e66-cc28-4270-84ed-aa6812f00935"),
                IsRightChassisChanged = false,
                IsLeftChassisChanged = false,
                IsBackPanelChanged = false,
                IsFrontPanelChanged = false,
            },
            new ChassisPart()
            {
                Id = new Guid("352dd90f-0292-4613-b5d9-3540a723c6dc"),
                IsRightChassisChanged = false,
                IsLeftChassisChanged = false,
                IsBackPanelChanged = false,
                IsFrontPanelChanged = false,
            },
            new ChassisPart()
            {
                Id = new Guid("85262f34-ace7-4f68-8b20-8ed9a0fd77c6"),
                IsRightChassisChanged = false,
                IsLeftChassisChanged = false,
                IsBackPanelChanged = false,
                IsFrontPanelChanged = false,
            }
            );
    }
}