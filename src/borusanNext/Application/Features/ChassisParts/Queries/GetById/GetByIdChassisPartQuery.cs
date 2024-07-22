using Application.Features.ChassisParts.Constants;
using Application.Features.ChassisParts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ChassisParts.Constants.ChassisPartsOperationClaims;

namespace Application.Features.ChassisParts.Queries.GetById;

public class GetByIdChassisPartQuery : IRequest<GetByIdChassisPartResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdChassisPartQueryHandler : IRequestHandler<GetByIdChassisPartQuery, GetByIdChassisPartResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChassisPartRepository _chassisPartRepository;
        private readonly ChassisPartBusinessRules _chassisPartBusinessRules;

        public GetByIdChassisPartQueryHandler(IMapper mapper, IChassisPartRepository chassisPartRepository, ChassisPartBusinessRules chassisPartBusinessRules)
        {
            _mapper = mapper;
            _chassisPartRepository = chassisPartRepository;
            _chassisPartBusinessRules = chassisPartBusinessRules;
        }

        public async Task<GetByIdChassisPartResponse> Handle(GetByIdChassisPartQuery request, CancellationToken cancellationToken)
        {
            ChassisPart? chassisPart = await _chassisPartRepository.GetAsync(predicate: cp => cp.Id == request.Id, cancellationToken: cancellationToken);
            await _chassisPartBusinessRules.ChassisPartShouldExistWhenSelected(chassisPart);

            GetByIdChassisPartResponse response = _mapper.Map<GetByIdChassisPartResponse>(chassisPart);
            return response;
        }
    }
}