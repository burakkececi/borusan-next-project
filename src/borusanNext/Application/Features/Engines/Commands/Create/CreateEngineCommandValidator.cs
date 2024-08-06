using FluentValidation;

namespace Application.Features.Engines.Commands.Create;

public class CreateEngineCommandValidator : AbstractValidator<CreateEngineCommand>
{
    public CreateEngineCommandValidator()
    {
        RuleFor(c => c.EngineNo).NotEmpty();
        RuleFor(c => c.EngineCapacity).NotEmpty();
        RuleFor(c => c.MotorPower).NotEmpty();
        RuleFor(c => c.MaximumTorque).NotEmpty();
        RuleFor(c => c.Acceleration).NotEmpty();
        RuleFor(c => c.MaximumSpeed).NotEmpty();
        RuleFor(c => c.FuelTankVolume).NotEmpty();
        RuleFor(c => c.FuelTypeId).NotEmpty();
        RuleFor(c => c.OutOfTownConsumptionRate).NotEmpty();
        RuleFor(c => c.UrbanConsumptionRate).NotEmpty();
        RuleFor(c => c.AverageConsumptionRate).NotEmpty();

    }
}
