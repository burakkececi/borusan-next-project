using NArchitecture.Core.Application.Dtos;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;

namespace Application.Features.BodyShellParts.Queries.GetList;

public class GetListBodyShellPartListItemDto : IDto
{
    public Guid Id { get; set; }
    public ExpertizeCondition LeftFrontFender { get; set; }
    public ExpertizeCondition LeftFrontDoor { get; set; }
    public ExpertizeCondition LeftRearDoor { get; set; }
    public ExpertizeCondition LeftRearFender { get; set; }
    public ExpertizeCondition RightFrontFender { get; set; }
    public ExpertizeCondition RightFrontDoor { get; set; }
    public ExpertizeCondition RightRearDoor { get; set; }
    public ExpertizeCondition RightRearFender { get; set; }
    public ExpertizeCondition Frontbumper { get; set; }
    public ExpertizeCondition RearBumper { get; set; }
    public ExpertizeCondition Bonnet { get; set; }
    public ExpertizeCondition Ceiling { get; set; }
    public ExpertizeCondition Luggage { get; set; }
}