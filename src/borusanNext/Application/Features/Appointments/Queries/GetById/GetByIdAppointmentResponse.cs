using NArchitecture.Core.Application.Responses;

namespace Application.Features.Appointments.Queries.GetById;

public class GetByIdAppointmentResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public DateTime Time { get; set; }
    public Guid CarId { get; set; }
    public Guid CustomerId { get; set; }
}