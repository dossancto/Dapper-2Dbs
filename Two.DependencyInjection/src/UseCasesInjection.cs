using Two.DependencyInjection.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Two.DependencyInjection;

public static class UseCasesInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
      => services
                .AddUserUseCases();
}



