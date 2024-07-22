using FluentValidation;

namespace Application.Features.Generations.Commands.Delete;

public class DeleteGenerationCommandValidator : AbstractValidator<DeleteGenerationCommand>
{
    public DeleteGenerationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}