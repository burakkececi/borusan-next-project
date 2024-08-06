using Application.Features.Licences.Constants;
using Application.Features.Licences.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Licences.Constants.LicencesOperationClaims;

namespace Application.Features.Licences.Commands.Create;

public class CreateLicenceCommand : IRequest<CreatedLicenceResponse>, ISecuredRequest
{
    public required int LicenceNo { get; set; }
    public required string ProvidedBy { get; set; }

    public string[] Roles => [Admin, Write, LicencesOperationClaims.Create];

    public class CreateLicenceCommandHandler : IRequestHandler<CreateLicenceCommand, CreatedLicenceResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILicenceRepository _licenceRepository;
        private readonly LicenceBusinessRules _licenceBusinessRules;

        public CreateLicenceCommandHandler(IMapper mapper, ILicenceRepository licenceRepository,
                                         LicenceBusinessRules licenceBusinessRules)
        {
            _mapper = mapper;
            _licenceRepository = licenceRepository;
            _licenceBusinessRules = licenceBusinessRules;
        }

        public async Task<CreatedLicenceResponse> Handle(CreateLicenceCommand request, CancellationToken cancellationToken)
        {
            Licence licence = _mapper.Map<Licence>(request);

            await _licenceRepository.AddAsync(licence);

            CreatedLicenceResponse response = _mapper.Map<CreatedLicenceResponse>(licence);
            return response;
        }
    }
}