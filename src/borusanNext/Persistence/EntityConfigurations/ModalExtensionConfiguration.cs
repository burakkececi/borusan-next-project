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
        builder.Property(c => c.EngineId).HasColumnName("EngineId").IsRequired();
        builder.Property(c => c.BodyTypeId).HasColumnName("BodyTypeId").IsRequired();
        builder.Property(c => c.TransmissionId).HasColumnName("TransmissionId").IsRequired();
        builder.Property(me => me.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(me => me.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(me => me.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(me => !me.DeletedDate.HasValue);
        builder.HasOne(p => p.CarModel).WithMany(p => p.ModalExtensions).HasForeignKey(p => p.CarModelId);
        builder.HasOne(p => p.Generation).WithMany(p => p.ModalExtensions).HasForeignKey(p => p.GenerationId);
        builder.HasOne(p => p.Engine).WithMany(p => p.ModalExtensions).HasForeignKey(p => p.EngineId);
        builder.HasOne(p => p.BodyType).WithMany(p => p.ModalExtensions).HasForeignKey(p => p.BodyTypeId);
        builder.HasOne(p => p.Transmission).WithMany(p => p.ModalExtensions).HasForeignKey(p => p.TransmissionId);

        builder.HasData(
            new ModalExtension()
            {
                Id = new Guid("e1721aa6-b49b-4290-8f71-ae5d17267d5a"),
                CarModelId = new Guid("86a6edf9-745f-4a0f-9413-110b4cd6bfb6"),
                GenerationId = new Guid("d94a19fa-9478-4514-8238-e08eb534a209"),
                EngineId = new Guid("12f9441e-92f2-4333-9e55-b1131c1bfde3"),
                BodyTypeId = new Guid("1e6fa0ec-590b-4d7f-8036-63f823390031"),
                TransmissionId = new Guid("b830d944-aa1b-4074-9a24-1ff60f1cd38d"),
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
                EngineId = new Guid("f235cb8f-559a-4659-8bba-8fba8b0737d6"),
                BodyTypeId = new Guid("7204f988-a804-43d0-8f9c-4084c1c5dfc0"),
                TransmissionId = new Guid("b830d944-aa1b-4074-9a24-1ff60f1cd38d"),
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
                EngineId = new Guid("0106e5db-0b88-4231-9cc0-263868fb5c01"),
                BodyTypeId = new Guid("491df778-2c1a-4d5f-a0c9-d28b5ffcb747"),
                TransmissionId = new Guid("2c450873-2f0b-4da2-a7ff-245ca5c73e19"),
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