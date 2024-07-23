using NArchitecture.Core.Application.Responses;

namespace Application.Features.ExpertizeResults.Commands.Delete;

public class DeletedExpertizeResultResponse : IResponse
{
    public Guid Id { get; set; }
    public int CarDamageInformationRecord { get; set; }
    public DateTime InquiryDate { get; set; }
    public Guid ChassisPartId { get; set; }
    public Guid BodyPartId { get; set; }
}