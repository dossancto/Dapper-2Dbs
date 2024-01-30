using System.Linq.Expressions;
using System.Reflection;

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
        string? value = null;

        var b = (BinaryExpression)body;

        if (b.Right is MemberExpression memberExpression)
        {
            var objectMember = Expression.Convert(memberExpression, typeof(object));
            var getterLambda = Expression.Lambda<Func<object>>(objectMember);
            var getter = getterLambda.Compile();
            value = $"'{getter()}'";
        }

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
            TargetValue = value ?? args.ElementAt(1),
            Operator = operatorType
        };

        Console.WriteLine(new { whereClause.Column, whereClause.Operator, whereClause.TargetValue });

        query.Details.WhereClauses.Add(whereClause);

        return query;
    }
    public static List<T> GetOddIndexedItems<T>(List<T> inputList)
    {
        List<T> oddIndexedItems = new List<T>();

        for (int i = 0; i < inputList.Count; i++)
        {
            Console.WriteLine(inputList[i].ToString());
            if (i % 2 == 0)
            {
                oddIndexedItems.Add(inputList[i]);
            }
        }

        return oddIndexedItems;
    }

}
