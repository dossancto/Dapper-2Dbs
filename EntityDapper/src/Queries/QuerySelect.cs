using EntityDapper.Tables;

namespace EntityDapper.Queries;

public static class QuerySelect
{
    public static SQLQueryable<T> Select<T>(this TableSet<T> table, Func<T, object> fieldObj) where T : class, new()
    {
        var t = fieldObj(new T()).GetType();

        var properties = t.GetProperties().Select(x => x.Name);
        var fields = string.Join(", ", properties);

        var sql = $@"SELECT {fields} FROM ""{table.TableName}""";

        var query = new SQLQueryable<T>(sql, table);

        query.Details.SelectFields = properties.ToList();

        return query;
    }
}
