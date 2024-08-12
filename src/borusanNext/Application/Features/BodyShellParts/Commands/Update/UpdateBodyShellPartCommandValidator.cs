using FluentValidation;

namespace Application.Features.BodyShellParts.Commands.Update
{
    public class UpdateBodyShellPartCommandValidator : AbstractValidator<UpdateBodyShellPartCommand>
    {
        public UpdateBodyShellPartCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id cannot be empty.");
            RuleFor(c => c.LeftFrontFender)
                .NotNull().WithMessage("LeftFrontFender cannot be null.")
                .IsInEnum().WithMessage("LeftFrontFender must be a valid ExpertizeCondition.");

            RuleFor(c => c.LeftFrontDoor)
                .NotNull().WithMessage("LeftFrontDoor cannot be null.")
                .IsInEnum().WithMessage("LeftFrontDoor must be a valid ExpertizeCondition.");

            RuleFor(c => c.LeftRearDoor)
                .NotNull().WithMessage("LeftRearDoor cannot be null.")
                .IsInEnum().WithMessage("LeftRearDoor must be a valid ExpertizeCondition.");

            RuleFor(c => c.LeftRearFender)
                .NotNull().WithMessage("LeftRearFender cannot be null.")
                .IsInEnum().WithMessage("LeftRearFender must be a valid ExpertizeCondition.");

            RuleFor(c => c.RightFrontFender)
                .NotNull().WithMessage("RightFrontFender cannot be null.")
                .IsInEnum().WithMessage("RightFrontFender must be a valid ExpertizeCondition.");

            RuleFor(c => c.RightFrontDoor)
                .NotNull().WithMessage("RightFrontDoor cannot be null.")
                .IsInEnum().WithMessage("RightFrontDoor must be a valid ExpertizeCondition.");

            RuleFor(c => c.RightRearDoor)
                .NotNull().WithMessage("RightRearDoor cannot be null.")
                .IsInEnum().WithMessage("RightRearDoor must be a valid ExpertizeCondition.");

            RuleFor(c => c.RightRearFender)
                .NotNull().WithMessage("RightRearFender cannot be null.")
                .IsInEnum().WithMessage("RightRearFender must be a valid ExpertizeCondition.");

            RuleFor(c => c.Frontbumper)
                .NotNull().WithMessage("Frontbumper cannot be null.")
                .IsInEnum().WithMessage("Frontbumper must be a valid ExpertizeCondition.");

            RuleFor(c => c.RearBumper)
                .NotNull().WithMessage("RearBumper cannot be null.")
                .IsInEnum().WithMessage("RearBumper must be a valid ExpertizeCondition.");

            RuleFor(c => c.Bonnet)
                .NotNull().WithMessage("Bonnet cannot be null.")
                .IsInEnum().WithMessage("Bonnet must be a valid ExpertizeCondition.");

            RuleFor(c => c.Ceiling)
                .NotNull().WithMessage("Ceiling cannot be null.")
                .IsInEnum().WithMessage("Ceiling must be a valid ExpertizeCondition.");

            RuleFor(c => c.Luggage)
                .NotNull().WithMessage("Luggage cannot be null.")
                .IsInEnum().WithMessage("Luggage must be a valid ExpertizeCondition.");
        }
    }
}
