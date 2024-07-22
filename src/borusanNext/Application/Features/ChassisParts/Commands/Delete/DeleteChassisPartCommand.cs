using Application.Features.ChassisParts.Constants;
using Application.Features.ChassisParts.Constants;
using Application.Features.ChassisParts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ChassisParts.Constants.ChassisPartsOperationClaims;

namespace Application.Features.ChassisParts.Commands.Delete;

public class DeleteChassisPartCommand : IRequest<DeletedChassisPartResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ChassisPartsOperationClaims.Delete];

    public class DeleteChassisPartCommandHandler : IRequestHandler<DeleteChassisPartCommand, DeletedChassisPartResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChassisPartRepository _chassisPartRepository;
        private readonly ChassisPartBusinessRules _chassisPartBusinessRules;

        public DeleteChassisPartCommandHandler(IMapper mapper, IChassisPartRepository chassisPartRepository,
                                         ChassisPartBusinessRules chassisPartBusinessRules)
        {
            _mapper = mapper;
            _chassisPartRepository = chassisPartRepository;
            _chassisPartBusinessRules = chassisPartBusinessRules;
        }

        public async Task<DeletedChassisPartResponse> Handle(DeleteChassisPartCommand request, CancellationToken cancellationToken)
        {
            ChassisPart? chassisPart = await _chassisPartRepository.GetAsync(predicate: cp => cp.Id == request.Id, cancellationToken: cancellationToken);
            await _chassisPartBusinessRules.ChassisPartShouldExistWhenSelected(chassisPart);

            await _chassisPartRepository.DeleteAsync(chassisPart!);

            DeletedChassisPartResponse response = _mapper.Map<DeletedChassisPartResponse>(chassisPart);
            return response;
        }
    }
}