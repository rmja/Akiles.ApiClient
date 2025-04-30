using System.Linq.Expressions;
using System.Text;
using System.Text.Json;

namespace Akiles.ApiClient;

public record class Sort(string FieldName, SortOrder Order) : IFormattable
{
    public static implicit operator Sort(string value)
    {
        var parts = value.Split(':', 2);
        var order = parts[1] switch
        {
            "asc" => SortOrder.Asc,
            "desc" => SortOrder.Desc,
            _ => throw new InvalidCastException()
        };
        return new Sort(parts[0], order);
    }

    public override string ToString()
    {
        return FieldName + ":" + Order.ToString().ToLowerInvariant();
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return ToString();
    }
}

public record class Sort<T> : Sort, IFormattable
{
    private static readonly JsonNamingPolicy _namingPolicy = JsonNamingPolicy.SnakeCaseLower;

    public Sort(string fieldName, SortOrder order)
        : base(fieldName, order) { }

    public Sort(Expression<Func<T, object?>> selector, SortOrder order)
        : base(GetPath(selector.Body), order) { }

    private static string GetPath(Expression expression)
    {
        if (expression is UnaryExpression unary)
        {
            expression = unary.Operand;
        }

        string? append = null;
        if (expression is MethodCallExpression methodCall)
        {
            if (methodCall.Method.Name != "get_Item")
            {
                throw new NotSupportedException();
            }

            var arg = methodCall.Arguments[0];
            if (arg is ConstantExpression constant)
            {
                append = (string)constant.Value!;
            }
            else if (arg is MemberExpression member)
            {
                throw new NotSupportedException();
            }
            else
            {
                append = arg.ToString();
            }
            expression = methodCall.Object!;
        }

        var memberExpression = expression as MemberExpression;
        var fieldPath = new StringBuilder();

        while (memberExpression is not null)
        {
            if (fieldPath.Length > 0)
            {
                fieldPath.Append('.');
            }

            fieldPath.Append(_namingPolicy.ConvertName(memberExpression.Member.Name));

            memberExpression = memberExpression.Expression as MemberExpression;
        }

        if (append is not null)
        {
            fieldPath.Append('.');
            fieldPath.Append(append);
        }

        return fieldPath.ToString();
    }

    public static implicit operator Sort<T>(string value)
    {
        var parts = value.Split(':', 2);
        var order = parts[1] switch
        {
            "asc" => SortOrder.Asc,
            "desc" => SortOrder.Desc,
            _ => throw new InvalidCastException()
        };
        return new Sort<T>(parts[0], order);
    }

    public override string ToString() => base.ToString();
}

public enum SortOrder
{
    Asc,
    Desc,
}
