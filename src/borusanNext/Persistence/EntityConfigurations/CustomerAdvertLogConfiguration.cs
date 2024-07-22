using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerAdvertLogConfiguration : IEntityTypeConfiguration<CustomerAdvertLog>
{
    public void Configure(EntityTypeBuilder<CustomerAdvertLog> builder)
    {
        builder.ToTable("CustomerAdvertLogs").HasKey(cal => cal.Id);

        builder.Property(cal => cal.Id).HasColumnName("Id").IsRequired();
        builder.Property(cal => cal.CustomerId).HasColumnName("CustomerId").IsRequired();
        builder.Property(cal => cal.AdvertId).HasColumnName("AdvertId").IsRequired();
        builder.Property(cal => cal.ContactStatus).HasColumnName("ContactStatus").IsRequired();
        builder.Property(cal => cal.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cal => cal.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cal => cal.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cal => !cal.DeletedDate.HasValue);
    }
}