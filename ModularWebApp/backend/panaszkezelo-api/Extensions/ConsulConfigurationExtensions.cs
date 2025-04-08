using Winton.Extensions.Configuration.Consul;
using Winton.Extensions.Configuration.Consul.Parsers;

namespace panaszkezelo_api.Extensions;

public static class ConsulConfigurationExtensions
{
    /// <summary>
    /// Hozzáadja a Consul konfigurációt a megadott IConfigurationBuilder-hez.
    /// </summary>
    /// <param name="builder">A konfigurációs builder.</param>
    /// <returns>A továbbfűzhető IConfigurationBuilder.</returns>
    public static IConfigurationBuilder AddConsulConfiguration(this IConfigurationBuilder builder)
    {
        return builder.AddConsul(
            "appsettings/panaszkezelo-api",
            options =>
            {
                options.ConsulConfigurationOptions = cco =>
                {
                    cco.Address = new Uri("http://localhost:8500");
                };
                options.Optional = false;
                options.ReloadOnChange = true;
                options.Parser = new SimpleConfigurationParser();
            });
    }
}