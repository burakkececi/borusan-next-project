using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BorusanNextDb")));
        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());

        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IAdvertRepository, AdvertRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IBlogItemTagRepository, BlogItemTagRepository>();
        services.AddScoped<IBodyShellPartRepository, BodyShellPartRepository>();
        services.AddScoped<IBodyTypeRepository, BodyTypeRepository>();
        services.AddScoped<ICampaignRepository, CampaignRepository>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<ICarColorRepository, CarColorRepository>();
        services.AddScoped<ICarModelRepository, CarModelRepository>();
        services.AddScoped<IChassisPartRepository, ChassisPartRepository>();
        services.AddScoped<ICustomerAdvertLogRepository, CustomerAdvertLogRepository>();
        services.AddScoped<IEngineRepository, EngineRepository>();
        services.AddScoped<IExpertizeResultRepository, ExpertizeResultRepository>();
        services.AddScoped<IFuelConsumptionRepository, FuelConsumptionRepository>();
        services.AddScoped<IFuelTypeRepository, FuelTypeRepository>();
        services.AddScoped<IGenerationRepository, GenerationRepository>();
        services.AddScoped<ILicenceRepository, LicenceRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IModalExtensionRepository, ModalExtensionRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ITransmissionRepository, TransmissionRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ISellerRepository, SellerRepository>();
        services.AddScoped<IAdvertImageRepository, AdvertImageRepository>();
        services.AddScoped<IGenerationImageRepository, GenerationImageRepository>();
        return services;
    }
}
