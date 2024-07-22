using FluentValidation;

namespace Application.Features.FuelTypes.Commands.Delete;

public class DeleteFuelTypeCommandValidator : AbstractValidator<DeleteFuelTypeCommand>
{
    public DeleteFuelTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}