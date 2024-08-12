using FluentValidation;

namespace Application.Features.ChassisParts.Commands.Delete
{
    public class DeleteChassisPartCommandValidator : AbstractValidator<DeleteChassisPartCommand>
    {
        public DeleteChassisPartCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id cannot be empty.");
        }
    }
}
