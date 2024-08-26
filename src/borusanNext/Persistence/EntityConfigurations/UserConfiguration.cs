using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Hashing;

namespace Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType").IsRequired();
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").HasColumnType("timestamp").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("timestamp");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate").HasColumnType("timestamp");

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        builder.HasMany(u => u.UserOperationClaims);
        builder.HasMany(u => u.RefreshTokens);
        builder.HasMany(u => u.EmailAuthenticators);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static Guid AdminId { get; } = Guid.NewGuid();
    private IEnumerable<User> _seeds
    {
        get
        {
            HashingHelper.CreatePasswordHash(
                password: "Passw0rd!",
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            var users = new List<User>() {
                new()
                {
                    Id = AdminId,
                    Email = "admin@borusan.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                },
                new()
                {
                    Id = new Guid("b73f6541-460e-4d9d-97eb-1402f63df038"),
                    Email = "avcilar@borusan.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                },
                new()
                {
                    Id = new Guid("69bd8e0f-59d4-4532-ae32-03cec3e39158"),
                    Email = "samandira@borusan.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                },
                new()
                {
                    Id = new Guid("398b5d31-f2e2-473f-8f40-78f7e79af217"),
                    Email = "kececi@borusan.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                },
                new()
                {
                    Id = new Guid("6444d306-ab8e-4e84-a6ff-77037d68fd2e"),
                    Email = "burak@borusan.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                },
                new()
                {
                    Id = new Guid("bd4dd3dc-72e4-42cb-bde3-0fcb1867b10d"),
                    Email = "meryem@borusan.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                },
                new()
                {
                    Id = new Guid("ada31c5d-6014-46d2-a1c3-ed8007e898cf"),
                    Email = "ali@borusan.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                },
                new()
                {
                    Id = new Guid("36160d4c-8a2a-4959-9769-ebf2bd812237"),
                    Email = "sefa@borusan.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                }
            };

            return users;
        }
    }
}
