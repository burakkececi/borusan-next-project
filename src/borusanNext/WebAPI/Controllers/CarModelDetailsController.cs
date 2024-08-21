using Application.Features.CarModelDetails.Queries.GetDynamic;
using Application.Models;
using Common.Persistance.Elastic.Queries;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarModelDetailsController : BaseController
{
    [HttpPost("GetDynamicElastic")]
    public async Task<ActionResult<GetListResponse<CarModelDetailsReadModel>>> GetDynamic([FromBody] ElasticQuery elasticQuery)
    {
        GetDynamicCarModelDetailsElasticQuery getDynamicQuery = new()
        {
            ElasticQuery = elasticQuery
        };
        GetListResponse<CarModelDetailsReadModel> response = await Mediator.Send(getDynamicQuery);
        return Ok(response);
    }

    [HttpPost("GetDynamic")]
    public async Task<ActionResult<GetListResponse<CarModelDetailsReadModel>>> GetDynamic([FromBody] DynamicQuery dynamicQuery, [FromQuery] PageRequest pageRequest)
    {
        GetDynamicCarModelDetailsQuery getDynamicQuery = new()
        {
            DynamicQuery = dynamicQuery,
            PageRequest = pageRequest
        };
        GetListResponse<CarModelDetailsReadModel> response = await Mediator.Send(getDynamicQuery);
        return Ok(response);
    }
}
