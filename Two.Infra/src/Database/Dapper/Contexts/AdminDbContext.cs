using Two.Application.Features.Metrics.Entities;
using Two.Infra.Database.Dapper.Contexts.Base;
using Two.Infra.Database.Dapper.Utils;

namespace Two.Infra.Database.Dapper.Contexts;

public class AdminDbContext(DapperDbConfiguration configuration) : DapperContext(configuration)
{
    public DbTable<AccountMetrics> AccountMetrics => new(this, "AccountsMetric");
}
