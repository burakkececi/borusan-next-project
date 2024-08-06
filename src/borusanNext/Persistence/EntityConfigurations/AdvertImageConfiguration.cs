using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AdvertImageConfiguration : IEntityTypeConfiguration<AdvertImage>
{
    public void Configure(EntityTypeBuilder<AdvertImage> builder)
    {
        builder.ToTable("AdvertImages").HasKey(ai => ai.Id);

        builder.Property(ai => ai.Id).HasColumnName("Id").IsRequired();
        builder.Property(ai => ai.AdvertId).HasColumnName("AdvertId").IsRequired();
        builder.Property(ai => ai.ImageURL).HasColumnName("ImageURL").IsRequired();
        builder.Property(ai => ai.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(ai => ai.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(ai => ai.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(ai => !ai.DeletedDate.HasValue);

        builder.HasData(
            new AdvertImage()
            {
                Id = new Guid("31895bc7-6acb-47ab-b17e-c25cdf4e206a"),
                AdvertId = new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"),
                ImageURL = "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927430/wkhtgdd9329qljrwrtct.jpg"
            },
            new AdvertImage()
            {
                Id = new Guid("abff24eb-4e70-4ed8-9628-6cbae7351290"),
                AdvertId = new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"),
                ImageURL = "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927430/dsjdl0uscjqi7dpwvjbb.jpg"
            },
            new AdvertImage()
            {
                Id = new Guid("9b099ef1-1465-457a-8f53-fe1322cbd1cc"),
                AdvertId = new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"),
                ImageURL = "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927433/rq2hr77xj9psnaau2qed.jpg"
            },
            new AdvertImage()
            {
                Id = new Guid("48360d95-19b9-4dc6-a5f9-ed7150ecd965"),
                AdvertId = new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"),
                ImageURL = "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927432/mkkciln87ynjbnje13ft.jpg"
            },
            new AdvertImage()
            {
                Id = new Guid("b755d05c-57f6-4929-ace4-5478f32dadb4"),
                AdvertId = new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"),
                ImageURL = "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927431/iwqgm7levti1a1peom4i.jpg"
            },
            new AdvertImage()
            {
                Id = new Guid("41d24792-ce26-41a7-ab03-86dd2b20da0e"),
                AdvertId = new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"),
                ImageURL = "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927430/e1trhsymprfpj4cv8qsj.jpg"
            },
            new AdvertImage()
            {
                Id = new Guid("e6bd50d8-861e-4696-8be6-74ed1a268090"),
                AdvertId = new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"),
                ImageURL = "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927429/x8tr1bwix1qafh6ekps2.jpg"
            },
            new AdvertImage()
            {
                Id = new Guid("4003779f-2f80-44aa-9569-737c0fa8fd5e"),
                AdvertId = new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"),
                ImageURL = "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927428/hdfqjaqsgg9ujzkmmg8k.jpg"
            },
            new AdvertImage()
            {
                Id = new Guid("9439d26c-d71c-4fb4-948f-bcf7969875b0"),
                AdvertId = new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"),
                ImageURL = "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927428/sjswo927ezke9ad4ehiq.jpg"
            },
            new AdvertImage()
            {
                Id = new Guid("7ad496e8-4960-42e5-947e-3af49eb2b54b"),
                AdvertId = new Guid("8e23dc9d-8db3-4ac8-93e4-369fe02c17dc"),
                ImageURL = "https://res.cloudinary.com/dl0cotczj/image/upload/v1722927427/uebfhjzoiofr0epripub.jpg"
            }
            );
    }
}