using FluentValidation;

namespace Application.Features.Appointments.Commands.Update;

public class UpdateAppointmentCommandValidator : AbstractValidator<UpdateAppointmentCommand>
{
    public UpdateAppointmentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.DateAndTime).NotEmpty();
        RuleFor(c => c.CarId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
    }
}