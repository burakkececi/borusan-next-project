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
        builder.Property(bit => bit.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(bit => bit.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(bit => bit.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(bit => !bit.DeletedDate.HasValue);

        builder.HasOne(p => p.Blog).WithMany(p => p.BlogItemTags).HasForeignKey(p => p.BlogId);
        builder.HasOne(p => p.Tag).WithMany(p => p.BlogItemTags).HasForeignKey(p => p.TagId);

        builder.HasData(
            new BlogItemTag()
            {
                Id = new Guid("24786008-f2f5-456a-b3b2-9be51d2584af"),
                BlogId = new Guid("1c1fac0a-4c1f-4ade-bded-a9b7a28df01b"),
                TagId = new Guid("873dbb53-f3ca-4bda-a0d7-18ae10ca9f3e")
            },
            new BlogItemTag()
            {
                Id = new Guid("e3415515-de98-4ba4-ab4d-9527e6b9dbd4"),
                BlogId = new Guid("6321910f-01ee-47be-b65e-8868ffecb023"),
                TagId = new Guid("873dbb53-f3ca-4bda-a0d7-18ae10ca9f3e")
            },
            new BlogItemTag()
            {
                Id = new Guid("f433e050-e90c-4551-b65d-edb409244e3c"),
                BlogId = new Guid("d323a479-a0f5-4347-a764-698be769fb57"),
                TagId = new Guid("873dbb53-f3ca-4bda-a0d7-18ae10ca9f3e")
            }
            );
    }
}