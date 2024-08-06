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
        builder.Property(cal => cal.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(cal => cal.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(cal => cal.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(cal => !cal.DeletedDate.HasValue);

        builder.HasOne(p => p.Advert).WithMany(p => p.CustomerAdvertLogs).HasForeignKey(p => p.AdvertId);
        builder.HasOne(p => p.Customer).WithMany(p => p.CustomerAdvertLogs).HasForeignKey(p => p.CustomerId);

        builder.HasData(
            new CustomerAdvertLog()
            {
                Id = new Guid("5015e481-036b-4f18-a500-28ecdbab1327"),
                AdvertId = new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"),
                CustomerId = new Guid("27ca8f20-333f-4fc2-a535-c156a2aec150"),
                ContactStatus = Domain.Enums.CustomerContactInformation.New
            },
            new CustomerAdvertLog()
            {
                Id = new Guid("2b6897d8-6964-4d3f-9bd7-e4e16a9285d1"),
                AdvertId = new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"),
                CustomerId = new Guid("ab623e31-88ab-48cb-8942-2c541343d651"),
                ContactStatus = Domain.Enums.CustomerContactInformation.New
            }
            );
    }
}