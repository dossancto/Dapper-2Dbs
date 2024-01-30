using EntityDapper.Tables;

namespace EntityDapper.Queries;

public interface IQueriable<T>
{
}

public class QueryDetails
{
    public IList<string> SelectFields { get; internal set; } = new List<string>();
    public IList<WhereClause> WhereClauses { get; internal set; } = new List<WhereClause>();
}

public class SQLQueryable<T> : IQueriable<T> where T : class, new()
{
    internal string query = string.Empty;
    public TableSet<T> Table { get; }
    public QueryDetails Details { get; } = new();

    public SQLQueryable(string query, TableSet<T> table)
    {
        this.query = query;
        Table = table;
    }
}

