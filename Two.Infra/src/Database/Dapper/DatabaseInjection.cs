using Microsoft.Extensions.DependencyInjection;
using Two.Infra.Database.Dapper.Contexts;

namespace Two.Infra.Database.Dapper;

public static class DatabaseInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddTransient<AdminDbContext>(_ => new(new()
        {
            ConnectionstringEnv = "ADMIN_POSTGRES"
        }));

        services.AddTransient<GeneralDbContext>(_ => new(new()
        {
            ConnectionstringEnv = "GENERAL_POSTGRES"
        }));

        return services;
    }
}
