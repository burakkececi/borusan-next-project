using Application.Features.AdvertImages.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.AdvertImages.Constants.AdvertImagesOperationClaims;

namespace Application.Features.AdvertImages.Queries.GetList;

public class GetListAdvertImageQuery : IRequest<GetListResponse<GetListAdvertImageListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListAdvertImageQueryHandler : IRequestHandler<GetListAdvertImageQuery, GetListResponse<GetListAdvertImageListItemDto>>
    {
        private readonly IAdvertImageRepository _advertImageRepository;
        private readonly IMapper _mapper;

        public GetListAdvertImageQueryHandler(IAdvertImageRepository advertImageRepository, IMapper mapper)
        {
            _advertImageRepository = advertImageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAdvertImageListItemDto>> Handle(GetListAdvertImageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AdvertImage> advertImages = await _advertImageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAdvertImageListItemDto> response = _mapper.Map<GetListResponse<GetListAdvertImageListItemDto>>(advertImages);
            return response;
        }
    }
}