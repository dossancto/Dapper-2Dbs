using System.Data;
using Npgsql;

namespace Two.Infra.Database.Dapper.Contexts.Base;

public class DapperContext
{
    private readonly string _connectionString;

    public DapperContext(DapperDbConfiguration c)
    {
        _connectionString = c.Connectionstring
                            ?? c.ConnectionStringFromEnv()
                            ?? throw new ArgumentException("CONNECTION STRING NOT FOUND")
                            ;
    }

    public IDbConnection CreateConnection()
        => new NpgsqlConnection(_connectionString);
}
