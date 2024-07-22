using Application.Features.ChassisParts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.ChassisParts.Constants.ChassisPartsOperationClaims;

namespace Application.Features.ChassisParts.Queries.GetList;

public class GetListChassisPartQuery : IRequest<GetListResponse<GetListChassisPartListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListChassisPartQueryHandler : IRequestHandler<GetListChassisPartQuery, GetListResponse<GetListChassisPartListItemDto>>
    {
        private readonly IChassisPartRepository _chassisPartRepository;
        private readonly IMapper _mapper;

        public GetListChassisPartQueryHandler(IChassisPartRepository chassisPartRepository, IMapper mapper)
        {
            _chassisPartRepository = chassisPartRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListChassisPartListItemDto>> Handle(GetListChassisPartQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ChassisPart> chassisParts = await _chassisPartRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListChassisPartListItemDto> response = _mapper.Map<GetListResponse<GetListChassisPartListItemDto>>(chassisParts);
            return response;
        }
    }
}