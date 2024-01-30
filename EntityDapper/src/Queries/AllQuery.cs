using Dapper;

namespace EntityDapper.Queries;

public static class FindTodos
{
    public static async Task<IEnumerable<T>> FindAll<T>(this SQLQueryable<T> table) where T : class, new()
    {
        using var connection = table.Table.Context.CreateConnection();

        var sql = SqlBuilder.BuildSql(table);

        Console.WriteLine(sql);

        return await connection.QueryAsync<T>(sql);
    }

}
