using Application.Features.BodyTypes.Constants;
using Application.Features.BodyTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BodyTypes.Constants.BodyTypesOperationClaims;

namespace Application.Features.BodyTypes.Queries.GetById;

public class GetByIdBodyTypeQuery : IRequest<GetByIdBodyTypeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBodyTypeQueryHandler : IRequestHandler<GetByIdBodyTypeQuery, GetByIdBodyTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBodyTypeRepository _bodyTypeRepository;
        private readonly BodyTypeBusinessRules _bodyTypeBusinessRules;

        public GetByIdBodyTypeQueryHandler(IMapper mapper, IBodyTypeRepository bodyTypeRepository, BodyTypeBusinessRules bodyTypeBusinessRules)
        {
            _mapper = mapper;
            _bodyTypeRepository = bodyTypeRepository;
            _bodyTypeBusinessRules = bodyTypeBusinessRules;
        }

        public async Task<GetByIdBodyTypeResponse> Handle(GetByIdBodyTypeQuery request, CancellationToken cancellationToken)
        {
            BodyType? bodyType = await _bodyTypeRepository.GetAsync(predicate: bt => bt.Id == request.Id, cancellationToken: cancellationToken);
            await _bodyTypeBusinessRules.BodyTypeShouldExistWhenSelected(bodyType);

            GetByIdBodyTypeResponse response = _mapper.Map<GetByIdBodyTypeResponse>(bodyType);
            return response;
        }
    }
}