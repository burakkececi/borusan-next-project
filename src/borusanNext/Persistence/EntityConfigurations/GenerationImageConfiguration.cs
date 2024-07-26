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
        builder.Property(gi => gi.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(gi => gi.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(gi => gi.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(gi => !gi.DeletedDate.HasValue);
    }
}