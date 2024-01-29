namespace Two.Infra.Database.Dapper.Utils;

public interface IQueriable<T>
{
    IQueriable<T> Where(Func<T, bool> f);
}

public class SQLQueryable<T> : IQueriable<T> where T : class
{
    internal string query = string.Empty;
    public DbTable<T> Table { get; }

    public SQLQueryable(string query, DbTable<T> table)
    {
        this.query = query;
        Table = table;
    }

    public IQueriable<T> Where(Func<T, bool> f)
    {
        query += "AND ";

        return this;
    }
}

