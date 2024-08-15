using Application.Features.AdvertImages.Rules;
using Application.Features.GenerationImages.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GenerationImages.Queries.GetByGenerationId;
public class GetByGenerationIdGenerationImagesQuery: IRequest<GetListResponse<GetByGenerationIdGenerationImagesResponse>>
{
    public Guid GenerationId { get; set; }
    public class GetByGenerationIdGenerationImagesQueryHandler : IRequestHandler<GetByGenerationIdGenerationImagesQuery, GetListResponse<GetByGenerationIdGenerationImagesResponse>>
    {
        private readonly IGenerationImageRepository _generationImageRepository;
        private readonly IMapper _mapper;

        public GetByGenerationIdGenerationImagesQueryHandler(IGenerationImageRepository generationImageRepository, IMapper mapper)
        {
            _generationImageRepository = generationImageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetByGenerationIdGenerationImagesResponse>> Handle(GetByGenerationIdGenerationImagesQuery request, CancellationToken cancellationToken)
        {
            IPaginate<GenerationImage> generationImages = await _generationImageRepository.GetListAsync(
                predicate: c => c.GenerationId == request.GenerationId,
                index: 0,
                size: 1000,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetByGenerationIdGenerationImagesResponse> response = _mapper.Map<GetListResponse<GetByGenerationIdGenerationImagesResponse>>(generationImages);
            return response;
        }
    }
}
