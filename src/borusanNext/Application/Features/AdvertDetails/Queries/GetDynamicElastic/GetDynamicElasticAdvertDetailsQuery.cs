using Application.Models;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Application.Features.AdvertDetails.Constants;
using Common.Persistance.Elastic.Queries;
using Common.Persistance.Elastic.Models;
using Application.Services.ElasticSearch;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AdvertDetails.Queries.GetDynamic;
public class GetDynamicElasticAdvertDetailsQuery : IRequest<GetListResponse<AdvertDetailsReadModel>>, ISecuredRequest
{
    public ElasticQuery ElasticQuery { get; set; }

    public string[] Roles => [AdvertDetailsOperationClaims.Admin, AdvertDetailsOperationClaims.Read];

    public class GetDynamicElasticAdvertDetailsQueryHandler : IRequestHandler<GetDynamicElasticAdvertDetailsQuery, GetListResponse<AdvertDetailsReadModel>>
    {
        private readonly IMapper _mapper;
        private readonly IElasticSearch _elasticSearch;


        public GetDynamicElasticAdvertDetailsQueryHandler(IMapper mapper, IElasticSearch elasticSearch)
        {
            _mapper = mapper;
            _elasticSearch = elasticSearch;
        }

        public async Task<GetListResponse<AdvertDetailsReadModel>> Handle(GetDynamicElasticAdvertDetailsQuery request, CancellationToken cancellationToken)
        {
            //IPaginate<AdvertDetailsReadModel> advertDetails = await _advertDetailsReadRepository.GetListByDynamicAsync(
            //    dynamic: request.DynamicQuery,
            //    index: request.PageRequest.PageIndex,
            //    size: request.PageRequest.PageSize,
            //    cancellationToken: cancellationToken
            //    );

            var advertDetails = await _elasticSearch.GetSearchBySimpleQueryString<AdvertDetailsReadModel>(new SearchByQueryParameters()
            {
                IndexName = "advertdetails",
                From = request.ElasticQuery.From,
                Size = request.ElasticQuery.Size,
                Order = request.ElasticQuery.Order,
                Queries = request.ElasticQuery.Queries,
                Filters = request.ElasticQuery.Filters
            });

            IPaginate<AdvertDetailsReadModel> listOfAdverts = advertDetails
                                                                .Select(p => p.Item)
                                                                .AsQueryable()
                                                                .ToPaginate(request.ElasticQuery.From, request.ElasticQuery.Size, 0);

            GetListResponse<AdvertDetailsReadModel> response = _mapper.Map<GetListResponse<AdvertDetailsReadModel>>(listOfAdverts);
            return response;
        }
    }
}
