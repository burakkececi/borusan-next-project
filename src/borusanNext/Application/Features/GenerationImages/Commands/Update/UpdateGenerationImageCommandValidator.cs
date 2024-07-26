using FluentValidation;

namespace Application.Features.GenerationImages.Commands.Update;

public class UpdateGenerationImageCommandValidator : AbstractValidator<UpdateGenerationImageCommand>
{
    public UpdateGenerationImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.GenerationId).NotEmpty();
        RuleFor(c => c.ImageURL).NotEmpty();
    }
}