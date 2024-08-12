using FluentValidation;

namespace Application.Features.BodyTypes.Commands.Update
{
    public class UpdateBodyTypeCommandValidator : AbstractValidator<UpdateBodyTypeCommand>
    {
        public UpdateBodyTypeCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id cannot be empty.");

            RuleFor(c => c.BodyName)
                .NotEmpty().WithMessage("BodyName cannot be empty.")
                .MaximumLength(50).WithMessage("BodyName must not exceed 50 characters.");

            RuleFor(c => c.Door)
                .NotEmpty().WithMessage("Door cannot be empty.")
                .MaximumLength(20).WithMessage("Door must not exceed 20 characters.");
        }
    }
}
