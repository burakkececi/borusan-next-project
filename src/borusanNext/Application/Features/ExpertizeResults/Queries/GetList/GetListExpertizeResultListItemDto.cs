using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ExpertizeResults.Queries.GetList;

public class GetListExpertizeResultListItemDto : IDto
{
    public Guid Id { get; set; }
    public int CarDamageInformationRecord { get; set; }
    public DateTime InquiryDate { get; set; }
    public ChassisPart ChassisPart { get; set; }
    public BodyShellPart BodyShellPart { get; set; }
}