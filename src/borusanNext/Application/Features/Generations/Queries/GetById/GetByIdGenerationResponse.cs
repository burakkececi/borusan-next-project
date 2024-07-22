using NArchitecture.Core.Application.Responses;

namespace Application.Features.Generations.Queries.GetById;

public class GetByIdGenerationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}