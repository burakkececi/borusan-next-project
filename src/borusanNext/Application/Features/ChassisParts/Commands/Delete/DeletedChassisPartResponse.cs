using NArchitecture.Core.Application.Responses;

namespace Application.Features.ChassisParts.Commands.Delete;

public class DeletedChassisPartResponse : IResponse
{
    public Guid Id { get; set; }
}