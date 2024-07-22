using NArchitecture.Core.Application.Responses;

namespace Application.Features.ExpertizeResults.Commands.Create;

public class CreatedExpertizeResultResponse : IResponse
{
    public Guid Id { get; set; }
    public int CarDamageInformationRecord { get; set; }
    public DateTime InquiryDate { get; set; }
}