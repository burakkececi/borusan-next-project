using FluentValidation;

namespace Application.Features.Engines.Commands.Update;

public class UpdateEngineCommandValidator : AbstractValidator<UpdateEngineCommand>
{
    public UpdateEngineCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("Engine Update Id");

        RuleFor(c => c.EngineNo)
            .NotNull().WithMessage("EngineNo cannot be null")
            .NotEmpty().WithMessage("EngineNo cannot be empty")
            .Matches(@"^ENG.{9}$").WithMessage("EngineNo must start with 'ENG' and be exactly 12 characters long")
            .WithName("Engine Update EngineNo");

        RuleFor(c => c.EngineCapacity)
            .NotNull().WithMessage("EngineCapacity cannot be null")
            .GreaterThan(0).WithMessage("EngineCapacity must be greater than 0")
            .WithName("Engine Update EngineCapacity");

        RuleFor(c => c.MotorPower)
            .NotNull().WithMessage("MotorPower cannot be null")
            .GreaterThan(0).WithMessage("MotorPower must be greater than 0")
            .WithName("Engine Update MotorPower");

        RuleFor(c => c.MaximumTorque)
            .NotNull().WithMessage("MaximumTorque cannot be null")
            .GreaterThan(0).WithMessage("MaximumTorque must be greater than 0")
            .WithName("Engine Update MaximumTorque");

        RuleFor(c => c.Acceleration)
            .NotNull().WithMessage("Acceleration cannot be null")
            .GreaterThan(0).WithMessage("Acceleration must be greater than 0")
            .WithName("Engine Update Acceleration");

        RuleFor(c => c.MaximumSpeed)
            .NotNull().WithMessage("MaximumSpeed cannot be null")
            .GreaterThan(0).WithMessage("MaximumSpeed must be greater than 0")
            .WithName("Engine Update MaximumSpeed");

        RuleFor(c => c.FuelTankVolume)
            .NotNull().WithMessage("FuelTankVolume cannot be null")
            .GreaterThan(0).WithMessage("FuelTankVolume must be greater than 0")
            .WithName("Engine Update FuelTankVolume");

        RuleFor(c => c.OutOfTownConsumptionRate)
            .NotNull().WithMessage("OutOfTownConsumptionRate cannot be null")
            .GreaterThan(0).WithMessage("OutOfTownConsumptionRate must be greater than 0")
            .WithName("Engine Update OutOfTownConsumptionRate");

        RuleFor(c => c.UrbanConsumptionRate)
            .NotNull().WithMessage("UrbanConsumptionRate cannot be null")
            .GreaterThan(0).WithMessage("UrbanConsumptionRate must be greater than 0")
            .WithName("Engine Update UrbanConsumptionRate");

        RuleFor(c => c.AverageConsumptionRate)
            .NotNull().WithMessage("AverageConsumptionRate cannot be null")
            .GreaterThan(0).WithMessage("AverageConsumptionRate must be greater than 0")
            .WithName("Engine Update AverageConsumptionRate");

        RuleFor(c => c.FuelTypeId)
            .NotNull().WithMessage("FuelTypeId cannot be null")
            .NotEqual(Guid.Empty).WithMessage("FuelTypeId cannot be an empty GUID")
            .WithName("Engine Update FuelTypeId");

    }
}
