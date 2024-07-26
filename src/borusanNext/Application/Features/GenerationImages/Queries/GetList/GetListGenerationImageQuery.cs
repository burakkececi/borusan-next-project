using Application.Features.GenerationImages.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.GenerationImages.Constants.GenerationImagesOperationClaims;

namespace Application.Features.GenerationImages.Queries.GetList;

public class GetListGenerationImageQuery : IRequest<GetListResponse<GetListGenerationImageListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListGenerationImageQueryHandler : IRequestHandler<GetListGenerationImageQuery, GetListResponse<GetListGenerationImageListItemDto>>
    {
        private readonly IGenerationImageRepository _generationImageRepository;
        private readonly IMapper _mapper;

        public GetListGenerationImageQueryHandler(IGenerationImageRepository generationImageRepository, IMapper mapper)
        {
            _generationImageRepository = generationImageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGenerationImageListItemDto>> Handle(GetListGenerationImageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<GenerationImage> generationImages = await _generationImageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListGenerationImageListItemDto> response = _mapper.Map<GetListResponse<GetListGenerationImageListItemDto>>(generationImages);
            return response;
        }
    }
}