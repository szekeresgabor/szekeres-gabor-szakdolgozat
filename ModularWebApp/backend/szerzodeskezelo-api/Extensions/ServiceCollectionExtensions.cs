using FluentValidation;
using FluentValidation.AspNetCore;
using szerzodeskezelo_api.Services;

namespace szerzodeskezelo_api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ISzerzodesService, SzerzodesService>();

        return services;
    }

    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssemblyContaining<SzerzodesDtoValidator>();

        return services;
    }
}
