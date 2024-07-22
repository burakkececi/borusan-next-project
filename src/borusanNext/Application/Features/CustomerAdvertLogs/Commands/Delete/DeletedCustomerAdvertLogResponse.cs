using NArchitecture.Core.Application.Responses;

namespace Application.Features.CustomerAdvertLogs.Commands.Delete;

public class DeletedCustomerAdvertLogResponse : IResponse
{
    public Guid Id { get; set; }
}