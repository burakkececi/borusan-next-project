using FluentValidation;

namespace Application.Features.ExpertizeResults.Commands.Delete;

public class DeleteExpertizeResultCommandValidator : AbstractValidator<DeleteExpertizeResultCommand>
{
    public DeleteExpertizeResultCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}