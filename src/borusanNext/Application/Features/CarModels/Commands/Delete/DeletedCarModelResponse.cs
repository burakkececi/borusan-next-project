using NArchitecture.Core.Application.Responses;

namespace Application.Features.CarModels.Commands.Delete;

public class DeletedCarModelResponse : IResponse
{
    public Guid Id { get; set; }
}