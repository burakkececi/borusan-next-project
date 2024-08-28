using Domain.Entities;
using Domain.Enums;
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
        builder.Property(c => c.CustomerType).HasColumnName("CustomerType").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasOne(p => p.Address).WithMany(p => p.Customers).HasForeignKey(p => p.AddressId);
        builder.HasOne(p => p.User).WithOne(p => p.Customer).HasForeignKey<Customer>(p => p.UserId);

        builder.HasData(
            new Customer()
            {
                Id = new Guid("27ca8f20-333f-4fc2-a535-c156a2aec150"),
                UserId = new Guid("6444d306-ab8e-4e84-a6ff-77037d68fd2e"),
                FirstName = "Burak",
                LastName = "Keçeci",
                CustomerType = Domain.Enums.CustomerType.Buyer,
                IdentityNumber = "44444444444",
                Phone = "5555555555",
                IsPhoneVerified = false,
                DateOfBirth = new DateOnly(),
                AddressId = new Guid("a48e5400-d10b-450c-817a-6a5188e13de9"),
                AddressLine = "",
            },
            new Customer()
            {
                Id = new Guid("ab623e31-88ab-48cb-8942-2c541343d651"),
                UserId = new Guid("bd4dd3dc-72e4-42cb-bde3-0fcb1867b10d"),
                FirstName = "Meryem",
                LastName = "Talay",
                CustomerType = Domain.Enums.CustomerType.Buyer,
                Phone = "5555555555",
                IdentityNumber = "33333333333",
                IsPhoneVerified = false,
                DateOfBirth = new DateOnly(),
                AddressId = new Guid("a48e5400-d10b-450c-817a-6a5188e13de9"),
                AddressLine = "",
            },
            new Customer()
            {
                Id = new Guid("d2f17680-26d1-4ac3-90c6-4ffec9e5c0ad"),
                UserId = new Guid("ada31c5d-6014-46d2-a1c3-ed8007e898cf"),
                FirstName = "Ali",
                LastName = "Laçin",
                CustomerType = Domain.Enums.CustomerType.BuyerAndSeller,
                Phone = "5555555555",
                IdentityNumber = "22222222222",
                IsPhoneVerified = false,
                DateOfBirth = new DateOnly(),
                AddressId = new Guid("a48e5400-d10b-450c-817a-6a5188e13de9"),
                AddressLine = "",
            },
            new Customer()
            {
                Id = new Guid("b1e3b9cd-1c82-4f68-a70e-8349c28af525"),
                UserId = new Guid("36160d4c-8a2a-4959-9769-ebf2bd812237"),
                FirstName = "Sefa",
                LastName = "Pehlivan",
                CustomerType = Domain.Enums.CustomerType.Seller,
                Phone = "5555555555",
                IdentityNumber = "11111111111",
                IsPhoneVerified = false,
                DateOfBirth = new DateOnly(),
                AddressId = new Guid("a48e5400-d10b-450c-817a-6a5188e13de9"),
                AddressLine = "",
            }
            );
    }
}