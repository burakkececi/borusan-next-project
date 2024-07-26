using NArchitecture.Core.Application.Responses;

namespace Application.Features.ExpertizeResults.Commands.Delete;

public class DeletedExpertizeResultResponse : IResponse
{
    public Guid Id { get; set; }
}