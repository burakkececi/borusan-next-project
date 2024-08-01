using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarColorConfiguration : IEntityTypeConfiguration<CarColor>
{
    public void Configure(EntityTypeBuilder<CarColor> builder)
    {
        builder.ToTable("CarColors").HasKey(cc => cc.Id);

        builder.Property(cc => cc.Id).HasColumnName("Id").IsRequired();
        builder.Property(cc => cc.Name).HasColumnName("Name").IsRequired();
        builder.Property(cc => cc.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(cc => cc.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(cc => cc.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(cc => !cc.DeletedDate.HasValue);
    }
}