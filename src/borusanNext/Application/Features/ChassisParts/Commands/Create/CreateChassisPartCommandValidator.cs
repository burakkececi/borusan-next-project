using FluentValidation;

namespace Application.Features.ChassisParts.Commands.Create;

public class CreateChassisPartCommandValidator : AbstractValidator<CreateChassisPartCommand>
{
    public CreateChassisPartCommandValidator()
    {
        RuleFor(c => c.IsRightChassisChanged).NotEmpty();
        RuleFor(c => c.IsLeftChassisChanged).NotEmpty();
        RuleFor(c => c.IsFrontPanelChanged).NotEmpty();
        RuleFor(c => c.IsBackPanelChanged).NotEmpty();
    }
}