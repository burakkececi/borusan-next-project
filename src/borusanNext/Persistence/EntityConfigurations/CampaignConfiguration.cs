using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
{
    public void Configure(EntityTypeBuilder<Campaign> builder)
    {
        builder.ToTable("Campaigns").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Title).HasColumnName("Title").IsRequired();
        builder.Property(c => c.Description).HasColumnName("Description").IsRequired();
        builder.Property(c => c.Banner).HasColumnName("Banner").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasData(
            new Campaign()
            {
                Id = new Guid("4ddb2ea7-21a7-4d1d-9367-bdf25cc75ac8"),
                Title = "Bu Bir Kampanya",
                Description = "Bu Bir Kampanya Detayı",
                Banner = "https://res.cloudinary.com/dl0cotczj/image/upload/v1722923108/g09uyd5sinylzgo2xtjj.jpg"
            }
            );
    }
}