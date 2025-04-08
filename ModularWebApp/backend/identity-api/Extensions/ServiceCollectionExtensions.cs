using Core.Backend.Package.Extensions;
using identity_api.Data;
using identity_api.Services;

namespace identity_api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddGenericRepository<User, IdentityDbContext>();

        return services;
    }
}
