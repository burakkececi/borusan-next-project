using FluentValidation;

namespace Application.Features.Engines.Commands.Update;

public class UpdateEngineCommandValidator : AbstractValidator<UpdateEngineCommand>
{
    public UpdateEngineCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
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
