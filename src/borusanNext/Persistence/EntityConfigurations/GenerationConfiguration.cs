using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class GenerationConfiguration : IEntityTypeConfiguration<Generation>
{
    public void Configure(EntityTypeBuilder<Generation> builder)
    {
        builder.ToTable("Generations").HasKey(g => g.Id);

        builder.Property(g => g.Id).HasColumnName("Id").IsRequired();
        builder.Property(g => g.Name).HasColumnName("Name").IsRequired();
        builder.Property(g => g.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(g => g.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(g => g.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(g => !g.DeletedDate.HasValue);

        builder.HasMany(p => p.GenerationImages).WithOne(p => p.Generation).HasForeignKey(g => g.GenerationId);

        builder.HasData(
            new Generation()
            {
                Id = new Guid("d94a19fa-9478-4514-8238-e08eb534a209"),
                Name = "7.Nesil Makyaj",
            },
            new Generation()
            {
                Id = new Guid("ccb47a46-d3ee-421f-b731-8810a62a0628"),
                Name = "4.Nesil Makyaj",
            },
            new Generation()
            {
                Id = new Guid("353a7e00-a2ba-4111-af4a-21302b0d8f50"),
                Name = "2.Nesil",
            }
            );
    }
}