using Application.Services.PricingService;
using Common.Models;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Adapters.PricingService;
public class PricePredictionAdapterService : IPricingService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiEndpoint;
    public PricePredictionAdapterService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiEndpoint = configuration["Pricing:Endpoint"];
    }

    public async Task<PricePredictionResponseModel> GetPredictedPriceAsync(PricePredictionRequestModel request)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_apiEndpoint, jsonContent);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PricePredictionResponseModel>(responseContent);
            return result;
        }
        else
        {
            throw new Exception($"Error from Flask API: {response.ReasonPhrase}");
        }
    }
}
