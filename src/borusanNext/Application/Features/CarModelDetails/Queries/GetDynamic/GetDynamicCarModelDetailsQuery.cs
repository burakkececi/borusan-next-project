using Application.Features.AdvertDetails.Constants;
using Application.Features.AdvertDetails.Queries.GetDynamic;
using Application.Features.CarModelDetails.Constants;
using Application.Models;
using Application.Services.ElasticSearch;
using Application.Services.Repositories;
using AutoMapper;
using Common.Persistance.Elastic.Queries;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarModelDetails.Queries.GetDynamic;
public class GetDynamicCarModelDetailsQuery : IRequest<GetListResponse<CarModelDetailsReadModel>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public string[] Roles => [CarModelDetailsOperationClaims.Admin, CarModelDetailsOperationClaims.Read];

    public class GetDynamicCarModelDetailsQueryHandler : IRequestHandler<GetDynamicCarModelDetailsQuery, GetListResponse<CarModelDetailsReadModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICarModelDetailsReadRepository _carModelDetailsReadRepository;


        public GetDynamicCarModelDetailsQueryHandler(IMapper mapper, ICarModelDetailsReadRepository carModelDetailsReadRepository)
        {
            _mapper = mapper;
            _carModelDetailsReadRepository = carModelDetailsReadRepository;
        }

        public async Task<GetListResponse<CarModelDetailsReadModel>> Handle(GetDynamicCarModelDetailsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CarModelDetailsReadModel> carModelDetails = await _carModelDetailsReadRepository.GetListByDynamicAsync(
                dynamic: request.DynamicQuery,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );

            GetListResponse<CarModelDetailsReadModel> response = _mapper.Map<GetListResponse<CarModelDetailsReadModel>>(carModelDetails);
            return response;
        }
    }
}
