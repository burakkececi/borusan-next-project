using NArchitecture.Core.Application.Responses;

namespace Application.Features.BodyTypes.Commands.Update;

public class UpdatedBodyTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BodyName { get; set; }
    public string Door { get; set; }
}