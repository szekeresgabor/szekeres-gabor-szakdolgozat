using FluentValidation;
using FluentValidation.AspNetCore;
using panaszkezelo_api.Services;

namespace panaszkezelo_api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPanaszService, PanaszService>();

        return services;
    }

    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssemblyContaining<PanaszDtoValidator>();

        return services;
    }
}
