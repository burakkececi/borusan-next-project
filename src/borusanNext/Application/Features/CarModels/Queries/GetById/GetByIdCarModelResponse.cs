using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.CarModels.Queries.GetById;

public class GetByIdCarModelResponse : IResponse
{
    public Guid Id { get; set; }
    public string ModelName { get; set; }
    public Brand Brand { get; set; }
}