using Application.Features.AdvertImages.Queries.GetByAdvertId;
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
public class GetByGenerationIdGenerationImagesQuery: IRequest<List<GetByGenerationIdGenerationImagesResponse>>
{
    public Guid GenerationId { get; set; }
    public class GetByGenerationIdGenerationImagesQueryHandler : IRequestHandler<GetByGenerationIdGenerationImagesQuery, List<GetByGenerationIdGenerationImagesResponse>>
    {
        private readonly IGenerationImageRepository _generationImageRepository;
        private readonly IMapper _mapper;

        public GetByGenerationIdGenerationImagesQueryHandler(IGenerationImageRepository generationImageRepository, IMapper mapper)
        {
            _generationImageRepository = generationImageRepository;
            _mapper = mapper;
        }

        public async Task<List<GetByGenerationIdGenerationImagesResponse>> Handle(GetByGenerationIdGenerationImagesQuery request, CancellationToken cancellationToken)
        {

            List<GenerationImage> generationImages = await _generationImageRepository.GetByGenerationId(request.GenerationId);

            List<GetByGenerationIdGenerationImagesResponse> response = _mapper.Map<List<GetByGenerationIdGenerationImagesResponse>>(generationImages);
            return response;
        }
    }
}
