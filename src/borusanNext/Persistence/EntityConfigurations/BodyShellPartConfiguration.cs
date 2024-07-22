using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BodyShellPartConfiguration : IEntityTypeConfiguration<BodyShellPart>
{
    public void Configure(EntityTypeBuilder<BodyShellPart> builder)
    {
        builder.ToTable("BodyShellParts").HasKey(bsp => bsp.Id);

        builder.Property(bsp => bsp.Id).HasColumnName("Id").IsRequired();
        builder.Property(bsp => bsp.LeftFrontFender).HasColumnName("LeftFrontFender").IsRequired();
        builder.Property(bsp => bsp.LeftFrontDoor).HasColumnName("LeftFrontDoor").IsRequired();
        builder.Property(bsp => bsp.LeftRearDoor).HasColumnName("LeftRearDoor").IsRequired();
        builder.Property(bsp => bsp.LeftRearFender).HasColumnName("LeftRearFender").IsRequired();
        builder.Property(bsp => bsp.RightFrontFender).HasColumnName("RightFrontFender").IsRequired();
        builder.Property(bsp => bsp.RightFrontDoor).HasColumnName("RightFrontDoor").IsRequired();
        builder.Property(bsp => bsp.RightRearDoor).HasColumnName("RightRearDoor").IsRequired();
        builder.Property(bsp => bsp.RightRearFender).HasColumnName("RightRearFender").IsRequired();
        builder.Property(bsp => bsp.Frontbumper).HasColumnName("Frontbumper").IsRequired();
        builder.Property(bsp => bsp.RearBumper).HasColumnName("RearBumper").IsRequired();
        builder.Property(bsp => bsp.Bonnet).HasColumnName("Bonnet").IsRequired();
        builder.Property(bsp => bsp.Ceiling).HasColumnName("Ceiling").IsRequired();
        builder.Property(bsp => bsp.Luggage).HasColumnName("Luggage").IsRequired();
        builder.Property(bsp => bsp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(bsp => bsp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(bsp => bsp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(bsp => !bsp.DeletedDate.HasValue);
    }
}