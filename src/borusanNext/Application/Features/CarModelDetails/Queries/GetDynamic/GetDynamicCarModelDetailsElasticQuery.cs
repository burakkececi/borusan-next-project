using Application.Features.CarModelDetails.Constants;
using Application.Models;
using Application.Services.ElasticSearch;
using Application.Services.Repositories;
using AutoMapper;
using Common.Persistance.Elastic.Models;
using Common.Persistance.Elastic.Queries;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CarModelDetails.Queries.GetDynamic;
public class GetDynamicCarModelDetailsElasticQuery : IRequest<GetListResponse<CarModelDetailsReadModel>>, ISecuredRequest
{
    public ElasticQuery ElasticQuery { get; set; }

    public string[] Roles => [CarModelDetailsOperationClaims.Admin, CarModelDetailsOperationClaims.Read];

    public class GetDynamicCarModelDetailsElasticQueryHandler : IRequestHandler<GetDynamicCarModelDetailsElasticQuery, GetListResponse<CarModelDetailsReadModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertDetailsReadRepository _advertDetailsReadRepository;
        private readonly IElasticSearch _elasticSearch;


        public GetDynamicCarModelDetailsElasticQueryHandler(IMapper mapper, IElasticSearch elasticSearch, IAdvertDetailsReadRepository advertDetailsReadRepository)
        {
            _mapper = mapper;
            _elasticSearch = elasticSearch;
            _advertDetailsReadRepository = advertDetailsReadRepository;
        }

        public async Task<GetListResponse<CarModelDetailsReadModel>> Handle(GetDynamicCarModelDetailsElasticQuery request, CancellationToken cancellationToken)
        {
            var advertDetails = await _elasticSearch.GetSearchBySimpleQueryString<CarModelDetailsReadModel>(new SearchByQueryParameters()
            {
                IndexName = "carmodeldetails",
                From = request.ElasticQuery.From,
                Size = request.ElasticQuery.Size,
                Order = request.ElasticQuery.Order,
                Filters = request.ElasticQuery.Filters
            });

            IPaginate<CarModelDetailsReadModel> listOfAdverts = advertDetails
                                                                .Select(p => p.Item)
                                                                .AsQueryable()
                                                                .ToPaginate(request.ElasticQuery.From, request.ElasticQuery.Size, 0);

            GetListResponse<CarModelDetailsReadModel> response = _mapper.Map<GetListResponse<CarModelDetailsReadModel>>(listOfAdverts);
            return response;
        }
    }
}
