using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ExpertizeResultConfiguration : IEntityTypeConfiguration<ExpertizeResult>
{
    public void Configure(EntityTypeBuilder<ExpertizeResult> builder)
    {
        builder.ToTable("ExpertizeResults").HasKey(er => er.Id);

        builder.Property(er => er.Id).HasColumnName("Id").IsRequired();
        builder.Property(er => er.CarDamageInformationRecord).HasColumnName("CarDamageInformationRecord").IsRequired();
        builder.Property(er => er.InquiryDate).HasColumnName("InquiryDate").IsRequired();
        builder.Property(er => er.ChassisPartId).HasColumnName("ChassisPartId").IsRequired();
        builder.Property(er => er.BodyShellPartId).HasColumnName("BodyShellPartId").IsRequired();
        builder.Property(er => er.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(er => er.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(er => er.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(er => !er.DeletedDate.HasValue);

        builder.HasOne(p => p.ChassisPart).WithOne(p => p.ExpertizeResult).HasForeignKey<ExpertizeResult>(p => p.ChassisPartId);
        builder.HasOne(p => p.BodyShellPart).WithOne(p => p.ExpertizeResult).HasForeignKey<ExpertizeResult>(p => p.BodyShellPartId);
    }
}