using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ModalExtensionConfiguration : IEntityTypeConfiguration<ModalExtension>
{
    public void Configure(EntityTypeBuilder<ModalExtension> builder)
    {
        builder.ToTable("ModalExtensions").HasKey(me => me.Id);

        builder.Property(me => me.Id).HasColumnName("Id").IsRequired();
        builder.Property(me => me.Name).HasColumnName("Name").IsRequired();
        builder.Property(me => me.Lenght).HasColumnName("Lenght").IsRequired();
        builder.Property(me => me.Width).HasColumnName("Width").IsRequired();
        builder.Property(me => me.Height).HasColumnName("Height").IsRequired();
        builder.Property(me => me.FuelTank).HasColumnName("FuelTank").IsRequired();
        builder.Property(me => me.LuggageCapacity).HasColumnName("LuggageCapacity").IsRequired();
        builder.Property(me => me.EmptyWeight).HasColumnName("EmptyWeight").IsRequired();
        builder.Property(me => me.ModelYear).HasColumnName("ModelYear").IsRequired();
        builder.Property(me => me.CarModelId).HasColumnName("CarModelId").IsRequired();
        builder.Property(me => me.GenerationId).HasColumnName("GenerationId").IsRequired();
        builder.Property(me => me.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(me => me.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(me => me.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(me => !me.DeletedDate.HasValue);
        builder.HasOne(p => p.CarModel).WithMany(p => p.ModalExtensions).HasForeignKey(p => p.CarModelId);
        builder.HasOne(p => p.Generation).WithMany(p => p.ModalExtensions).HasForeignKey(p => p.GenerationId);

        builder.HasData(
            new ModalExtension()
            {
                Id = new Guid("e1721aa6-b49b-4290-8f71-ae5d17267d5a"),
                CarModelId = new Guid("86a6edf9-745f-4a0f-9413-110b4cd6bfb6"),
                GenerationId = new Guid("d94a19fa-9478-4514-8238-e08eb534a209"),
                Name = "520i Luxury Line",
                EmptyWeight = 0,
                Height = 1557,
                Lenght = 4299,
                Width = 1822,
                LuggageCapacity = 0,
                FuelTank = 0,
                ModelYear = 2021,
            },
            new ModalExtension()
            {
                Id = new Guid("0333574e-400f-4ae4-80f2-0ac061efd7c8"),
                CarModelId = new Guid("534e852f-1bcf-4ae3-9ae4-4b5976bdfd87"),
                GenerationId = new Guid("ccb47a46-d3ee-421f-b731-8810a62a0628"),
                Name = "2.0 PHEV Vogue",
                EmptyWeight = 0,
                Height = 1557,
                Lenght = 4299,
                Width = 1822,
                LuggageCapacity = 0,
                FuelTank = 0,
                ModelYear = 2021,
            },
            new ModalExtension()
            {
                Id = new Guid("40b9b81b-ccb9-4906-ad6d-7f0c2a9c728d"),
                CarModelId = new Guid("1c852177-9ca6-4ff6-af49-eb88c0f72cff"),
                GenerationId = new Guid("353a7e00-a2ba-4111-af4a-21302b0d8f50"),
                Name = "1.5 Pepper",
                EmptyWeight = 0,
                Height = 1557,
                Lenght = 4299,
                Width = 1822,
                LuggageCapacity = 0,
                FuelTank = 0,
                ModelYear = 2021,
            }
            );
    }
}