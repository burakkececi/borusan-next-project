using FluentValidation;

namespace Application.Features.ModalExtensions.Commands.Update;

public class UpdateModalExtensionCommandValidator : AbstractValidator<UpdateModalExtensionCommand>
{
    public UpdateModalExtensionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Lenght).NotEmpty();
        RuleFor(c => c.Width).NotEmpty();
        RuleFor(c => c.Height).NotEmpty();
        RuleFor(c => c.FuelTank).NotEmpty();
        RuleFor(c => c.LuggageCapacity).NotEmpty();
        RuleFor(c => c.EmptyWeight).NotEmpty();
        RuleFor(c => c.ModelYear).NotEmpty();
        RuleFor(c => c.CarModelId).NotEmpty();
        RuleFor(c => c.GenerationId).NotEmpty();
    }
}