using FluentValidation;

namespace Application.Features.ExpertizeResults.Commands.Delete;

public class DeleteExpertizeResultCommandValidator : AbstractValidator<DeleteExpertizeResultCommand>
{
    public DeleteExpertizeResultCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEqual(Guid.Empty).WithMessage("Id cannot be an empty GUID")
            .WithName("ExpertizeResults Delete Id");
    }
}