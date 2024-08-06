using NArchitecture.Core.Application.Responses;

namespace Application.Features.BodyTypes.Commands.Delete;

public class DeletedBodyTypeResponse : IResponse
{
    public Guid Id { get; set; }
}