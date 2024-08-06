using NArchitecture.Core.Application.Responses;

namespace Application.Features.BodyTypes.Commands.Update;

public class UpdatedBodyTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string BodyName { get; set; }
    public string Door { get; set; }
}