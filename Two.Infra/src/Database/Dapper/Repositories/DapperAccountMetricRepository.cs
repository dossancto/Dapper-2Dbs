using Two.Application.Features.Metrics.Data;
using Two.Application.Features.Metrics.Entities;

using NanoidDotNet;
using Two.Infra.Database.Dapper.Contexts;
using Dapper;
using Two.Infra.Database.Dapper.Utils;

namespace Two.Infra.Database.Dapper.Repositories;

public class DapperAccountMetricRepository : IAccountMetricsRepository
{
    private string TABLE_NAME { get; }
    private readonly AdminDbContext _context;

    public DapperAccountMetricRepository(AdminDbContext context)
    {
        _context = context;
        TABLE_NAME = context.AccountMetrics;
    }

    public Task<IEnumerable<AccountMetrics>> All()
    => _context
    .AccountMetrics
    .All();

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<AccountMetrics?> FindById(string id)
      => _context
              .AccountMetrics
              .Find(id);

    public async Task<AccountMetrics> Save(AccountMetrics metric)
    {
        using var connection = _context.CreateConnection();

        metric.Id = Nanoid.Generate();

        var query = @$"INSERT INTO ""{TABLE_NAME}"" VALUES (@Id, @AccountCount, @DayCount)";

        await connection.ExecuteAsync(query, metric);

        var createdUser = await FindById(metric.Id);

        return createdUser!;
    }

    public Task<AccountMetrics> Update(AccountMetrics entity)
    {
        throw new NotImplementedException();
    }
}
