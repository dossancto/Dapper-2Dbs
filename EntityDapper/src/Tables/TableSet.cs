using EntityDapper.Contexts;

namespace EntityDapper.Tables;

public class TableSet<T> where T : class
{
    public DapperContext Context { get; }
    public string TableName { get; }

    public TableSet(DapperContext context)
      : this(context, typeof(T).GetGenericTypeDefinition().Name) { }

    public TableSet(DapperContext context, string tableName)
    {
        Context = context;
        TableName = tableName;
    }

    public static implicit operator string(TableSet<T> t) => t.TableName;
}

