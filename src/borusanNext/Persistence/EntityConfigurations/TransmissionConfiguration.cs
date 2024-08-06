using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TransmissionConfiguration : IEntityTypeConfiguration<Transmission>
{
    public void Configure(EntityTypeBuilder<Transmission> builder)
    {
        builder.ToTable("Transmissions").HasKey(t => t.Id);

        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.Name).HasColumnName("Name").IsRequired();
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);

        builder.HasData(
            new Transmission()
            {
                Id = new Guid("b830d944-aa1b-4074-9a24-1ff60f1cd38d"),
                Name = "Automatic"
            },
            new Transmission()
            {
                Id = new Guid("2c450873-2f0b-4da2-a7ff-245ca5c73e19"),
                Name = "Manuel"
            }
            );
    }
}