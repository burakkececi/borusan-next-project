using Application.Features.AdvertDetails.Queries.GetDynamic;
using Common.Persistance.Elastic.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvertDetailsController : BaseController
{
    [HttpPost("GetAdvertDetailsDynamic")]
    public async Task<IActionResult> GetAdvertDetailsDynamic([FromBody] ElasticQuery elasticQuery)
    {
        GetDynamicAdvertDetailsQuery getDynamicQuery = new()
        {
            ElasticQuery = elasticQuery
        };
        var response = await Mediator.Send(getDynamicQuery);
        return Ok(response);
    }
}
