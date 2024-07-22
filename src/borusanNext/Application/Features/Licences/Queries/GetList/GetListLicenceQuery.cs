using Application.Features.Licences.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Licences.Constants.LicencesOperationClaims;

namespace Application.Features.Licences.Queries.GetList;

public class GetListLicenceQuery : IRequest<GetListResponse<GetListLicenceListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListLicenceQueryHandler : IRequestHandler<GetListLicenceQuery, GetListResponse<GetListLicenceListItemDto>>
    {
        private readonly ILicenceRepository _licenceRepository;
        private readonly IMapper _mapper;

        public GetListLicenceQueryHandler(ILicenceRepository licenceRepository, IMapper mapper)
        {
            _licenceRepository = licenceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLicenceListItemDto>> Handle(GetListLicenceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Licence> licences = await _licenceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLicenceListItemDto> response = _mapper.Map<GetListResponse<GetListLicenceListItemDto>>(licences);
            return response;
        }
    }
}