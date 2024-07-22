using NArchitecture.Core.Application.Responses;

namespace Application.Features.ChassisParts.Commands.Update;

public class UpdatedChassisPartResponse : IResponse
{
    public Guid Id { get; set; }
    public bool IsRightChassisChanged { get; set; }
    public bool IsLeftChassisChanged { get; set; }
    public bool IsFrontPanelChanged { get; set; }
    public bool IsBackPanelChanged { get; set; }
}