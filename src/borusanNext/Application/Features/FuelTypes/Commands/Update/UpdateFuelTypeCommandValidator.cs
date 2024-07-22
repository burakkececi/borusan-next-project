using FluentValidation;

namespace Application.Features.FuelTypes.Commands.Update;

public class UpdateFuelTypeCommandValidator : AbstractValidator<UpdateFuelTypeCommand>
{
    public UpdateFuelTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}