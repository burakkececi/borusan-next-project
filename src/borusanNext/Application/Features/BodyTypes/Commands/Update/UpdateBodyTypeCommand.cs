using Application.Features.BodyTypes.Constants;
using Application.Features.BodyTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BodyTypes.Constants.BodyTypesOperationClaims;

namespace Application.Features.BodyTypes.Commands.Update;

public class UpdateBodyTypeCommand : IRequest<UpdatedBodyTypeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required Guid BodyName { get; set; }
    public required string Door { get; set; }

    public string[] Roles => [Admin, Write, BodyTypesOperationClaims.Update];

    public class UpdateBodyTypeCommandHandler : IRequestHandler<UpdateBodyTypeCommand, UpdatedBodyTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBodyTypeRepository _bodyTypeRepository;
        private readonly BodyTypeBusinessRules _bodyTypeBusinessRules;

        public UpdateBodyTypeCommandHandler(IMapper mapper, IBodyTypeRepository bodyTypeRepository,
                                         BodyTypeBusinessRules bodyTypeBusinessRules)
        {
            _mapper = mapper;
            _bodyTypeRepository = bodyTypeRepository;
            _bodyTypeBusinessRules = bodyTypeBusinessRules;
        }

        public async Task<UpdatedBodyTypeResponse> Handle(UpdateBodyTypeCommand request, CancellationToken cancellationToken)
        {
            BodyType? bodyType = await _bodyTypeRepository.GetAsync(predicate: bt => bt.Id == request.Id, cancellationToken: cancellationToken);
            await _bodyTypeBusinessRules.BodyTypeShouldExistWhenSelected(bodyType);
            bodyType = _mapper.Map(request, bodyType);

            await _bodyTypeRepository.UpdateAsync(bodyType!);

            UpdatedBodyTypeResponse response = _mapper.Map<UpdatedBodyTypeResponse>(bodyType);
            return response;
        }
    }
}