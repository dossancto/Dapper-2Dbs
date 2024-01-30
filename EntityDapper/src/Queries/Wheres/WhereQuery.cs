namespace EntityDapper.Queries;

public enum ComOperator
{
    Eq,
    Gt,
    Lt,
    Gte,
    Lte,
    Neq
}

public class WhereClause
{
    public string Column = string.Empty;
    public System.Linq.Expressions.ExpressionType Operator;
    public string TargetValue = string.Empty;
}

public static class WhereQuery
{
    public static SQLQueryable<T> Where<T>(this SQLQueryable<T> query, System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class, new()
    {
        var param = predicate.Parameters[0];
        var paramName = param.Name;
        var body = predicate.Body;
        var operatorType = body.ReduceExtensions().NodeType;
        var content = predicate.Body.ToString();

        var tokens = content
                          .Replace(")", "")
                          .Replace("(", "")
                          .Replace("\"", "'")
                          .Replace($"{paramName}.", "")
                          .Split(" ")
                          .ToList();

        var args = GetOddIndexedItems(tokens);

        var whereClause = new WhereClause
        {
            Column = args.ElementAt(0),
            TargetValue = args.ElementAt(1),
            Operator = operatorType
        };

        query.Details.WhereClauses.Add(whereClause);

        return query;
    }
    public static List<T> GetOddIndexedItems<T>(List<T> inputList)
    {
        List<T> oddIndexedItems = new List<T>();

        for (int i = 0; i < inputList.Count; i++)
        {
            if (i % 2 == 0)
            {
                oddIndexedItems.Add(inputList[i]);
            }
        }

        return oddIndexedItems;
    }

}
