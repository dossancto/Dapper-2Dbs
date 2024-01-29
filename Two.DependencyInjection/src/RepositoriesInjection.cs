using Two.Application.Features.Users.Data;
using Two.Application.Features.Metrics.Data;
using Two.Infra.Database.Dapper.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Two.DependencyInjection;

public static class RepositoriesInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, bool isDev)
    => services
              .AddScoped<IUserRepository, DapperUserRepository>()
              .AddScoped<IAccountMetricsRepository, DapperAccountMetricRepository>()
    ;
}


