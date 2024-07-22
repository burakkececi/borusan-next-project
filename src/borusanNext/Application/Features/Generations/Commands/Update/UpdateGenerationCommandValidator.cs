using FluentValidation;

namespace Application.Features.Generations.Commands.Update;

public class UpdateGenerationCommandValidator : AbstractValidator<UpdateGenerationCommand>
{
    public UpdateGenerationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}