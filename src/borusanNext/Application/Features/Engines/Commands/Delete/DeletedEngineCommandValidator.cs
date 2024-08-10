using FluentValidation;

namespace Application.Features.Engines.Commands.Delete;

public class DeleteEngineCommandValidator : AbstractValidator<DeleteEngineCommand>
{
    public DeleteEngineCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("Engine Delete Id");
    }
}