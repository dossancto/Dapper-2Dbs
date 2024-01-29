using Dapper;

namespace Two.Infra.Database.Dapper.Utils;

public static class DapperBaseRepositoryExtension
{
    public static async Task<T?> Find<T>(this DbTable<T> table, string Id) where T : class
    {
        using var connection = table.Context.CreateConnection();

        var query = @$"SELECT * from ""{table.TableName}"" WHERE Id = @Id";

        return await connection.QuerySingleOrDefaultAsync<T>(query, new { Id });
    }

    public static async Task<IEnumerable<T>> All<T>(this DbTable<T> table) where T : class
    {
        using var connection = table.Context.CreateConnection();

        var query = @$"SELECT * from ""{table.TableName}""";

        return await connection.QueryAsync<T>(query);
    }

    public static SQLQueryable<T> Select<T>(this DbTable<T> table, Func<T, object> fieldObj) where T : class, new()
    {
        var t = fieldObj(new T()).GetType();

        var properties = t.GetProperties().Select(x => x.Name);
        var fields = string.Join(", ", properties);

        var sql = $@"SELECT {fields} FROM ""{table.TableName}"";";

        return new(sql, table);
    }
}

public static class DapperQueryableBaseRepositoryExtension
{
    public static async Task<IEnumerable<T>> All<T>(this SQLQueryable<T> table) where T : class
    {
        using var connection = table.Table.Context.CreateConnection();

        var sql = table.query;

        Console.WriteLine(sql);

        return await connection.QueryAsync<T>(sql);
    }
}
