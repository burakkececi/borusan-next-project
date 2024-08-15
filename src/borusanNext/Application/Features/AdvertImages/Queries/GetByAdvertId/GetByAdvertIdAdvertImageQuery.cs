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
public class GetByAdvertIdAdvertImageQuery: IRequest<List<GetByAdvertIdAdvertImageResponse>>
{
    public Guid AdvertId { get; set; }


    public class GetByCarIdAdvertImageQueryHandler : IRequestHandler<GetByAdvertIdAdvertImageQuery, List<GetByAdvertIdAdvertImageResponse>>
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

        public async Task<List<GetByAdvertIdAdvertImageResponse>> Handle(GetByAdvertIdAdvertImageQuery request, CancellationToken cancellationToken)
        {
            List<AdvertImage> advertImages = await _advertImageRepository.GetByAdvertId( request.AdvertId);

            List<GetByAdvertIdAdvertImageResponse> response = _mapper.Map<List<GetByAdvertIdAdvertImageResponse>>(advertImages);
            return response;
        }
    }
}
