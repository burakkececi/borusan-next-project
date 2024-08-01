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
    }
}