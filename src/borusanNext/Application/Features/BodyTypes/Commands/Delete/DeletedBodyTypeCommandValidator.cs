using FluentValidation;

namespace Application.Features.BodyTypes.Commands.Delete;

public class DeleteBodyTypeCommandValidator : AbstractValidator<DeleteBodyTypeCommand>
{
    public DeleteBodyTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}