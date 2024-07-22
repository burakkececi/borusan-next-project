using Application.Features.Licences.Constants;
using Application.Features.Licences.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Licences.Constants.LicencesOperationClaims;

namespace Application.Features.Licences.Commands.Update;

public class UpdateLicenceCommand : IRequest<UpdatedLicenceResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required int LicenceNo { get; set; }
    public required string LicenceOwner { get; set; }

    public string[] Roles => [Admin, Write, LicencesOperationClaims.Update];

    public class UpdateLicenceCommandHandler : IRequestHandler<UpdateLicenceCommand, UpdatedLicenceResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILicenceRepository _licenceRepository;
        private readonly LicenceBusinessRules _licenceBusinessRules;

        public UpdateLicenceCommandHandler(IMapper mapper, ILicenceRepository licenceRepository,
                                         LicenceBusinessRules licenceBusinessRules)
        {
            _mapper = mapper;
            _licenceRepository = licenceRepository;
            _licenceBusinessRules = licenceBusinessRules;
        }

        public async Task<UpdatedLicenceResponse> Handle(UpdateLicenceCommand request, CancellationToken cancellationToken)
        {
            Licence? licence = await _licenceRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _licenceBusinessRules.LicenceShouldExistWhenSelected(licence);
            licence = _mapper.Map(request, licence);

            await _licenceRepository.UpdateAsync(licence!);

            UpdatedLicenceResponse response = _mapper.Map<UpdatedLicenceResponse>(licence);
            return response;
        }
    }
}