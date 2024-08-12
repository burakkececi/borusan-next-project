using Domain.Enums;
using FluentValidation;

namespace Application.Features.BodyShellParts.Commands.Create
{
    public class CreateBodyShellPartCommandValidator : AbstractValidator<CreateBodyShellPartCommand>
    {
        public CreateBodyShellPartCommandValidator()
        {
            RuleFor(c => c.LeftFrontFender)
                .NotNull().WithMessage("LeftFrontFender cannot be null.")
                .Must(value => Enum.IsDefined(typeof(ExpertizeCondition), value))
                .WithMessage("LeftFrontFender must be a valid ExpertizeCondition value.");

            RuleFor(c => c.LeftFrontDoor)
                .NotNull().WithMessage("LeftFrontDoor cannot be null.")
                .Must(value => Enum.IsDefined(typeof(ExpertizeCondition), value))
                .WithMessage("LeftFrontDoor must be a valid ExpertizeCondition value.");

            RuleFor(c => c.LeftRearDoor)
                .NotNull().WithMessage("LeftRearDoor cannot be null.")
                .Must(value => Enum.IsDefined(typeof(ExpertizeCondition), value))
                .WithMessage("LeftRearDoor must be a valid ExpertizeCondition value.");

            RuleFor(c => c.LeftRearFender)
                .NotNull().WithMessage("LeftRearFender cannot be null.")
                .Must(value => Enum.IsDefined(typeof(ExpertizeCondition), value))
                .WithMessage("LeftRearFender must be a valid ExpertizeCondition value.");

            RuleFor(c => c.RightFrontFender)
                .NotNull().WithMessage("RightFrontFender cannot be null.")
                .Must(value => Enum.IsDefined(typeof(ExpertizeCondition), value))
                .WithMessage("RightFrontFender must be a valid ExpertizeCondition value.");

            RuleFor(c => c.RightFrontDoor)
                .NotNull().WithMessage("RightFrontDoor cannot be null.")
                .Must(value => Enum.IsDefined(typeof(ExpertizeCondition), value))
                .WithMessage("RightFrontDoor must be a valid ExpertizeCondition value.");

            RuleFor(c => c.RightRearDoor)
                .NotNull().WithMessage("RightRearDoor cannot be null.")
                .Must(value => Enum.IsDefined(typeof(ExpertizeCondition), value))
                .WithMessage("RightRearDoor must be a valid ExpertizeCondition value.");

            RuleFor(c => c.RightRearFender)
                .NotNull().WithMessage("RightRearFender cannot be null.")
                .Must(value => Enum.IsDefined(typeof(ExpertizeCondition), value))
                .WithMessage("RightRearFender must be a valid ExpertizeCondition value.");

            RuleFor(c => c.Frontbumper)
                .NotNull().WithMessage("Frontbumper cannot be null.")
                .Must(value => Enum.IsDefined(typeof(ExpertizeCondition), value))
                .WithMessage("Frontbumper must be a valid ExpertizeCondition value.");

            RuleFor(c => c.RearBumper)
                .NotNull().WithMessage("RearBumper cannot be null.")
                .Must(value => Enum.IsDefined(typeof(ExpertizeCondition), value))
                .WithMessage("RearBumper must be a valid ExpertizeCondition value.");

            RuleFor(c => c.Bonnet)
                .NotNull().WithMessage("Bonnet cannot be null.")
                .Must(value => Enum.IsDefined(typeof(ExpertizeCondition), value))
                .WithMessage("Bonnet must be a valid ExpertizeCondition value.");

            RuleFor(c => c.Ceiling)
                .NotNull().WithMessage("Ceiling cannot be null.")
                .Must(value => Enum.IsDefined(typeof(ExpertizeCondition), value))
                .WithMessage("Ceiling must be a valid ExpertizeCondition value.");

            RuleFor(c => c.Luggage)
                .NotNull().WithMessage("Luggage cannot be null.")
                .Must(value => Enum.IsDefined(typeof(ExpertizeCondition), value))
                .WithMessage("Luggage must be a valid ExpertizeCondition value.");
        }
    }
}
