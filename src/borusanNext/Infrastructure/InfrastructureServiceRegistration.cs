using Application.Services.ElasticSearch;
using Application.Services.ImageService;
using Application.Services.PricingService;
using Infrastructure.Adapters.Elastic;
using Infrastructure.Adapters.ImageService;
using Infrastructure.Adapters.PricingService;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.ElasticSearch.Models;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ElasticSearchConfig elasticSearchConfig)
    {
        services.AddScoped<ImageServiceBase, CloudinaryImageServiceAdapter>();
        services.AddSingleton<IElasticSearch, ElasticSearchServiceAdapter>(_ => new ElasticSearchServiceAdapter(elasticSearchConfig));
        services.AddHttpClient<IPricingService, PricePredictionAdapterService>();

        return services;
    }
}
