using FluentValidation;
using System;

namespace Application.Features.Cars.Commands.Create
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(c => c.ChassisNumber)
                .NotEmpty().WithMessage("Chassis Number cannot be empty.")
                .NotNull().WithMessage("Chassis Number cannot be null.");

            RuleFor(c => c.Plate)
                .NotEmpty().WithMessage("Plate cannot be empty.")
                .NotNull().WithMessage("Plate cannot be null.");

            RuleFor(c => c.Kilometers)
                .NotEmpty().WithMessage("Kilometers cannot be empty.")
                .GreaterThan(0).WithMessage("Kilometers must be greater than zero.")
                .NotNull().WithMessage("Kilometers cannot be null.");

            RuleFor(c => c.SpareKey)
                .NotNull().WithMessage("Spare Key cannot be null.");

            RuleFor(c => c.Inquiry)
                .NotEmpty().WithMessage("Inquiry cannot be empty.")
                .NotNull().WithMessage("Inquiry cannot be null.");

            RuleFor(c => c.WheelType)
                .NotEmpty().WithMessage("Wheel Type cannot be empty.")
                .NotNull().WithMessage("Wheel Type cannot be null.");

            RuleFor(c => c.SpareWheel)
                .NotNull().WithMessage("Spare Wheel cannot be null.");

            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("Price cannot be empty.")
                .GreaterThan(0).WithMessage("Price must be greater than zero.")
                .NotNull().WithMessage("Price cannot be null.");

            RuleFor(c => c.CarModelId)
                .NotEmpty().WithMessage("Car Model Id cannot be empty.")
                .Must(id => id != Guid.Empty).WithMessage("Car Model Id must be a valid GUID.")
                .NotNull().WithMessage("Car Model Id cannot be null.");

            RuleFor(c => c.ColorId)
                .NotEmpty().WithMessage("Color Id cannot be empty.")
                .Must(id => id != Guid.Empty).WithMessage("Color Id must be a valid GUID.")
                .NotNull().WithMessage("Color Id cannot be null.");

            RuleFor(c => c.EngineId)
                .NotEmpty().WithMessage("Engine Id cannot be empty.")
                .Must(id => id != Guid.Empty).WithMessage("Engine Id must be a valid GUID.")
                .NotNull().WithMessage("Engine Id cannot be null.");

            RuleFor(c => c.BodyTypeId)
                .NotEmpty().WithMessage("Body Type Id cannot be empty.")
                .Must(id => id != Guid.Empty).WithMessage("Body Type Id must be a valid GUID.")
                .NotNull().WithMessage("Body Type Id cannot be null.");

            RuleFor(c => c.TransmissionId)
                .NotEmpty().WithMessage("Transmission Id cannot be empty.")
                .Must(id => id != Guid.Empty).WithMessage("Transmission Id must be a valid GUID.")
                .NotNull().WithMessage("Transmission Id cannot be null.");

            RuleFor(c => c.TramerId)
                .NotEmpty().WithMessage("Tramer Id cannot be empty.")
                .Must(id => id != Guid.Empty).WithMessage("Tramer Id must be a valid GUID.")
                .NotNull().WithMessage("Tramer Id cannot be null.");

            RuleFor(c => c.SellerId)
                .NotEmpty().WithMessage("Seller Id cannot be empty.")
                .Must(id => id != Guid.Empty).WithMessage("Seller Id must be a valid GUID.")
                .NotNull().WithMessage("Seller Id cannot be null.");
        }
    }
}
