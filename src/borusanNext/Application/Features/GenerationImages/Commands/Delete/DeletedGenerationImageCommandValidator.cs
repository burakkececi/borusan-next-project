using FluentValidation;

namespace Application.Features.GenerationImages.Commands.Delete;

public class DeleteGenerationImageCommandValidator : AbstractValidator<DeleteGenerationImageCommand>
{
    public DeleteGenerationImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}