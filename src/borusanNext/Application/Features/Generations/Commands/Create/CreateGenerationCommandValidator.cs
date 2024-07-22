using FluentValidation;

namespace Application.Features.Generations.Commands.Create;

public class CreateGenerationCommandValidator : AbstractValidator<CreateGenerationCommand>
{
    public CreateGenerationCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}