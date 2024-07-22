using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class ChassisPart : Entity<Guid>
{
    public bool IsRightChassisChanged { get; set; }
    public bool IsLeftChassisChanged { get; set; }
    public bool IsFrontPanelChanged { get; set; }
    public bool IsBackPanelChanged { get; set; }

    public virtual ExpertizeResult ExpertizeResult { get; set; }

}