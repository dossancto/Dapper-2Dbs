using Microsoft.Extensions.DependencyInjection;
using Two.Infra.Database.Dapper.Contexts;

namespace Two.Infra.Database.Dapper;

public static class DatabaseInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        var adminConnectionString = Environment.GetEnvironmentVariable("ADMIN_POSTGRES") ?? throw new ArgumentException("<ADMIN_POSTGRES> not found.");
        var generalConnectionString = Environment.GetEnvironmentVariable("GENERAL_POSTGRES") ?? throw new ArgumentException("<GENERAL_POSTGRES> not found.");

        services.AddTransient<AdminDbContext>(_ => new(new()
        {
            Connectionstring = adminConnectionString
        }));

        services.AddTransient<GeneralDbContext>(_ => new(new()
        {
            Connectionstring = generalConnectionString
        }));

        return services;
    }
}
