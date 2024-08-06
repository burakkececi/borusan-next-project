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

        builder.HasData(
            new CarColor()
            {
                Id = new Guid("38211267-9cce-4040-adae-0c64bc26dab8"),
                Name = "Red"
            },
             new CarColor()
             {
                 Id = new Guid("22596234-0c65-4e4e-9db4-bbf0584af494"),
                 Name = "Blue"
             }, new CarColor()
             {
                 Id = new Guid("22b793c7-8706-4850-aaa8-0f2fac8a2858"),
                 Name = "Black"
             }
            );
    }
}