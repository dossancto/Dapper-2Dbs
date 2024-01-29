using Two.Application.Features.Metrics.Data;
using Two.Application.Features.Metrics.Entities;

using NanoidDotNet;
using Two.Infra.Database.Dapper.Contexts;
using Dapper;

namespace Two.Infra.Database.Dapper.Repositories;

public class DapperAccountMetricRepository : IAccountMetricsRepository
{
    private const string TABLE_NAME = "AccountsMetric";
    private readonly AdminDbContext _context;

    public DapperAccountMetricRepository(AdminDbContext context)
    => _context = context;

    public Task<List<AccountMetrics>> All()
    {
        throw new NotImplementedException();
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<AccountMetrics?> FindById(string id)
    {
        using var connection = _context.CreateConnection();

        var query = @$"SELECT * from ""{TABLE_NAME}"" WHERE Id = @Id";

        return await connection
            .QuerySingleOrDefaultAsync<AccountMetrics>
            (query, new { Id = id });
    }

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
