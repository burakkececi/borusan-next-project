using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.CarModels.Queries.GetList;

public class GetListCarModelListItemDto : IDto
{
    public Guid Id { get; set; }
    public string ModelName { get; set; }
    public Brand Brand { get; set; }
}