using Two.Application.Features.Users.Data;
using Two.Infra.Database.Dapper.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Two.DependencyInjection;

public static class RepositoriesInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, bool isDev)
    => services
              .AddScoped<IUserRepository, DapperUserRepository>()
    ;
}


