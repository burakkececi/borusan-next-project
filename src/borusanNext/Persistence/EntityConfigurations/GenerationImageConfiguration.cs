using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class GenerationImageConfiguration : IEntityTypeConfiguration<GenerationImage>
{
    public void Configure(EntityTypeBuilder<GenerationImage> builder)
    {
        builder.ToTable("GenerationImages").HasKey(gi => gi.Id);

        builder.Property(gi => gi.Id).HasColumnName("Id").IsRequired();
        builder.Property(gi => gi.GenerationId).HasColumnName("GenerationId").IsRequired();
        builder.Property(gi => gi.ImageURL).HasColumnName("ImageURL").IsRequired();
        builder.Property(gi => gi.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(gi => gi.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(gi => gi.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(gi => !gi.DeletedDate.HasValue);
    }
}