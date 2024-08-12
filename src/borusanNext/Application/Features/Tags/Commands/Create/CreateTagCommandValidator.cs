using FluentValidation;

namespace Application.Features.Tags.Commands.Create;

public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
{
    public CreateTagCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name cannot be empty")
            .WithName("Name");
    }
}