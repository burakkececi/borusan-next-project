using FluentValidation;

namespace Application.Features.Generations.Commands.Update;

public class UpdateGenerationCommandValidator : AbstractValidator<UpdateGenerationCommand>
{
    public UpdateGenerationCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("Generation Delete Id");

        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name cannot be empty")
            .MinimumLength(3).WithMessage("Name length must be at least 3")
            .MaximumLength(100).WithMessage("Name length can be up to 100")
            .WithName("Generation Update Name");
    }
}