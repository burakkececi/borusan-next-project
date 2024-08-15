using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.ExpertizeResults.Queries.GetById;

public class GetByIdExpertizeResultResponse : IResponse
{
    public Guid Id { get; set; }
    public int CarDamageInformationRecord { get; set; }
    public DateTime InquiryDate { get; set; }
    public ChassisPart ChassisPart { get; set; }
    public BodyShellPart BodyShellPart { get; set; }
}