using FluentValidation;

namespace Application.Features.GenerationImages.Commands.Create;

public class CreateGenerationImageCommandValidator : AbstractValidator<CreateGenerationImageCommand>
{
    public CreateGenerationImageCommandValidator()
    {
        RuleFor(c => c.GenerationId)
            .NotEmpty().WithMessage("GenerationId cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("GenerationId cannot be an empty GUID")
            .WithName("GenerationImage Create Generation ID");

        RuleFor(c => c.ImageURL)
            .NotEmpty().WithMessage("ImageURL cannot be empty")
            .WithName("GenerationImage Create Image URL");
    }
}