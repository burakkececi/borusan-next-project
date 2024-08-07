using FluentValidation;

namespace Application.Features.FuelTypes.Commands.Update;

public class UpdateFuelTypeCommandValidator : AbstractValidator<UpdateFuelTypeCommand>
{
    public UpdateFuelTypeCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("FuelTypes Update Id");

        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name cannot be empty")
            .MinimumLength(3).WithMessage("Name length must be at least 3")
            .MaximumLength(100).WithMessage("Name length can be up to 100")
            .WithName("FuelTypes Update Name");
    }
}