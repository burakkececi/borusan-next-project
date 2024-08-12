using FluentValidation;
using System;

namespace Application.Features.Appointments.Commands.Create
{
    public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator()
        {
            RuleFor(c => c.DateAndTime)
                .NotNull().WithMessage("Date and Time cannot be null.")
                .NotEmpty().WithMessage("Date and Time cannot be empty.")
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Date and Time must be in the future.");

            RuleFor(c => c.CarId)
                .NotNull().WithMessage("Car ID cannot be null.")
                .NotEmpty().WithMessage("Car ID cannot be empty.")
                .Must(BeAValidGuid).WithMessage("Car ID must be a valid GUID.");

            RuleFor(c => c.CustomerId)
                .NotNull().WithMessage("Customer ID cannot be null.")
                .NotEmpty().WithMessage("Customer ID cannot be empty.")
                .Must(BeAValidGuid).WithMessage("Customer ID must be a valid GUID.");
        }

        private bool BeAValidGuid(Guid guid)
        {
            return guid != Guid.Empty;
        }
    }
}
