using FluentValidation;

namespace Application.Features.BodyTypes.Commands.Create
{
    public class CreateBodyTypeCommandValidator : AbstractValidator<CreateBodyTypeCommand>
    {
        public CreateBodyTypeCommandValidator()
        {
            RuleFor(c => c.BodyName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("BodyName cannot be empty.")
                .NotNull().WithMessage("BodyName cannot be null.")
                .MaximumLength(50).WithMessage("BodyName must not exceed 50 characters.");

            RuleFor(c => c.Door)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Door cannot be empty.")
                .NotNull().WithMessage("Door cannot be null.")
                .MaximumLength(20).WithMessage("Door must not exceed 20 characters.");
        }
    }
}
