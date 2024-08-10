using FluentValidation;

namespace Application.Features.Tags.Commands.Delete;

public class DeleteTagCommandValidator : AbstractValidator<DeleteTagCommand>
{
    public DeleteTagCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("Tag Delete Id");
    }
}