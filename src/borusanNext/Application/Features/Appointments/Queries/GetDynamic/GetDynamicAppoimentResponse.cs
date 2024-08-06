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
    public Guid CarId { get; set; }
    public Guid CustomerId { get; set; }
}
