using Application.Features.Licences.Constants;
using Application.Features.Licences.Constants;
using Application.Features.Licences.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Licences.Constants.LicencesOperationClaims;

namespace Application.Features.Licences.Commands.Delete;

public class DeleteLicenceCommand : IRequest<DeletedLicenceResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, LicencesOperationClaims.Delete];

    public class DeleteLicenceCommandHandler : IRequestHandler<DeleteLicenceCommand, DeletedLicenceResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILicenceRepository _licenceRepository;
        private readonly LicenceBusinessRules _licenceBusinessRules;

        public DeleteLicenceCommandHandler(IMapper mapper, ILicenceRepository licenceRepository,
                                         LicenceBusinessRules licenceBusinessRules)
        {
            _mapper = mapper;
            _licenceRepository = licenceRepository;
            _licenceBusinessRules = licenceBusinessRules;
        }

        public async Task<DeletedLicenceResponse> Handle(DeleteLicenceCommand request, CancellationToken cancellationToken)
        {
            Licence? licence = await _licenceRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _licenceBusinessRules.LicenceShouldExistWhenSelected(licence);

            await _licenceRepository.DeleteAsync(licence!);

            DeletedLicenceResponse response = _mapper.Map<DeletedLicenceResponse>(licence);
            return response;
        }
    }
}