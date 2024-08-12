using Application.Features.AdvertDetails.Queries.GetDynamic;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvertDetailsController : BaseController
{
    [HttpPost("GetAdvertDetailsDynamic")]
    public async Task<IActionResult> GetAdvertDetailsDynamic([FromBody] DynamicQuery dynamicQuery, [FromQuery] int pageSize, [FromQuery] int pageIndex)
    {
        GetDynamicAdvertDetailsQuery getDynamicQuery = new()
        {
            DynamicQuery = dynamicQuery,
            PageRequest = new() { PageIndex = pageIndex, PageSize = pageSize }
        };
        var response = await Mediator.Send(getDynamicQuery);
        return Ok(response);
    }
}
