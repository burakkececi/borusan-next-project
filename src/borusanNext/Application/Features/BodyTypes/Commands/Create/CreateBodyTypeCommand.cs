using Application.Features.BodyTypes.Constants;
using Application.Features.BodyTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BodyTypes.Constants.BodyTypesOperationClaims;

namespace Application.Features.BodyTypes.Commands.Create;

public class CreateBodyTypeCommand : IRequest<CreatedBodyTypeResponse>, ISecuredRequest
{
    public required string BodyName { get; set; }
    public required string Door { get; set; }

    public string[] Roles => [Admin, Write, BodyTypesOperationClaims.Create];

    public class CreateBodyTypeCommandHandler : IRequestHandler<CreateBodyTypeCommand, CreatedBodyTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBodyTypeRepository _bodyTypeRepository;
        private readonly BodyTypeBusinessRules _bodyTypeBusinessRules;

        public CreateBodyTypeCommandHandler(IMapper mapper, IBodyTypeRepository bodyTypeRepository,
                                         BodyTypeBusinessRules bodyTypeBusinessRules)
        {
            _mapper = mapper;
            _bodyTypeRepository = bodyTypeRepository;
            _bodyTypeBusinessRules = bodyTypeBusinessRules;
        }

        public async Task<CreatedBodyTypeResponse> Handle(CreateBodyTypeCommand request, CancellationToken cancellationToken)
        {
            BodyType bodyType = _mapper.Map<BodyType>(request);

            await _bodyTypeRepository.AddAsync(bodyType);

            CreatedBodyTypeResponse response = _mapper.Map<CreatedBodyTypeResponse>(bodyType);
            return response;
        }
    }
}