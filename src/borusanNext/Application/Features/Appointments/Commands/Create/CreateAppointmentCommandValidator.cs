using FluentValidation;

namespace Application.Features.Appointments.Commands.Create;

public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
{
    public CreateAppointmentCommandValidator()
    {
        RuleFor(c => c.DateAndTime).NotEmpty();
        RuleFor(c => c.CarId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
    }
}