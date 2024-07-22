using FluentValidation;

namespace Application.Features.ChassisParts.Commands.Update;

public class UpdateChassisPartCommandValidator : AbstractValidator<UpdateChassisPartCommand>
{
    public UpdateChassisPartCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.IsRightChassisChanged).NotEmpty();
        RuleFor(c => c.IsLeftChassisChanged).NotEmpty();
        RuleFor(c => c.IsFrontPanelChanged).NotEmpty();
        RuleFor(c => c.IsBackPanelChanged).NotEmpty();
    }
}