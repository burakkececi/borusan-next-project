using FluentValidation;

namespace Application.Features.FuelConsumptions.Commands.Update;

public class UpdateFuelConsumptionCommandValidator : AbstractValidator<UpdateFuelConsumptionCommand>
{
    public UpdateFuelConsumptionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.OutOfTown).NotEmpty();
        RuleFor(c => c.Urban).NotEmpty();
        RuleFor(c => c.Average).NotEmpty();
    }
}