using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetDynamic;
public class GetDynamicCarResponse : IResponse
{
    public Guid Id { get; set; }
    public string ChassisNumber { get; set; }
    public string Plate { get; set; }
    public int Kilometers { get; set; }
    public bool SpareKey { get; set; }
    public DateTime Inquiry { get; set; }
    public string WheelType { get; set; }
    public bool SpareWheel { get; set; }
    public decimal Price { get; set; }
    public string CarModelName { get; set; }
    public Guid CarModelId { get; set; }
    public string ColorName { get; set; }
    public Guid ColorId { get; set; }
    public Guid EngineId { get; set; }
    public string EngineNo { get; set; }
    public Guid BodyTypeId { get; set; }
    public Guid TransmissionId { get; set; }
    public Guid TramerId { get; set; }
    public Guid SellerId { get; set; }
    public string SellerName { get; set; }
}
