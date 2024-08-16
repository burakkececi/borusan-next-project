using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Queries.GetDynamic;
public class GetDynamicAppoimentResponse:IResponse
{
    public Guid Id { get; set; }
    public DateTime DateAndTime { get; set; }
    public Car Car { get; set; }
    public Customer Customer { get; set; }
}
