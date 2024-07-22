using FluentValidation;

namespace Application.Features.CarModels.Commands.Update;

public class UpdateCarModelCommandValidator : AbstractValidator<UpdateCarModelCommand>
{
    public UpdateCarModelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BrandId).NotEmpty();
        RuleFor(c => c.ModelName).NotEmpty();
        RuleFor(c => c.Lenght).NotEmpty();
        RuleFor(c => c.Width).NotEmpty();
        RuleFor(c => c.Height).NotEmpty();
        RuleFor(c => c.FuelTank).NotEmpty();
        RuleFor(c => c.LuggageCapacity).NotEmpty();
        RuleFor(c => c.EmptyWeight).NotEmpty();
        RuleFor(c => c.ModelYear).NotEmpty();
        RuleFor(c => c.CarId).NotEmpty();
        RuleFor(c => c.ModalExtensionId).NotEmpty();
    }
}