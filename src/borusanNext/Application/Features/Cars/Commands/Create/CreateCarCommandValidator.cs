using FluentValidation;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(c => c.ChassisNumber).NotEmpty();
        RuleFor(c => c.Plate).NotEmpty();
        RuleFor(c => c.Kilometers).NotEmpty();
        RuleFor(c => c.SpareKey).NotEmpty();
        RuleFor(c => c.Inquiry).NotEmpty();
        RuleFor(c => c.WheelType).NotEmpty();
        RuleFor(c => c.SpareWheel).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.CarModelId).NotEmpty();
        RuleFor(c => c.ColorId).NotEmpty();
        RuleFor(c => c.EngineId).NotEmpty();
        RuleFor(c => c.BodyTypeId).NotEmpty();
        RuleFor(c => c.TransmissionId).NotEmpty();
        RuleFor(c => c.TramerId).NotEmpty();
        RuleFor(c => c.SellerId).NotEmpty();
    }
}