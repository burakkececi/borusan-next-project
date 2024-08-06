using Domain.Entities;
using Domain.Enums;
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
        builder.Property(bsp => bsp.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(bsp => bsp.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(bsp => bsp.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(bsp => !bsp.DeletedDate.HasValue);

        builder.HasData(
            new BodyShellPart()
            {
                Id = new Guid("3eeff5e8-58ab-4f64-82a9-05d77b83b4ef"),
                LeftFrontFender = ExpertizeCondition.Changed,
                LeftFrontDoor = ExpertizeCondition.Changed,
                LeftRearDoor = ExpertizeCondition.Changed,
                LeftRearFender = ExpertizeCondition.Changed,
                RightFrontFender = 0,
                RightFrontDoor = 0,
                RightRearDoor = 0,
                RightRearFender = 0,
                Frontbumper = 0,
                RearBumper = ExpertizeCondition.Painted,
                Bonnet = 0,
                Ceiling = 0,
                Luggage = 0
            },
            new BodyShellPart()
            {
                Id = new Guid("8c9d2d89-affb-4202-9953-ab86cf490ca0"),
                LeftFrontFender = 0,
                LeftFrontDoor = 0,
                LeftRearDoor = 0,
                LeftRearFender = 0,
                RightFrontFender = 0,
                RightFrontDoor = 0,
                RightRearDoor = 0,
                RightRearFender = 0,
                Frontbumper = 0,
                RearBumper = 0,
                Bonnet = 0,
                Ceiling = 0,
                Luggage = 0
            },
            new BodyShellPart()
            {
                Id = new Guid("db7257a0-5a57-4960-8a34-7f4f798470a2"),
                LeftFrontFender = 0,
                LeftFrontDoor = 0,
                LeftRearDoor = ExpertizeCondition.Painted,
                LeftRearFender = 0,
                RightFrontFender = 0,
                RightFrontDoor = 0,
                RightRearDoor = 0,
                RightRearFender = ExpertizeCondition.Painted,
                Frontbumper = 0,
                RearBumper = 0,
                Bonnet = 0,
                Ceiling = 0,
                Luggage = 0
            }
            );
    }
}