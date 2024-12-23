using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Allin.Common.Utilities
{
    //I got this from https://stackoverflow.com/a/58190566/1730846
    public class NameOf<TSource, TProperty>
    {
        #region Public Methods

        public static string Full(Expression<Func<TSource, TProperty?>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                var unaryExpression = expression.Body as UnaryExpression;
                if (unaryExpression != null && unaryExpression.NodeType == ExpressionType.Convert)
                    memberExpression = unaryExpression.Operand as MemberExpression;
            }

            var result = memberExpression?.ToString() ?? "";
            result = result.Substring(result.IndexOf('.') + 1);

            return result;
        }

        public static string Full(string sourceFieldName, Expression<Func<TSource, TProperty?>> expression)
        {
            var result = Full(expression);
            result = string.IsNullOrEmpty(sourceFieldName) ? result : sourceFieldName + "." + result;
            return result;
        }

        #endregion
    }

    public class NameOf<TSource> : NameOf<TSource, object>
    {
    }
}
