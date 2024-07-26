using System.Reflection;
using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using NArchitecture.Core.Application.Pipelines.Validation;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Abstraction;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Configurations;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Serilog.File;
using NArchitecture.Core.ElasticSearch;
using NArchitecture.Core.ElasticSearch.Models;
using NArchitecture.Core.Localization.Resource.Yaml.DependencyInjection;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Mailing.MailKit;
using NArchitecture.Core.Security.DependencyInjection;
using NArchitecture.Core.Security.JWT;
using Application.Services.Brands;
using Application.Services.Adverts;
using Application.Services.Appointments;
using Application.Services.Blogs;
using Application.Services.BlogItemTags;
using Application.Services.BodyShellParts;
using Application.Services.BodyTypes;
using Application.Services.Campaigns;
using Application.Services.Cars;
using Application.Services.CarColors;
using Application.Services.CarModels;
using Application.Services.ChassisParts;
using Application.Services.CustomerAdvertLogs;
using Application.Services.Engines;
using Application.Services.ExpertizeResults;
using Application.Services.FuelConsumptions;
using Application.Services.FuelTypes;
using Application.Services.Generations;
using Application.Services.Licences;
using Application.Services.Locations;
using Application.Services.ModalExtensions;
using Application.Services.Tags;
using Application.Services.Transmissions;
using Application.Services.Customers;
using Application.Services.Sellers;
using Application.Services.AdvertImages;
using Application.Services.GenerationImages;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        MailSettings mailSettings,
        FileLogConfiguration fileLogConfiguration,
        ElasticSearchConfig elasticSearchConfig,
        TokenOptions tokenOptions
    )
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>(_ => new MailKitMailService(mailSettings));
        services.AddSingleton<ILogger, SerilogFileLogger>(_ => new SerilogFileLogger(fileLogConfiguration));
        services.AddSingleton<IElasticSearch, ElasticSearchManager>(_ => new ElasticSearchManager(elasticSearchConfig));

        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddYamlResourceLocalization();

        services.AddSecurityServices<Guid, int, Guid>(tokenOptions);

        services.AddScoped<IBrandService, BrandManager>();
        services.AddScoped<IAdvertService, AdvertManager>();
        services.AddScoped<IAppointmentService, AppointmentManager>();
        services.AddScoped<IBlogService, BlogManager>();
        services.AddScoped<IBlogItemTagService, BlogItemTagManager>();
        services.AddScoped<IBodyShellPartService, BodyShellPartManager>();
        services.AddScoped<IBodyTypeService, BodyTypeManager>();
        services.AddScoped<ICampaignService, CampaignManager>();
        services.AddScoped<ICarService, CarManager>();
        services.AddScoped<ICarColorService, CarColorManager>();
        services.AddScoped<ICarModelService, CarModelManager>();
        services.AddScoped<IChassisPartService, ChassisPartManager>();
        services.AddScoped<ICustomerAdvertLogService, CustomerAdvertLogManager>();
        services.AddScoped<IEngineService, EngineManager>();
        services.AddScoped<IExpertizeResultService, ExpertizeResultManager>();
        services.AddScoped<IFuelConsumptionService, FuelConsumptionManager>();
        services.AddScoped<IFuelTypeService, FuelTypeManager>();
        services.AddScoped<IGenerationService, GenerationManager>();
        services.AddScoped<ILicenceService, LicenceManager>();
        services.AddScoped<ILocationService, LocationManager>();
        services.AddScoped<IModalExtensionService, ModalExtensionManager>();
        services.AddScoped<ITagService, TagManager>();
        services.AddScoped<ITransmissionService, TransmissionManager>();
        services.AddScoped<ICustomerService, CustomerManager>();
        services.AddScoped<ISellerService, SellerManager>();
        services.AddScoped<IAdvertImageService, AdvertImageManager>();
        services.AddScoped<IGenerationImageService, GenerationImageManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
