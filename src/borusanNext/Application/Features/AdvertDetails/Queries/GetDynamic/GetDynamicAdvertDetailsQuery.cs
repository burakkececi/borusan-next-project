using Application.Models;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.ElasticSearch;
using NArchitecture.Core.ElasticSearch.Models;
using NArchitecture.Core.Persistence.Dynamic;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AdvertDetails.Queries.GetDynamic;
public class GetDynamicAdvertDetailsQuery : IRequest<GetListResponse<AdvertDetailsReadModel>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }
    //public string Query { get; set; }
    //public string[] Fields { get; set; }

    public class GetDynamicAdvertDetailsQueryHandler : IRequestHandler<GetDynamicAdvertDetailsQuery, GetListResponse<AdvertDetailsReadModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertDetailsReadRepository _advertDetailsReadRepository;
        private readonly IElasticSearch _elasticSearch;


        public GetDynamicAdvertDetailsQueryHandler(IMapper mapper, IElasticSearch elasticSearch, IAdvertDetailsReadRepository advertDetailsReadRepository)
        {
            _mapper = mapper;
            _elasticSearch = elasticSearch;
            _advertDetailsReadRepository = advertDetailsReadRepository;
        }

        public async Task<GetListResponse<AdvertDetailsReadModel>> Handle(GetDynamicAdvertDetailsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AdvertDetailsReadModel> advertDetails = await _advertDetailsReadRepository.GetListByDynamicAsync(
                dynamic: request.DynamicQuery,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );

            GetListResponse<AdvertDetailsReadModel> response = _mapper.Map<GetListResponse<AdvertDetailsReadModel>>(advertDetails);
            return response;

            //var advertDetails = _elasticSearch.GetSearchBySimpleQueryString<AdvertDetailsReadModel>(new SearchByQueryParameters()
            //{
            //    IndexName = "advertdetails",
            //    From = request.PageRequest.PageIndex,
            //    Size = request.PageRequest.PageSize,
            //    Fields = request.Fields,
            //    Query = request.Query,
            //    QueryName = "advert_details_search"
            //});
        }
    }
}
