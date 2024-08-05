using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FuelConsumptions.Queries.GetDynamic;
public class GetDynamicFuelConsumptionResponse:IResponse
{
    public Guid Id { get; set; }
    public double OutOfTown { get; set; }
    public double Urban { get; set; }
    public double Average { get; set; }
}
