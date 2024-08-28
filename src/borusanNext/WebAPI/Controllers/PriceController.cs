using Application.Features.Pricing.Queries;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PriceController : BaseController
{
    [HttpPost("predict")]
    public async Task<ActionResult<PricePredictionResponseModel>> Predict([FromBody] PricePredictionRequestModel request)
    {
        PredictPrice predictPrice = new() { PricePredictionRequest = request };
        PricePredictionResponseModel response = await Mediator.Send(predictPrice);
        return Ok(response);
    }
}
