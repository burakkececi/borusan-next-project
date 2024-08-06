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

        builder.HasData(
            new ExpertizeResult()
            {
                Id = new Guid("47e992e3-6561-49ff-a827-0e19aaf10345"),
                CarDamageInformationRecord = 30000,
                InquiryDate = new DateTime(2022, 01, 15),
                ChassisPartId = new Guid("e59f7e66-cc28-4270-84ed-aa6812f00935"),
                BodyShellPartId = new Guid("3eeff5e8-58ab-4f64-82a9-05d77b83b4ef"),
            },
            new ExpertizeResult()
            {
                Id = new Guid("0ce199f9-3627-44bb-b3c2-fbd72c6799c2"),
                CarDamageInformationRecord = 0,
                InquiryDate = new DateTime(2021, 11, 05),
                ChassisPartId = new Guid("352dd90f-0292-4613-b5d9-3540a723c6dc"),
                BodyShellPartId = new Guid("8c9d2d89-affb-4202-9953-ab86cf490ca0"),
            },
            new ExpertizeResult()
            {
                Id = new Guid("b8cb292b-c61b-4c73-9f20-f8fe2b746b5a"),
                CarDamageInformationRecord = 4000,
                InquiryDate = new DateTime(2020, 10, 25),
                ChassisPartId = new Guid("85262f34-ace7-4f68-8b20-8ed9a0fd77c6"),
                BodyShellPartId = new Guid("db7257a0-5a57-4960-8a34-7f4f798470a2"),
            }
            );
    }
}