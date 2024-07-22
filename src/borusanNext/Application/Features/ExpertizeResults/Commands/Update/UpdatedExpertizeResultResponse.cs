using NArchitecture.Core.Application.Responses;

namespace Application.Features.ExpertizeResults.Commands.Update;

public class UpdatedExpertizeResultResponse : IResponse
{
    public Guid Id { get; set; }
    public int CarDamageInformationRecord { get; set; }
    public DateTime InquiryDate { get; set; }
}