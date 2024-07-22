using Application.Features.ExpertizeResults.Constants;
using Application.Features.ExpertizeResults.Constants;
using Application.Features.ExpertizeResults.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ExpertizeResults.Constants.ExpertizeResultsOperationClaims;

namespace Application.Features.ExpertizeResults.Commands.Delete;

public class DeleteExpertizeResultCommand : IRequest<DeletedExpertizeResultResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ExpertizeResultsOperationClaims.Delete];

    public class DeleteExpertizeResultCommandHandler : IRequestHandler<DeleteExpertizeResultCommand, DeletedExpertizeResultResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExpertizeResultRepository _expertizeResultRepository;
        private readonly ExpertizeResultBusinessRules _expertizeResultBusinessRules;

        public DeleteExpertizeResultCommandHandler(IMapper mapper, IExpertizeResultRepository expertizeResultRepository,
                                         ExpertizeResultBusinessRules expertizeResultBusinessRules)
        {
            _mapper = mapper;
            _expertizeResultRepository = expertizeResultRepository;
            _expertizeResultBusinessRules = expertizeResultBusinessRules;
        }

        public async Task<DeletedExpertizeResultResponse> Handle(DeleteExpertizeResultCommand request, CancellationToken cancellationToken)
        {
            ExpertizeResult? expertizeResult = await _expertizeResultRepository.GetAsync(predicate: er => er.Id == request.Id, cancellationToken: cancellationToken);
            await _expertizeResultBusinessRules.ExpertizeResultShouldExistWhenSelected(expertizeResult);

            await _expertizeResultRepository.DeleteAsync(expertizeResult!);

            DeletedExpertizeResultResponse response = _mapper.Map<DeletedExpertizeResultResponse>(expertizeResult);
            return response;
        }
    }
}