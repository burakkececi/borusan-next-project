using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System.Security.Cryptography;

namespace Domain.Entities;

public class User : Entity<Guid>
{
    public string Email { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public byte[]? PasswordHash { get; set; }
    public AuthenticatorType AuthenticatorType { get; set; }
    public AuthProvider Provider { get; set; }

    public User()
    {
        Email = string.Empty;
        PasswordHash = Array.Empty<byte>();
        PasswordSalt = Array.Empty<byte>();
    }
    public User(string email, AuthenticatorType authenticatorType, AuthProvider authProvider)
    {
        Email = email;
        AuthenticatorType = authenticatorType;
        Provider = authProvider;
    }
    public User(string email, byte[] passwordSalt, byte[] passwordHash, AuthenticatorType authenticatorType, AuthProvider authProvider)
    {
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        AuthenticatorType = authenticatorType;
        Provider = authProvider;
    }

    public User(Guid id, string email, byte[] passwordSalt, byte[] passwordHash, AuthenticatorType authenticatorType, AuthProvider authProvider)
        : base(id)
    {
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        AuthenticatorType = authenticatorType;
        Provider = authProvider;
    }
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = default!;
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = default!;
    public virtual ICollection<EmailAuthenticator> EmailAuthenticators { get; set; } = default!;

    public virtual Customer Customer { get; set; }
    public virtual Seller Seller { get; set; }
}
