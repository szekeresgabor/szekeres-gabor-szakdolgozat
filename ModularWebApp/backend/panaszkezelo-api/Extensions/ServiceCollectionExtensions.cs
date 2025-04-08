using panaszkezelo_api.Services;

namespace panaszkezelo_api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPanaszService, PanaszService>();

        return services;
    }
}
