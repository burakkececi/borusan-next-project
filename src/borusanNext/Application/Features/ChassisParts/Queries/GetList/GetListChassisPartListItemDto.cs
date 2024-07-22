using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ChassisParts.Queries.GetList;

public class GetListChassisPartListItemDto : IDto
{
    public Guid Id { get; set; }
    public bool IsRightChassisChanged { get; set; }
    public bool IsLeftChassisChanged { get; set; }
    public bool IsFrontPanelChanged { get; set; }
    public bool IsBackPanelChanged { get; set; }
}