using FluentValidation;

namespace Application.Features.FuelTypes.Commands.Create;

public class CreateFuelTypeCommandValidator : AbstractValidator<CreateFuelTypeCommand>
{
    public CreateFuelTypeCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name cannot be empty")
            .MinimumLength(3).WithMessage("Name length must be at least 3")
            .MaximumLength(100).WithMessage("Name length can be up to 100")
            .WithName("FuelTypes Create Name");
    }
}