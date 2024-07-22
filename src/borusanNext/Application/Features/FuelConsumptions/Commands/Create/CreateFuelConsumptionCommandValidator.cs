using FluentValidation;

namespace Application.Features.FuelConsumptions.Commands.Create;

public class CreateFuelConsumptionCommandValidator : AbstractValidator<CreateFuelConsumptionCommand>
{
    public CreateFuelConsumptionCommandValidator()
    {
        RuleFor(c => c.OutOfTown).NotEmpty();
        RuleFor(c => c.Urban).NotEmpty();
        RuleFor(c => c.Average).NotEmpty();
    }
}