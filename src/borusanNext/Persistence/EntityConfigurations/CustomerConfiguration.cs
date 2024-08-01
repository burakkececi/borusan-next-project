using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(c => c.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(c => c.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(c => c.Phone).HasColumnName("Phone").IsRequired();
        builder.Property(c => c.IsSmsConfirmed).HasColumnName("IsSmsConfirmed").IsRequired();
        builder.Property(c => c.CustomerType).HasColumnName("CustomerType").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasOne(p => p.User).WithOne(p => p.Customer).HasForeignKey<Customer>(p => p.UserId);

    }
}