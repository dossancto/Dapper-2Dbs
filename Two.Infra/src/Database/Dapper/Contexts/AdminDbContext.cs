using EntityDapper.Configuration;
using EntityDapper.Contexts;
using EntityDapper.Tables;
using Two.Application.Features.Metrics.Entities;

namespace Two.Infra.Database.Dapper.Contexts;

public class AdminDbContext(DapperDbConfiguration configuration) : DapperContext(configuration)
{
    public TableSet<AccountMetrics> AccountMetrics => new(this, "AccountsMetric");
}
