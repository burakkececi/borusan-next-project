using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.CarId).HasColumnName("CarId").IsRequired();
        builder.Property(a => a.CustomerId).HasColumnName("CustomerId").IsRequired();
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

        builder.HasOne(p => p.Customer).WithMany(p => p.Appointments).HasForeignKey(p => p.CustomerId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(p => p.Car).WithMany(p => p.Appointments).HasForeignKey(p => p.CarId).OnDelete(DeleteBehavior.NoAction);

        builder.HasData(
            new Appointment()
            {
                Id = new Guid("72f3de2b-6f55-400b-9b17-7e9c7dcb3167"),
                CarId = new Guid("48f8a123-6b7d-4a2e-928b-c1e6beb2e7f2"),
                CustomerId = new Guid("b1e3b9cd-1c82-4f68-a70e-8349c28af525"),
                DateAndTime = new DateTime(2024, 07, 01, 14, 30, 00),
            }
            );

    }
}