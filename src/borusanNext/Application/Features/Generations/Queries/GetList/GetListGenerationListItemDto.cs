using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Generations.Queries.GetList;

public class GetListGenerationListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}