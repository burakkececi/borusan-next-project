using NArchitecture.Core.Application.Responses;

namespace Application.Features.Cars.Commands.Delete;

public class DeletedCustomerResponse : IResponse
{
    public Guid Id { get; set; }
}