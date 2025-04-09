using storage_api.Services;

namespace storage_api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IStorageService, StorageService>();

        return services;
    }
}
