using FluentValidation;

namespace Application.Features.CarColors.Commands.Create
{
    public class CreateCarColorCommandValidator : AbstractValidator<CreateCarColorCommand>
    {
        public CreateCarColorCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");
        }
    }
}
