using FluentValidation;

namespace Application.Features.BodyShellParts.Commands.Delete;

public class DeleteBodyShellPartCommandValidator : AbstractValidator<DeleteBodyShellPartCommand>
{
    public DeleteBodyShellPartCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}