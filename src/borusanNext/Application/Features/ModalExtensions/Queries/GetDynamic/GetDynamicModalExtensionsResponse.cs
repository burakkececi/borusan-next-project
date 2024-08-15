using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ModalExtensions.Queries.GetDynamic;
public class GetDynamicModalExtensionsResponse:IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Lenght { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double FuelTank { get; set; }
    public double LuggageCapacity { get; set; }
    public double EmptyWeight { get; set; }
    public int ModelYear { get; set; }

    public Guid CarModelId { get; set; }
    public string CarModelName { get; set; }
    public Guid BrandId { get; set; }
    public string BrandName { get; set; }
    public string BrandLogo { get; set; }
    public Guid GenerationId { get; set; }
    public string GenerationName { get; set; }
}
