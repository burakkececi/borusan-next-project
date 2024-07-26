using FluentValidation;

namespace Application.Features.GenerationImages.Commands.Create;

public class CreateGenerationImageCommandValidator : AbstractValidator<CreateGenerationImageCommand>
{
    public CreateGenerationImageCommandValidator()
    {
        RuleFor(c => c.GenerationId).NotEmpty();
        RuleFor(c => c.ImageURL).NotEmpty();
    }
}