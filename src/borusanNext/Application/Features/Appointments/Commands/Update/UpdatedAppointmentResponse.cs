using NArchitecture.Core.Application.Responses;

namespace Application.Features.Appointments.Commands.Update;

public class UpdatedAppointmentResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime DateAndTime { get; set; }
    public Guid CarId { get; set; }
    public Guid CustomerId { get; set; }
}