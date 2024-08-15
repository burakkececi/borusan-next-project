using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarModels.Queries.GetDynamic;
public class GetDynamicCarModelsResponse:IResponse
{
    public Guid Id { get; set; }
    public string ModelName { get; set; }
    public Brand Brand { get; set; }
}
