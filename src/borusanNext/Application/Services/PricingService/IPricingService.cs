using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PricingService;
public interface IPricingService
{
    public Task<PricePredictionResponseModel> GetPredictedPriceAsync(PricePredictionRequestModel request);
}
