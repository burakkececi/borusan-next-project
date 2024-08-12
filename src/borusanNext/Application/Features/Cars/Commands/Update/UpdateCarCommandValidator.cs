using FluentValidation;
using System;

namespace Application.Features.Cars.Commands.Update
{
    public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
    {
        public UpdateCarCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id cannot be empty.")
                .Must(BeValidGuid).WithMessage("Id must be a valid GUID format.");

            RuleFor(c => c.ChassisNumber)
                .NotEmpty().WithMessage("Chassis Number cannot be empty.");

            RuleFor(c => c.Plate)
                .NotEmpty().WithMessage("Plate cannot be empty.");

            RuleFor(c => c.Kilometers)
                .NotEmpty().WithMessage("Kilometers cannot be empty.")
                .GreaterThan(0).WithMessage("Kilometers must be greater than zero.");

            RuleFor(c => c.SpareKey)
                .NotEmpty().WithMessage("Spare Key cannot be empty.");

            RuleFor(c => c.Inquiry)
                .NotEmpty().WithMessage("Inquiry cannot be empty.");

            RuleFor(c => c.WheelType)
                .NotEmpty().WithMessage("Wheel Type cannot be empty.");

            RuleFor(c => c.SpareWheel)
                .NotEmpty().WithMessage("Spare Wheel cannot be empty.");

            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("Price cannot be empty.")
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(c => c.CarModelId)
                .NotEmpty().WithMessage("Car Model Id cannot be empty.")
                .Must(id => id != Guid.Empty).WithMessage("Car Model Id must be a valid GUID.");

            RuleFor(c => c.ColorId)
                .NotEmpty().WithMessage("Color Id cannot be empty.")
                .Must(id => id != Guid.Empty).WithMessage("Color Id must be a valid GUID.");

            RuleFor(c => c.EngineId)
                .NotEmpty().WithMessage("Engine Id cannot be empty.")
                .Must(id => id != Guid.Empty).WithMessage("Engine Id must be a valid GUID.");

            RuleFor(c => c.BodyTypeId)
                .NotEmpty().WithMessage("Body Type Id cannot be empty.")
                .Must(id => id != Guid.Empty).WithMessage("Body Type Id must be a valid GUID.");

            RuleFor(c => c.TransmissionId)
                .NotEmpty().WithMessage("Transmission Id cannot be empty.")
                .Must(id => id != Guid.Empty).WithMessage("Transmission Id must be a valid GUID.");

            RuleFor(c => c.TramerId)
                .NotEmpty().WithMessage("Tramer Id cannot be empty.")
                .Must(id => id != Guid.Empty).WithMessage("Tramer Id must be a valid GUID.");

            RuleFor(c => c.SellerId)
                .NotEmpty().WithMessage("Seller Id cannot be empty.")
                .Must(id => id != Guid.Empty).WithMessage("Seller Id must be a valid GUID.");
        }

        private bool BeValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
