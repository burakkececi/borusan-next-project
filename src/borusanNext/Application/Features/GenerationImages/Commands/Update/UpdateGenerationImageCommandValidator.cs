using FluentValidation;

namespace Application.Features.GenerationImages.Commands.Update;

public class UpdateGenerationImageCommandValidator : AbstractValidator<UpdateGenerationImageCommand>
{
    public UpdateGenerationImageCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("GenerationImage Update Id");

        RuleFor(c => c.GenerationId)
            .NotEmpty().WithMessage("GenerationId cannot be empty")
            .NotEqual(Guid.Empty).WithMessage("GenerationId cannot be an empty GUID")
            .WithName("GenerationImage Create Generation ID");

        RuleFor(c => c.ImageURL)
            .NotEmpty().WithMessage("ImageURL cannot be empty")
            .WithName("GenerationImage Create Image URL");
    }
}