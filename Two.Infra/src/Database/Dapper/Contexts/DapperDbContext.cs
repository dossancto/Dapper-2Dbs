using System.Data;
using Npgsql;

namespace Two.Infra.Database.Dapper.Contexts;

public class DapperDbConfiguration
{
    public string Connectionstring { get; set; } = string.Empty;
}

public class DapperContext
{
    private readonly string _connectionString;

    public DapperContext(DapperDbConfiguration configuration)
    {
        _connectionString = configuration.Connectionstring;
    }

    public IDbConnection CreateConnection()
        => new NpgsqlConnection(_connectionString);
}
