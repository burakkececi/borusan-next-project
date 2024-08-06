using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerFavoriteConfiguration : IEntityTypeConfiguration<CustomerFavorite>
{
    public void Configure(EntityTypeBuilder<CustomerFavorite> builder)
    {
        builder.ToTable("CustomerFavorites").HasKey(cf => cf.Id);

        builder.Property(cf => cf.Id).HasColumnName("Id").IsRequired();
        builder.Property(cf => cf.CustomerId).HasColumnName("CustomerId").IsRequired();
        builder.Property(cf => cf.AdvertId).HasColumnName("AdvertId").IsRequired();
        builder.Property(cf => cf.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cf => cf.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cf => cf.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cf => !cf.DeletedDate.HasValue);

        builder.HasData(
            new CustomerFavorite()
            {
                Id = new Guid("374b8206-bc64-47e1-8a3b-3359fb8eba1f"),
                CustomerId = new Guid("ab623e31-88ab-48cb-8942-2c541343d651"),
                AdvertId = new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc")
            },
            new CustomerFavorite()
            {
                Id = new Guid("3bdf5ae4-4e67-445b-85f9-005575de78fd"),
                CustomerId = new Guid("ab623e31-88ab-48cb-8942-2c541343d651"),
                AdvertId = new Guid("87b836e5-0f84-4bc0-8825-0a3c50277385")
            }
            );
    }
}