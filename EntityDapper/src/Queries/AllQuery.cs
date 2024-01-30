using Dapper;
using ExpressionType = System.Linq.Expressions.ExpressionType;

namespace EntityDapper.Queries;

public static class FindTodos
{
    public static async Task<IEnumerable<T>> Todos<T>(this SQLQueryable<T> table) where T : class, new()
    {
        using var connection = table.Table.Context.CreateConnection();

        var sql = table.query;

        if (table.Details.WhereClauses.Any())
            sql += $" WHERE {BuildWhereClauses(table)}";

        Console.WriteLine(sql);


        return await connection.QueryAsync<T>(sql);
    }

    private static string BuildWhereClauses<T>(SQLQueryable<T> details) where T : class, new()
    {
        var wheres = details.Details.WhereClauses;
        var queries = wheres.Select(x =>
            $"{x.Column} {x.Operator.SqlOperator()} {x.TargetValue}"
        );
        return string.Join(" AND ", queries);
    }

    public static string SqlOperator(this ExpressionType op)
    {
        return op switch
        {
            ExpressionType.Equal => "=",
            _ => throw new NotImplementedException()
        };
    }
}
