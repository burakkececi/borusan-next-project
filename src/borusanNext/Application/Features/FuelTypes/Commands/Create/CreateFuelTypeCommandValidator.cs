using FluentValidation;

namespace Application.Features.FuelTypes.Commands.Create;

public class CreateFuelTypeCommandValidator : AbstractValidator<CreateFuelTypeCommand>
{
    public CreateFuelTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}