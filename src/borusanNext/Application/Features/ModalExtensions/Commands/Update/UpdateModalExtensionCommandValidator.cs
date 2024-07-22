using FluentValidation;

namespace Application.Features.ModalExtensions.Commands.Update;

public class UpdateModalExtensionCommandValidator : AbstractValidator<UpdateModalExtensionCommand>
{
    public UpdateModalExtensionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.CarModelId).NotEmpty();
        RuleFor(c => c.GenerationId).NotEmpty();
    }
}