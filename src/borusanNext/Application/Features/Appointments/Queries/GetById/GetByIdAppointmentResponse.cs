using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Appointments.Queries.GetById;

public class GetByIdAppointmentResponse : IResponse
{
    public Guid Id { get; set; }
    public DateTime DateAndTime { get; set; }
    public Car Car { get; set; }
    public Customer Customer { get; set; }
}