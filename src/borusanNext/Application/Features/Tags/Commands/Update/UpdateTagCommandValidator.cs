using FluentValidation;

namespace Application.Features.Tags.Commands.Update;

public class UpdateTagCommandValidator : AbstractValidator<UpdateTagCommand>
{
    public UpdateTagCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("Tag Delete Id");

        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name cannot be empty")
            .WithName("Name");
    }
}