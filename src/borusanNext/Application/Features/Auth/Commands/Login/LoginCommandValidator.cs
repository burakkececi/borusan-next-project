using FluentValidation;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(c => c.UserForLoginDto.Email).NotNull().NotEmpty().EmailAddress();
        RuleFor(c => c.UserForLoginDto.Password).NotNull().NotEmpty().MinimumLength(8);
    }
}
