using Application.Features.ExpertizeResults.Constants;
using Application.Features.ExpertizeResults.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ExpertizeResults.Constants.ExpertizeResultsOperationClaims;

namespace Application.Features.ExpertizeResults.Commands.Update;

public class UpdateExpertizeResultCommand : IRequest<UpdatedExpertizeResultResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required int CarDamageInformationRecord { get; set; }
    public required DateTime InquiryDate { get; set; }
    public required Guid ChassisPartId { get; set; }
    public required Guid BodyPartId { get; set; }

    public string[] Roles => [Admin, Write, ExpertizeResultsOperationClaims.Update];

    public class UpdateExpertizeResultCommandHandler : IRequestHandler<UpdateExpertizeResultCommand, UpdatedExpertizeResultResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExpertizeResultRepository _expertizeResultRepository;
        private readonly ExpertizeResultBusinessRules _expertizeResultBusinessRules;

        public UpdateExpertizeResultCommandHandler(IMapper mapper, IExpertizeResultRepository expertizeResultRepository,
                                         ExpertizeResultBusinessRules expertizeResultBusinessRules)
        {
            _mapper = mapper;
            _expertizeResultRepository = expertizeResultRepository;
            _expertizeResultBusinessRules = expertizeResultBusinessRules;
        }

        public async Task<UpdatedExpertizeResultResponse> Handle(UpdateExpertizeResultCommand request, CancellationToken cancellationToken)
        {
            ExpertizeResult? expertizeResult = await _expertizeResultRepository.GetAsync(predicate: er => er.Id == request.Id, cancellationToken: cancellationToken);
            await _expertizeResultBusinessRules.ExpertizeResultShouldExistWhenSelected(expertizeResult);
            expertizeResult = _mapper.Map(request, expertizeResult);

            await _expertizeResultRepository.UpdateAsync(expertizeResult!);

            UpdatedExpertizeResultResponse response = _mapper.Map<UpdatedExpertizeResultResponse>(expertizeResult);
            return response;
        }
    }
}