using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.ChassisNumber).HasColumnName("ChassisNumber").IsRequired();
        builder.Property(c => c.Plate).HasColumnName("Plate").IsRequired();
        builder.Property(c => c.Kilometers).HasColumnName("Kilometers").IsRequired();
        builder.Property(c => c.SpareKey).HasColumnName("SpareKey").IsRequired();
        builder.Property(c => c.Inquiry).HasColumnName("Inquiry").IsRequired();
        builder.Property(c => c.WheelType).HasColumnName("WheelType").IsRequired();
        builder.Property(c => c.SpareWheel).HasColumnName("SpareWheel").IsRequired();
        builder.Property(c => c.Price).HasColumnName("Price").HasPrecision(18, 2).IsRequired();
        builder.Property(c => c.ModalExtensionId).HasColumnName("ModalExtensionId").IsRequired();
        builder.Property(c => c.ColorId).HasColumnName("ColorId").IsRequired();
        builder.Property(c => c.EngineId).HasColumnName("EngineId").IsRequired();
        builder.Property(c => c.BodyTypeId).HasColumnName("BodyTypeId").IsRequired();
        builder.Property(c => c.TransmissionId).HasColumnName("TransmissionId").IsRequired();
        builder.Property(c => c.TramerId).HasColumnName("TramerId").IsRequired();
        builder.Property(c => c.SellerId).HasColumnName("SellerId").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasOne(p => p.ExpertizeResult).WithOne(p => p.Car).HasForeignKey<Car>(p => p.TramerId);
        builder.HasOne(p => p.ModalExtension).WithOne(p => p.Car).HasForeignKey<Car>(p => p.ModalExtensionId);
        builder.HasOne(p => p.Engine).WithMany(p => p.Cars).HasForeignKey(p => p.EngineId);
        builder.HasOne(p => p.BodyType).WithMany(p => p.Cars).HasForeignKey(p => p.BodyTypeId);
        builder.HasOne(p => p.Transmission).WithMany(p => p.Cars).HasForeignKey(p => p.TransmissionId);
        builder.HasOne(p => p.Color).WithMany(p => p.Cars).HasForeignKey(p => p.ColorId);
        builder.HasOne(p => p.Seller).WithMany(p => p.Cars).HasForeignKey(p => p.SellerId);

        builder.HasData(
                        new Car()
                        {
                            Id = new Guid("948018bd-0032-4a6e-928b-c1e6beb2e76b"),
                            ChassisNumber = "1HGCM82633A123456",
                            Plate = "34GS407",
                            Kilometers = 60000,
                            SpareKey = true,
                            Inquiry = new DateTime(2023, 08, 05),
                            WheelType = "Alloy",
                            SpareWheel = true,
                            Price = 25000.00m,

                            ModalExtensionId = new Guid("e1721aa6-b49b-4290-8f71-ae5d17267d5a"),
                            ColorId = new Guid("38211267-9cce-4040-adae-0c64bc26dab8"),
                            EngineId = new Guid("12f9441e-92f2-4333-9e55-b1131c1bfde3"),
                            BodyTypeId = new Guid("1e6fa0ec-590b-4d7f-8036-63f823390031"),
                            TransmissionId = new Guid("b830d944-aa1b-4074-9a24-1ff60f1cd38d"),
                            TramerId = new Guid("47e992e3-6561-49ff-a827-0e19aaf10345"),
                            SellerId = new Guid("056dd418-5114-4ea1-baf3-07d4b8fc26f6"),
                        },
                        new Car()
                        {
                            Id = new Guid("12f8c123-4b6d-4a1e-928b-c1e6beb2e6f1"),
                            ChassisNumber = "2HGCM82644A654321",
                            Plate = "22AB123",
                            Kilometers = 45000,
                            SpareKey = true,
                            Inquiry = new DateTime(2022, 05, 20),
                            WheelType = "Steel",
                            SpareWheel = false,
                            Price = 20000.00m,

                            ModalExtensionId = new Guid("0333574e-400f-4ae4-80f2-0ac061efd7c8"),
                            ColorId = new Guid("22596234-0c65-4e4e-9db4-bbf0584af494"),
                            EngineId = new Guid("f235cb8f-559a-4659-8bba-8fba8b0737d6"),
                            BodyTypeId = new Guid("7204f988-a804-43d0-8f9c-4084c1c5dfc0"),
                            TransmissionId = new Guid("b830d944-aa1b-4074-9a24-1ff60f1cd38d"),
                            TramerId = new Guid("0ce199f9-3627-44bb-b3c2-fbd72c6799c2"),
                            SellerId = new Guid("785d6af9-4404-4d7a-ad3e-82319812b037"),
                        },
                        new Car()
                        {
                            Id = new Guid("48f8a123-6b7d-4a2e-928b-c1e6beb2e7f2"),
                            ChassisNumber = "3HGCM82655A789012",
                            Plate = "78CD456",
                            Kilometers = 75000,
                            SpareKey = false,
                            Inquiry = new DateTime(2021, 11, 15),
                            WheelType = "Alloy",
                            SpareWheel = true,
                            Price = 18000.00m,

                            ModalExtensionId = new Guid("40b9b81b-ccb9-4906-ad6d-7f0c2a9c728d"),
                            ColorId = new Guid("22b793c7-8706-4850-aaa8-0f2fac8a2858"),
                            EngineId = new Guid("0106e5db-0b88-4231-9cc0-263868fb5c01"),
                            BodyTypeId = new Guid("491df778-2c1a-4d5f-a0c9-d28b5ffcb747"),
                            TransmissionId = new Guid("2c450873-2f0b-4da2-a7ff-245ca5c73e19"),
                            TramerId = new Guid("b8cb292b-c61b-4c73-9f20-f8fe2b746b5a"),
                            SellerId = new Guid("667742ae-ae24-4d8c-9029-57ab5ba305ba"),
                        }

            );
    }
}