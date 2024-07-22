using FluentValidation;

namespace Application.Features.BodyShellParts.Commands.Update;

public class UpdateBodyShellPartCommandValidator : AbstractValidator<UpdateBodyShellPartCommand>
{
    public UpdateBodyShellPartCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LeftFrontFender).NotEmpty();
        RuleFor(c => c.LeftFrontDoor).NotEmpty();
        RuleFor(c => c.LeftRearDoor).NotEmpty();
        RuleFor(c => c.LeftRearFender).NotEmpty();
        RuleFor(c => c.RightFrontFender).NotEmpty();
        RuleFor(c => c.RightFrontDoor).NotEmpty();
        RuleFor(c => c.RightRearDoor).NotEmpty();
        RuleFor(c => c.RightRearFender).NotEmpty();
        RuleFor(c => c.Frontbumper).NotEmpty();
        RuleFor(c => c.RearBumper).NotEmpty();
        RuleFor(c => c.Bonnet).NotEmpty();
        RuleFor(c => c.Ceiling).NotEmpty();
        RuleFor(c => c.Luggage).NotEmpty();
    }
}