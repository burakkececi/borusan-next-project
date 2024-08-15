using Application.Features.AdvertImages.Queries.GetById;
using Application.Features.AdvertImages.Queries.GetList;
using Application.Features.AdvertImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdvertImages.Queries.GetByAdvertId;
public class GetByAdvertIdAdvertImageQuery: IRequest<GetListResponse<GetByAdvertIdAdvertImageResponse>>
{
    public Guid AdvertId { get; set; }


    public class GetByCarIdAdvertImageQueryHandler : IRequestHandler<GetByAdvertIdAdvertImageQuery, GetListResponse<GetByAdvertIdAdvertImageResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertImageRepository _advertImageRepository;
        private readonly AdvertImageBusinessRules _advertImageBusinessRules;

        public GetByCarIdAdvertImageQueryHandler(IMapper mapper, IAdvertImageRepository advertImageRepository, AdvertImageBusinessRules advertImageBusinessRules)
        {
            _mapper = mapper;
            _advertImageRepository = advertImageRepository;
            _advertImageBusinessRules = advertImageBusinessRules;
        }

        public async Task<GetListResponse<GetByAdvertIdAdvertImageResponse>> Handle(GetByAdvertIdAdvertImageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AdvertImage> advertImages = await _advertImageRepository.GetListAsync(
                predicate: c => c.AdvertId == request.AdvertId,
                index: 0,
                size: 1000,
                cancellationToken: cancellationToken
            );


            GetListResponse<GetByAdvertIdAdvertImageResponse> response = _mapper.Map<GetListResponse<GetByAdvertIdAdvertImageResponse>>(advertImages);
            return response;
        }
    }
}
