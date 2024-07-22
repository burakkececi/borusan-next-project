using NArchitecture.Core.Application.Responses;

namespace Application.Features.ExpertizeResults.Queries.GetById;

public class GetByIdExpertizeResultResponse : IResponse
{
    public Guid Id { get; set; }
    public int CarDamageInformationRecord { get; set; }
    public DateTime InquiryDate { get; set; }
    public Guid ChassisPartId { get; set; }
    public Guid BodyPartId { get; set; }
}