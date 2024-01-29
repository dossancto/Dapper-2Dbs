using Two.Infra.Database.Dapper.Contexts.Base;

namespace Two.Infra.Database.Dapper.Utils;

public class DbTable<T> where T : class
{
    public DapperContext Context { get; }
    public string TableName { get; }

    public DbTable(DapperContext context)
      : this(context, typeof(T).GetGenericTypeDefinition().Name) { }

    public DbTable(DapperContext context, string tableName)
    {
        Context = context;
        TableName = tableName;
    }

    public static implicit operator string(DbTable<T> t) => t.TableName;
}

