using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.ToTable("Blogs").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Title).HasColumnName("Title").IsRequired();
        builder.Property(b => b.Description).HasColumnName("Description").IsRequired();
        builder.Property(b => b.Banner).HasColumnName("Banner").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        builder.HasData(
            new Blog()
            {
                Id = new Guid("1c1fac0a-4c1f-4ade-bded-a9b7a28df01b"),
                Title = "İkinci El Arabanın Yeni Adresi Borusan Next!",
                Description = "Borusan Otomotiv Grubu'nun tek çatı altında çoklu marka ve çoklu kanal stratejisi vizyonu doğrultusunda oluşturulan ikinci el otomobil platformu Borusan Next, kendi lokasyonlarında, teknoloji, güven, hız ve premium müşteri deneyimi odaklı bir yaklaşım ile kullanılmış otomobil alım, satım, takas ve iş ortakları vasıtasıyla da finansman ve sigorta çözümleri sunuyor.",
                Banner = "https://res.cloudinary.com/dl0cotczj/image/upload/v1722923108/g09uyd5sinylzgo2xtjj.jpg"
            },
            new Blog()
            {
                Id = new Guid("6321910f-01ee-47be-b65e-8868ffecb023"),
                Title = "Hız Tutkunları Motoru Nextten...",
                Description = "Borusan Otomotiv Grubu'nun tek çatı altında çoklu marka ve çoklu kanal stratejisi vizyonu doğrultusunda oluşturulan ikinci el otomobil platformu Borusan Next, kendi lokasyonlarında, teknoloji, güven, hız ve premium müşteri deneyimi odaklı bir yaklaşım ile kullanılmış otomobil alım, satım, takas ve iş ortakları vasıtasıyla da finansman ve sigorta çözümleri sunuyor.",
                Banner = "https://res.cloudinary.com/dl0cotczj/image/upload/v1722923108/roar5vpmq5y2btncajl2.jpg"
            },
            new Blog()
            {
                Id = new Guid("d323a479-a0f5-4347-a764-698be769fb57"),
                Title = "Burası Harika Bir Title!",
                Description = "Borusan Otomotiv Grubu'nun tek çatı altında çoklu marka ve çoklu kanal stratejisi vizyonu doğrultusunda oluşturulan ikinci el otomobil platformu Borusan Next, kendi lokasyonlarında, teknoloji, güven, hız ve premium müşteri deneyimi odaklı bir yaklaşım ile kullanılmış otomobil alım, satım, takas ve iş ortakları vasıtasıyla da finansman ve sigorta çözümleri sunuyor.",
                Banner = "https://res.cloudinary.com/dl0cotczj/image/upload/v1722923108/cnhqv7ttffz6297xulca.jpg"
            }
            );
    }
}