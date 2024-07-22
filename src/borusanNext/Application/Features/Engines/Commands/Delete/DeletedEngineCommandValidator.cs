using FluentValidation;

namespace Application.Features.Engines.Commands.Delete;

public class DeleteEngineCommandValidator : AbstractValidator<DeleteEngineCommand>
{
    public DeleteEngineCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}