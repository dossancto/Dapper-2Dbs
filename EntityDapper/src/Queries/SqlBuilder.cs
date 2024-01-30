using System.Linq.Expressions;
using System.Text;

namespace EntityDapper.Queries;

internal static class SqlBuilder
{
    public static string BuildSql<T>(SQLQueryable<T> query) where T : class, new()
    {
        var fields = string.Join(", ", query.Details.SelectFields);

        var sql = new StringBuilder($@"SELECT {fields} FROM ""{query.Table.TableName}""");

        if (query.Details.WhereClauses.Any())
            sql.Append($" WHERE {BuildWhereClauses(query)}");

        return sql.ToString();
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
            ExpressionType.Or => "or",
            _ => throw new NotImplementedException()
        };
    }
}
