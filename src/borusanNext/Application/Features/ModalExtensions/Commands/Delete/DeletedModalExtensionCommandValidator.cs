using FluentValidation;

namespace Application.Features.ModalExtensions.Commands.Delete;

public class DeleteModalExtensionCommandValidator : AbstractValidator<DeleteModalExtensionCommand>
{
    public DeleteModalExtensionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}