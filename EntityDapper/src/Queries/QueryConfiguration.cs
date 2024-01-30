namespace EntityDapper.Queries;

internal class QueryConfiguration
{
    public string TableName { get; set; } = string.Empty;

    public IList<string> Wheres { get; set; } = new List<string>();

    public IList<string> Joins { get; set; } = new List<string>();
}
