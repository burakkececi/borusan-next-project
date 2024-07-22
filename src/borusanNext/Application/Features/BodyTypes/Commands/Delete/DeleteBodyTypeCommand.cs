using Application.Features.BodyTypes.Constants;
using Application.Features.BodyTypes.Constants;
using Application.Features.BodyTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BodyTypes.Constants.BodyTypesOperationClaims;

namespace Application.Features.BodyTypes.Commands.Delete;

public class DeleteBodyTypeCommand : IRequest<DeletedBodyTypeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, BodyTypesOperationClaims.Delete];

    public class DeleteBodyTypeCommandHandler : IRequestHandler<DeleteBodyTypeCommand, DeletedBodyTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBodyTypeRepository _bodyTypeRepository;
        private readonly BodyTypeBusinessRules _bodyTypeBusinessRules;

        public DeleteBodyTypeCommandHandler(IMapper mapper, IBodyTypeRepository bodyTypeRepository,
                                         BodyTypeBusinessRules bodyTypeBusinessRules)
        {
            _mapper = mapper;
            _bodyTypeRepository = bodyTypeRepository;
            _bodyTypeBusinessRules = bodyTypeBusinessRules;
        }

        public async Task<DeletedBodyTypeResponse> Handle(DeleteBodyTypeCommand request, CancellationToken cancellationToken)
        {
            BodyType? bodyType = await _bodyTypeRepository.GetAsync(predicate: bt => bt.Id == request.Id, cancellationToken: cancellationToken);
            await _bodyTypeBusinessRules.BodyTypeShouldExistWhenSelected(bodyType);

            await _bodyTypeRepository.DeleteAsync(bodyType!);

            DeletedBodyTypeResponse response = _mapper.Map<DeletedBodyTypeResponse>(bodyType);
            return response;
        }
    }
}