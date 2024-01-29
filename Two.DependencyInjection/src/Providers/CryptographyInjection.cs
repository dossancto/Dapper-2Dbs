using Two.Adapters.Cryptographies;
using Two.Infra.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Two.DependencyInjection.Providers;

internal static class CryptographyInjection
{
    public static IServiceCollection AddCryptography(this IServiceCollection services, bool isDev)
    {
        return services.AddScoped<ICryptographys, TheWorstCrypt>();
    }
}


