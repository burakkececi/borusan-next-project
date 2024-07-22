using Application.Features.CarColors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.CarColors.Constants.CarColorsOperationClaims;

namespace Application.Features.CarColors.Queries.GetList;

public class GetListCarColorQuery : IRequest<GetListResponse<GetListCarColorListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListCarColorQueryHandler : IRequestHandler<GetListCarColorQuery, GetListResponse<GetListCarColorListItemDto>>
    {
        private readonly ICarColorRepository _carColorRepository;
        private readonly IMapper _mapper;

        public GetListCarColorQueryHandler(ICarColorRepository carColorRepository, IMapper mapper)
        {
            _carColorRepository = carColorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCarColorListItemDto>> Handle(GetListCarColorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CarColor> carColors = await _carColorRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCarColorListItemDto> response = _mapper.Map<GetListResponse<GetListCarColorListItemDto>>(carColors);
            return response;
        }
    }
}