using NArchitecture.Core.Application.Dtos;
namespace Application.Dtos.User;
public class UserForLoginDto : IDto
{
    public string Email { get; set; }
    public string? Password { get; set; }
    public string? AuthenticatorCode { get; set; }
    public int AuthProvider { get; set; }

    public UserForLoginDto()
    {
        Email = string.Empty;
        Password = string.Empty;
        AuthProvider = 0;
    }

    public UserForLoginDto(string email, string password)
    {
        Email = email;
        Password = password;
        AuthProvider = 0;
    }

    public UserForLoginDto(string email, int authProvider)
    {
        Email = email;
        AuthProvider = authProvider;
    }
}