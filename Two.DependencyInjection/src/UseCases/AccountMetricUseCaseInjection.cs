using Two.Application.Features.Metrics.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Two.DependencyInjection.UseCases;

internal static class AccountMetricUseCaseInjection
{
    public static IServiceCollection AddAccountMetricUseCases(this IServiceCollection services)
      => services
                .AddScoped<CreateAccountMetricsUseCase>()
                .AddScoped<SelectAccountMetricsUseCase>()
                .AddScoped<DeleteAccountMetricsUseCase>()
                .AddScoped<UpdateAccountMetricsUseCase>()
      ;
}
