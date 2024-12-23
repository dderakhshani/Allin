using System;
using System.Linq;
using System.Linq.Expressions;

namespace Allin.Common.Data
{
    public static class ExpressionUtils
    {
        public const string Equal = "e";
        public const string NotEqual = "ne";
        public const string StartsWith = "sw";
        public const string EndsWith = "ew";
        public const string Contains = "contains";
        public const string In = "in";
        public const string Between = "between";
        public const string LessThan = "lt";
        public const string LessThanOrEqual = "lte";
        public const string GreaterThan = "gt";
        public const string GreaterThanOrEqual = "gte";
        public const string Or = "or";
        public const string And = "and";
        public const string Not = "not";
        public const string InListAll = "inListAll";
        public const string InListAny = "inListAny";
        public const string IsNull = "n";
        public const string IsNotNull = "nn";

        public static Expression<Func<T, bool>> BuildPredicate<T>(string propertyName, string comparison, object value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            //if (propertyName.Contains('+'))
            //{
            //    Expression Expression = null;
            //    foreach (var s in propertyName.Split('+'))
            //    {
            //        Expression = s.Split('.').Aggregate((Expression)parameter, Expression.Property);
            //        Expression.Add(new BinaryExpression(){})
            //    }

            //}
            var left = propertyName.Split('.').Aggregate((Expression)parameter, Expression.Property);
            var body = CompileComparison(left, comparison, value);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        public static Expression<Func<T, bool>> BuildPredicate<T>(Expression<Func<T, bool>> leftExpression, string propertyName, string comparison, object jsonValue, string operand)
        {
            var value = jsonValue.ToString();
            if (jsonValue is System.Text.Json.JsonElement)
                value = ((System.Text.Json.JsonElement)jsonValue).ToString();

            var parameter = leftExpression.Parameters[0];
            var left = propertyName.Split('.').Aggregate((Expression)leftExpression.Parameters[0], Expression.Property);
            var body = CompileComparison(left, comparison, value);
            var right = Expression.Lambda<Func<T, bool>>(body, parameter);

            var binaryExpression = Expression.MakeBinary(GetExpressionType(operand), leftExpression.Body, right.Body);

            return Expression.Lambda<Func<T, bool>>(binaryExpression, parameter);
        }

        public static Expression<Func<T, bool>> BuildPredicate<T>(this Expression<Func<T, bool>> leftExpression, Expression<Func<T, bool>> rightExpression, string operand)
        {
            var parameter = leftExpression.Parameters[0];
            var right = Expression.Lambda<Func<T, bool>>(rightExpression.Body, parameter);

            var binaryExpression = Expression.MakeBinary(GetExpressionType(operand), leftExpression.Body, right.Body);

            return Expression.Lambda<Func<T, bool>>(binaryExpression, parameter);
        }

        public static Expression<Func<T, bool>> BuildPredicate<T>(Expression<Func<T, bool>> expression, string operand)
        {
            var parameter = expression.Parameters[0];
            UnaryExpression? unaryExpression = null;

            switch (operand)
            {
                case Not:
                    unaryExpression = Expression.Not(expression.Body);
                    break;
            }

            if (unaryExpression == null)
            {
                return expression;
            }
            return Expression.Lambda<Func<T, bool>>(unaryExpression, parameter);
        }



        private static ExpressionType GetExpressionType(string operand)
        {
            switch (operand)
            {
                case Or:
                    return ExpressionType.Or;
                case And:
                    return ExpressionType.And;
                default:
                    return ExpressionType.Or;
            }
        }


        private static Expression CompileComparison(Expression left, string comparison, object? value)
        {
            switch (comparison)
            {
                case Equal:
                    return ApplyComparison(ExpressionType.Equal, left, value);
                case NotEqual:
                    return ApplyComparison(ExpressionType.NotEqual, left, value);
                case GreaterThan:
                    return ApplyComparison(ExpressionType.GreaterThan, left, value);
                case GreaterThanOrEqual:
                    return ApplyComparison(ExpressionType.GreaterThanOrEqual, left, value);
                case LessThan:
                    return ApplyComparison(ExpressionType.LessThan, left, value);
                case LessThanOrEqual:
                    return ApplyComparison(ExpressionType.LessThanOrEqual, left, value);
                case Contains:
                case StartsWith:
                case EndsWith:
                    return Expression.Call(left, comparison, Type.EmptyTypes, Expression.Constant(value, typeof(string)));
                default:
                    throw new NotSupportedException($"Invalid comparison operator '{comparison}'.");
            }
        }

        private static Expression ToString(Expression source)
        {
            return source.Type == typeof(string) ? source : Expression.Call(source, "ToString", Type.EmptyTypes);
        }

        private static Expression ApplyComparison(ExpressionType type, Expression left, object? value)
        {
            object? typedValue = value;
            if (left.Type != typeof(string))
            {
                if (string.IsNullOrEmpty(value!.ToString()))
                {
                    typedValue = null;
                    if (Nullable.GetUnderlyingType(left.Type) == null)
                        left = Expression.Convert(left, typeof(Nullable<>).MakeGenericType(left.Type));
                }
                else
                {
                    var valueType = Nullable.GetUnderlyingType(left.Type) ?? left.Type;
                    typedValue = valueType.IsEnum ? Enum.Parse(valueType, value.ToString()!) :
                        valueType == typeof(Guid) ? Guid.Parse(value.ToString()!) :
                        Convert.ChangeType(value, valueType);
                }
            }
            var right = Expression.Constant(typedValue, left.Type);
            return Expression.MakeBinary(type, left, right);
        }


        /// <summary>
        /// SearchableItems.Any(item=> fieldName.Contains(item))
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="searchableItems"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GenerateSearchExpressionAnyAndContains<T>(string[] searchableItems, string fieldName, Expression<Func<T, bool>>? andCondition = null, Expression<Func<T, bool>>? orCondition = null)
        {
            var parameter = Expression.Parameter(typeof(T), typeof(T).Name.ToLower());
            var property = Expression.Property(parameter, fieldName);

            Expression finalExpression = null;

            foreach (var searchableItem in searchableItems)
            {
                var constant = Expression.Constant(searchableItem);
                var containMethodInfo = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;
                var toLowerMethodInfo = typeof(string).GetMethod("ToLower", new Type[] { })!;
                var toLowerMethodExp = Expression.Call(property, toLowerMethodInfo);
                var lastExp = Expression.Call(toLowerMethodExp, containMethodInfo, constant);


                if (finalExpression == null)
                {
                    finalExpression = lastExp;
                }
                else
                {
                    finalExpression = Expression.OrElse(finalExpression, lastExp);
                }
            }

            if (finalExpression == null)
            {
                finalExpression = Expression.Constant(true);
            }
            if (andCondition != null)
            {
                finalExpression = Expression.AndAlso(Expression.Invoke(andCondition, parameter), finalExpression);
            }
            if (orCondition != null)
            {
                finalExpression = Expression.OrElse(finalExpression, Expression.Invoke(orCondition, parameter));
            }
            var lambda = Expression.Lambda<Func<T, bool>>(finalExpression, parameter);
            return lambda;
        }

    }
}