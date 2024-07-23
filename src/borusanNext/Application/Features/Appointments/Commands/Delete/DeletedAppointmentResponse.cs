using NArchitecture.Core.Application.Responses;

namespace Application.Features.Appointments.Commands.Delete;

public class DeletedAppointmentResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public DateTime Time { get; set; }
    public Guid CarId { get; set; }
    public Guid CustomerId { get; set; }
}