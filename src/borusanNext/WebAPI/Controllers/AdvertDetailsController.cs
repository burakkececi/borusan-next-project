using Application.Features.AdvertDetails.Queries.GetDynamic;
using Application.Models;
using Common.Persistance.Elastic.Queries;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvertDetailsController : BaseController
{
    [HttpPost("GetAdvertDetailsDynamic")]
    public async Task<ActionResult<GetListResponse<AdvertDetailsReadModel>>> GetAdvertDetailsDynamic([FromBody] ElasticQuery elasticQuery)
    {
        GetDynamicAdvertDetailsQuery getDynamicQuery = new()
        {
            ElasticQuery = elasticQuery
        };
        GetListResponse<AdvertDetailsReadModel> response = await Mediator.Send(getDynamicQuery);
        return Ok(response);
    }
}
