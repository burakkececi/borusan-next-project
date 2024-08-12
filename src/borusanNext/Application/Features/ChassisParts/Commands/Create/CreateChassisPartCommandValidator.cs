using FluentValidation;

namespace Application.Features.ChassisParts.Commands.Create
{
    public class CreateChassisPartCommandValidator : AbstractValidator<CreateChassisPartCommand>
    {
        public CreateChassisPartCommandValidator()
        {
            RuleFor(c => c.IsRightChassisChanged)
                .NotEmpty().WithMessage("IsRightChassisChanged cannot be empty.");

            RuleFor(c => c.IsLeftChassisChanged)
                .NotEmpty().WithMessage("IsLeftChassisChanged cannot be empty.");

            RuleFor(c => c.IsFrontPanelChanged)
                .NotEmpty().WithMessage("IsFrontPanelChanged cannot be empty.");

            RuleFor(c => c.IsBackPanelChanged)
                .NotEmpty().WithMessage("IsBackPanelChanged cannot be empty.");
        }
    }
}
