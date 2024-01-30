using Two.Application.Features.Metrics.Data;
using Two.Application.Features.Metrics.Entities;

using EntityDapper.Queries;

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
            .Select(x => new { x.Id })
            .FindAll();

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<AccountMetrics?> FindById(string id)
      => (await _context
              .AccountMetrics
              .Select(x => new { x.Id })
              .Where(x => x.Id == id)
              .FindAll())
              .FirstOrDefault();

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
