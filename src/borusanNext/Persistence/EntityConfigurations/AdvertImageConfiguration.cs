using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AdvertImageConfiguration : IEntityTypeConfiguration<AdvertImage>
{
    public void Configure(EntityTypeBuilder<AdvertImage> builder)
    {
        builder.ToTable("AdvertImages").HasKey(ai => ai.Id);

        builder.Property(ai => ai.Id).HasColumnName("Id").IsRequired();
        builder.Property(ai => ai.AdvertId).HasColumnName("AdvertId").IsRequired();
        builder.Property(ai => ai.ImageURL).HasColumnName("ImageURL").IsRequired();
        builder.Property(ai => ai.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(ai => ai.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(ai => ai.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(ai => !ai.DeletedDate.HasValue);
    }
}