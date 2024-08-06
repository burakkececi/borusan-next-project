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

        builder.HasData(
            new BodyType()
            {
                Id = new Guid("1e6fa0ec-590b-4d7f-8036-63f823390031"),
                BodyName = "Hatchback",
                Door = "4"
            },
            new BodyType()
            {
                Id = new Guid("7204f988-a804-43d0-8f9c-4084c1c5dfc0"),
                BodyName = "Sedan",
                Door = "4"
            },
            new BodyType()
            {
                Id = new Guid("491df778-2c1a-4d5f-a0c9-d28b5ffcb747"),
                BodyName = "SUV",
                Door = "4"
            }
            );
    }
}