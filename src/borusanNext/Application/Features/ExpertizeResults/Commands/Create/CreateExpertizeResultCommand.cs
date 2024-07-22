using Application.Features.ExpertizeResults.Constants;
using Application.Features.ExpertizeResults.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ExpertizeResults.Constants.ExpertizeResultsOperationClaims;

namespace Application.Features.ExpertizeResults.Commands.Create;

public class CreateExpertizeResultCommand : IRequest<CreatedExpertizeResultResponse>, ISecuredRequest
{
    public required int CarDamageInformationRecord { get; set; }
    public required DateTime InquiryDate { get; set; }

    public string[] Roles => [Admin, Write, ExpertizeResultsOperationClaims.Create];

    public class CreateExpertizeResultCommandHandler : IRequestHandler<CreateExpertizeResultCommand, CreatedExpertizeResultResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExpertizeResultRepository _expertizeResultRepository;
        private readonly ExpertizeResultBusinessRules _expertizeResultBusinessRules;

        public CreateExpertizeResultCommandHandler(IMapper mapper, IExpertizeResultRepository expertizeResultRepository,
                                         ExpertizeResultBusinessRules expertizeResultBusinessRules)
        {
            _mapper = mapper;
            _expertizeResultRepository = expertizeResultRepository;
            _expertizeResultBusinessRules = expertizeResultBusinessRules;
        }

        public async Task<CreatedExpertizeResultResponse> Handle(CreateExpertizeResultCommand request, CancellationToken cancellationToken)
        {
            ExpertizeResult expertizeResult = _mapper.Map<ExpertizeResult>(request);

            await _expertizeResultRepository.AddAsync(expertizeResult);

            CreatedExpertizeResultResponse response = _mapper.Map<CreatedExpertizeResultResponse>(expertizeResult);
            return response;
        }
    }
}