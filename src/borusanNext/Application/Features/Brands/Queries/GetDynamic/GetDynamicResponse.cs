using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetDynamic;
public class GetDynamicResponse:IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
}
