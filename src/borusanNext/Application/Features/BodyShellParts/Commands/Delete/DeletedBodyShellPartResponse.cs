using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.BodyShellParts.Commands.Delete;

public class DeletedBodyShellPartResponse : IResponse
{
    public Guid Id { get; set; }
}