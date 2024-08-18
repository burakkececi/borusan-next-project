using Application.Services.ElasticSearch;
using Application.Services.ImageService;
using Infrastructure.Adapters.Elastic;
using Infrastructure.Adapters.ImageService;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.ElasticSearch.Models;
using NArchitecture.Core.Mailing;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ElasticSearchConfig elasticSearchConfig)
    {
        services.AddScoped<ImageServiceBase, CloudinaryImageServiceAdapter>();
        services.AddSingleton<IElasticSearch, ElasticSearchServiceAdapter>(_ => new ElasticSearchServiceAdapter(elasticSearchConfig));

        return services;
    }
}
