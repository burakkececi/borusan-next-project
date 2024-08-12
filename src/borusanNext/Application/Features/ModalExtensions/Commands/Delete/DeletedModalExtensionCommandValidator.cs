using FluentValidation;

namespace Application.Features.ModalExtensions.Commands.Delete;

public class DeleteModalExtensionCommandValidator : AbstractValidator<DeleteModalExtensionCommand>
{
    public DeleteModalExtensionCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("ModalExtension Delete Id");
    }
}