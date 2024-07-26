using FluentValidation;

namespace Application.Features.ModalExtensions.Commands.Create;

public class CreateModalExtensionCommandValidator : AbstractValidator<CreateModalExtensionCommand>
{
    public CreateModalExtensionCommandValidator()
    {
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