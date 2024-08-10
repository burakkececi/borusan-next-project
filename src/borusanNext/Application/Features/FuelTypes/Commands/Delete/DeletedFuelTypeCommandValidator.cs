using FluentValidation;

namespace Application.Features.FuelTypes.Commands.Delete;

public class DeleteFuelTypeCommandValidator : AbstractValidator<DeleteFuelTypeCommand>
{
    public DeleteFuelTypeCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("FuelTypes Update Id");
    }
}