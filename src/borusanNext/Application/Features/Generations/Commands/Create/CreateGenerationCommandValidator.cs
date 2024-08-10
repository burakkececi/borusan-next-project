using FluentValidation;

namespace Application.Features.Generations.Commands.Create;

public class CreateGenerationCommandValidator : AbstractValidator<CreateGenerationCommand>
{
    public CreateGenerationCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name cannot be empty")
            .MinimumLength(3).WithMessage("Name length must be at least 3")
            .MaximumLength(100).WithMessage("Name length can be up to 100")
            .WithName("Generation Create Name");
    }
}