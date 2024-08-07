using FluentValidation;

namespace Application.Features.Generations.Commands.Delete;

public class DeleteGenerationCommandValidator : AbstractValidator<DeleteGenerationCommand>
{
    public DeleteGenerationCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("Generation Delete Id");
    }
}