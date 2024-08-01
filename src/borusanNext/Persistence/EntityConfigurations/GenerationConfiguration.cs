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
    }
}