using FluentValidation;

namespace Application.Features.GenerationImages.Commands.Delete;

public class DeleteGenerationImageCommandValidator : AbstractValidator<DeleteGenerationImageCommand>
{
    public DeleteGenerationImageCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("GenerationImage Delete Id");
    }
}