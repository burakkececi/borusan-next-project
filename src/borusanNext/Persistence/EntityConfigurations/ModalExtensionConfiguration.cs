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
        builder.Property(me => me.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(me => me.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(me => me.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(me => !me.DeletedDate.HasValue);
        builder.HasOne(p => p.CarModel).WithMany(p => p.ModalExtensions).HasForeignKey(p => p.CarModelId);
        builder.HasOne(p => p.Generation).WithMany(p => p.ModalExtensions).HasForeignKey(p => p.GenerationId);
    }
}