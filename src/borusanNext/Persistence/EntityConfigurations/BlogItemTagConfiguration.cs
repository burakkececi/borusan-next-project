using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BlogItemTagConfiguration : IEntityTypeConfiguration<BlogItemTag>
{
    public void Configure(EntityTypeBuilder<BlogItemTag> builder)
    {
        builder.ToTable("BlogItemTags").HasKey(bit => bit.Id);

        builder.Property(bit => bit.Id).HasColumnName("Id").IsRequired();
        builder.Property(bit => bit.TagId).HasColumnName("TagId").IsRequired();
        builder.Property(bit => bit.BlogId).HasColumnName("BlogId").IsRequired();
        builder.Property(bit => bit.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(bit => bit.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(bit => bit.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(bit => !bit.DeletedDate.HasValue);
    }
}