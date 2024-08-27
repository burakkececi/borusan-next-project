using FluentValidation;

namespace Application.Features.ChassisParts.Commands.Create
{
    public class CreateChassisPartCommandValidator : AbstractValidator<CreateChassisPartCommand>
    {
        public CreateChassisPartCommandValidator()
        {
            RuleFor(c => c.IsRightChassisChanged)
                 .NotNull().WithMessage("IsRightChassisChanged cannot be null.");

            RuleFor(c => c.IsLeftChassisChanged)
                .NotNull().WithMessage("IsLeftChassisChanged cannot be null.");

            RuleFor(c => c.IsFrontPanelChanged)
                .NotNull().WithMessage("IsFrontPanelChanged cannot be null.");

            RuleFor(c => c.IsBackPanelChanged)
                .NotNull().WithMessage("IsBackPanelChanged cannot be null.");
        }
    }
}
