using FluentValidation;

namespace Application.Features.CarColors.Commands.Create;

public class CreateCarColorCommandValidator : AbstractValidator<CreateCarColorCommand>
{
    public CreateCarColorCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}