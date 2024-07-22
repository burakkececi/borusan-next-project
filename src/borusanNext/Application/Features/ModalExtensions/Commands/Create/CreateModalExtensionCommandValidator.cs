using FluentValidation;

namespace Application.Features.ModalExtensions.Commands.Create;

public class CreateModalExtensionCommandValidator : AbstractValidator<CreateModalExtensionCommand>
{
    public CreateModalExtensionCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.CarModelId).NotEmpty();
        RuleFor(c => c.GenerationId).NotEmpty();
    }
}