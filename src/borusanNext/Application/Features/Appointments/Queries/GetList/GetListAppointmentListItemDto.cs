using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Appointments.Queries.GetList;

public class GetListAppointmentListItemDto : IDto
{
    public Guid Id { get; set; }
    public DateTime DateAndTime { get; set; }
    public Car Car { get; set; }
    public Customer Customer { get; set; }
}