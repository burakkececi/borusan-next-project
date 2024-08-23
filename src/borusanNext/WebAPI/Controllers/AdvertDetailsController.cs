using Application.Features.AdvertDetails.Queries.GetDynamic;
using Application.Models;
using Common.Persistance.Elastic.Queries;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvertDetailsController : BaseController
{
    [HttpPost("GetAdvertDetailsDynamic")]
    public async Task<ActionResult<GetListResponse<AdvertDetailsReadModel>>> GetAdvertDetailsDynamic([FromBody] DynamicQuery dynamicQuery, [FromQuery] PageRequest pageRequest)
    {
        GetDynamicAdvertDetailsQuery getDynamicQuery = new()
        {
            PageRequest = pageRequest,
            DynamicQuery = dynamicQuery
        };
        GetListResponse<AdvertDetailsReadModel> response = await Mediator.Send(getDynamicQuery);
        return Ok(response);
    }

    [HttpPost("GetAdvertDetailsDynamicElastic")]
    public async Task<ActionResult<GetListResponse<AdvertDetailsReadModel>>> GetAdvertDetailsDynamicElastic([FromBody] ElasticQuery elasticQuery)
    {
        GetDynamicElasticAdvertDetailsQuery getDynamicQuery = new()
        {
            ElasticQuery = elasticQuery
        };
        GetListResponse<AdvertDetailsReadModel> response = await Mediator.Send(getDynamicQuery);
        return Ok(response);
    }
}
