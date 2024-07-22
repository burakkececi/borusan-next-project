using FluentValidation;

namespace Application.Features.FuelConsumptions.Commands.Delete;

public class DeleteFuelConsumptionCommandValidator : AbstractValidator<DeleteFuelConsumptionCommand>
{
    public DeleteFuelConsumptionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}