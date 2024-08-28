using Application.Services.PricingService;
using Common.Models;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using static Application.Features.Pricing.Constants.PricingOperationClaims;

namespace Application.Features.Pricing.Queries;
public class PredictPrice : IRequest<PricePredictionResponseModel>, ISecuredRequest
{
    public required PricePredictionRequestModel PricePredictionRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class PredictPriceHandler : IRequestHandler<PredictPrice, PricePredictionResponseModel>
    {
        private readonly IPricingService _pricingService;

        public PredictPriceHandler(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        public async Task<PricePredictionResponseModel> Handle(PredictPrice request, CancellationToken cancellationToken)
        {
            PricePredictionResponseModel response = await _pricingService.GetPredictedPriceAsync(request.PricePredictionRequest);
            return response;
        }
    }
}
