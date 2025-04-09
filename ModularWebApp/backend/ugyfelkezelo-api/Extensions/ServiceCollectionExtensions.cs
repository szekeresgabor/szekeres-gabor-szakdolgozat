using FluentValidation;
using FluentValidation.AspNetCore;
using ugyfelkezelo_api.Services;

namespace ugyfelkezelo_api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUgyfelService, UgyfelService>();

        return services;
    }

    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssemblyContaining<UgyfelDtoValidator>();

        return services;
    }
}
