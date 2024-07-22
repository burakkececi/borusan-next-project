using FluentValidation;

namespace Application.Features.BodyTypes.Commands.Create;

public class CreateBodyTypeCommandValidator : AbstractValidator<CreateBodyTypeCommand>
{
    public CreateBodyTypeCommandValidator()
    {
        RuleFor(c => c.BodyName).NotEmpty();
        RuleFor(c => c.Door).NotEmpty();
    }
}