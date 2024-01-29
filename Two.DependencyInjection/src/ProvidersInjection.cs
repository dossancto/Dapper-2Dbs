using Microsoft.Extensions.DependencyInjection;
using Two.DependencyInjection.Providers;

namespace Two.DependencyInjection;

public static class ProvidersInjection
{
    public static IServiceCollection AddProviders(this IServiceCollection services, bool isDev)
    {
        return services
                      .AddCryptography(isDev);
    }
}

