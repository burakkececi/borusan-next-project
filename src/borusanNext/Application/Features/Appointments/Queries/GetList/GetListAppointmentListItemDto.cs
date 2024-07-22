using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Appointments.Queries.GetList;

public class GetListAppointmentListItemDto : IDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public DateTime Time { get; set; }
    public Guid CarId { get; set; }
    public Guid CustomerId { get; set; }
}