using FluentValidation;

namespace Application.Features.BodyTypes.Commands.Update;

public class UpdateBodyTypeCommandValidator : AbstractValidator<UpdateBodyTypeCommand>
{
    public UpdateBodyTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BodyName).NotEmpty();
        RuleFor(c => c.Door).NotEmpty();
    }
}