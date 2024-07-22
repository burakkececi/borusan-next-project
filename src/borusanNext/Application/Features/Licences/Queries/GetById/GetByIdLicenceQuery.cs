using Application.Features.Licences.Constants;
using Application.Features.Licences.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Licences.Constants.LicencesOperationClaims;

namespace Application.Features.Licences.Queries.GetById;

public class GetByIdLicenceQuery : IRequest<GetByIdLicenceResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdLicenceQueryHandler : IRequestHandler<GetByIdLicenceQuery, GetByIdLicenceResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILicenceRepository _licenceRepository;
        private readonly LicenceBusinessRules _licenceBusinessRules;

        public GetByIdLicenceQueryHandler(IMapper mapper, ILicenceRepository licenceRepository, LicenceBusinessRules licenceBusinessRules)
        {
            _mapper = mapper;
            _licenceRepository = licenceRepository;
            _licenceBusinessRules = licenceBusinessRules;
        }

        public async Task<GetByIdLicenceResponse> Handle(GetByIdLicenceQuery request, CancellationToken cancellationToken)
        {
            Licence? licence = await _licenceRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _licenceBusinessRules.LicenceShouldExistWhenSelected(licence);

            GetByIdLicenceResponse response = _mapper.Map<GetByIdLicenceResponse>(licence);
            return response;
        }
    }
}