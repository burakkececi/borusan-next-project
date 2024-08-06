using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags").HasKey(t => t.Id);

        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.Name).HasColumnName("Name").IsRequired();
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);

        builder.HasData(
            new Tag()
            {
                Id = new Guid("873dbb53-f3ca-4bda-a0d7-18ae10ca9f3e"),
                Name = "İkinci El"
            }
            );
    }
}