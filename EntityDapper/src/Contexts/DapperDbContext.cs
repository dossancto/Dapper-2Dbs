using System.Data;
using Npgsql;

using EntityDapper.Configuration;

namespace EntityDapper.Contexts;

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
