using Application.Features.ExpertizeResults.Constants;
using Application.Features.ExpertizeResults.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ExpertizeResults.Constants.ExpertizeResultsOperationClaims;

namespace Application.Features.ExpertizeResults.Queries.GetById;

public class GetByIdExpertizeResultQuery : IRequest<GetByIdExpertizeResultResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdExpertizeResultQueryHandler : IRequestHandler<GetByIdExpertizeResultQuery, GetByIdExpertizeResultResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExpertizeResultRepository _expertizeResultRepository;
        private readonly ExpertizeResultBusinessRules _expertizeResultBusinessRules;

        public GetByIdExpertizeResultQueryHandler(IMapper mapper, IExpertizeResultRepository expertizeResultRepository, ExpertizeResultBusinessRules expertizeResultBusinessRules)
        {
            _mapper = mapper;
            _expertizeResultRepository = expertizeResultRepository;
            _expertizeResultBusinessRules = expertizeResultBusinessRules;
        }

        public async Task<GetByIdExpertizeResultResponse> Handle(GetByIdExpertizeResultQuery request, CancellationToken cancellationToken)
        {
            ExpertizeResult? expertizeResult = await _expertizeResultRepository.GetAsync(predicate: er => er.Id == request.Id, cancellationToken: cancellationToken);
            await _expertizeResultBusinessRules.ExpertizeResultShouldExistWhenSelected(expertizeResult);

            GetByIdExpertizeResultResponse response = _mapper.Map<GetByIdExpertizeResultResponse>(expertizeResult);
            return response;
        }
    }
}