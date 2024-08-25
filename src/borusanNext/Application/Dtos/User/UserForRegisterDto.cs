using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.User;
public class UserForRegisterDto : IDto
{
    public string Email { get; set; }

    public string? Password { get; set; }

    public int AuthProvider { get; set; }

    public UserForRegisterDto()
    {
        Email = string.Empty;
        Password = string.Empty;
        AuthProvider = 0;
    }

    public UserForRegisterDto(string email, string password)
    {
        Email = email;
        Password = password;
        AuthProvider = 0;
    }

    public UserForRegisterDto(string email, int authProvider)
    {
        Email = email;
        AuthProvider = authProvider;
    }
}