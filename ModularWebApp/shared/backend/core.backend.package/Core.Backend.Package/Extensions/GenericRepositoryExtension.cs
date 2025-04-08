using Microsoft.EntityFrameworkCore;
using Core.Backend.Package.Data;

namespace Core.Backend.Package.Extensions;

/// <summary>
/// Extension metódus a GenericRepository egyszerű regisztrálásához.
/// </summary>
public static class GenericRepositoryExtensions
{
    /// <summary>
    /// Regisztrálja a GenericRepository implementációt az adott entitás- és DbContext típushoz.
    /// </summary>
    /// <typeparam name="TEntity">Az entitás típusa.</typeparam>
    /// <typeparam name="TContext">A DbContext típusa.</typeparam>
    /// <param name="services">A szolgáltatásgyűjtemény, amelyhez a regisztráció történik.</param>
    public static IServiceCollection AddGenericRepository<TEntity, TContext>(this IServiceCollection services)
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        services.AddScoped<IGenericRepository<TEntity>, GenericRepository<TEntity, TContext>>();
        return services;
    }
}