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
        builder.Property(a => a.Date).HasColumnName("Date").IsRequired();
        builder.Property(a => a.Time).HasColumnName("Time").IsRequired();
        builder.Property(a => a.CarId).HasColumnName("CarId").IsRequired();
        builder.Property(a => a.CustomerId).HasColumnName("CustomerId").IsRequired();
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

        builder.HasOne(p => p.Customer).WithMany(p => p.Appointments).HasForeignKey(p => p.CustomerId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(p => p.Car).WithMany(p => p.Appointments).HasForeignKey(p => p.CarId).OnDelete(DeleteBehavior.NoAction);


    }
}