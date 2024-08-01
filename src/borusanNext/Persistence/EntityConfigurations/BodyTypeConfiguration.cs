using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BodyTypeConfiguration : IEntityTypeConfiguration<BodyType>
{
    public void Configure(EntityTypeBuilder<BodyType> builder)
    {
        builder.ToTable("BodyTypes").HasKey(bt => bt.Id);

        builder.Property(bt => bt.Id).HasColumnName("Id").IsRequired();
        builder.Property(bt => bt.BodyName).HasColumnName("BodyName").IsRequired();
        builder.Property(bt => bt.Door).HasColumnName("Door").IsRequired();
        builder.Property(bt => bt.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(bt => bt.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(bt => bt.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(bt => !bt.DeletedDate.HasValue);
    }
}