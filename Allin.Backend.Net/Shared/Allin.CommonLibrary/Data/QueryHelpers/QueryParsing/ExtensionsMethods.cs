using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Expression = System.Linq.Expressions.Expression;

namespace Allin.Common.Data.QueryHelpers.QueryParsing
{
    public static class QueryParserExtensionsMethods
    {

        public static IQueryable<TEntity> WhereQueryMaker<TEntity>(this IQueryable<TEntity> query, List<Condition>? conditions)
        {
            if (conditions is null)
            {
                return query;
            }

            foreach (var condition in conditions)
            {
                var value0 = condition.Values[0] == null ? "NULL" : condition.Values[0].ToString();
                if (condition.Comparison == ExpressionUtils.Between)
                {
                    query = query.Where($"{condition.PropertyName} >= @0 && {condition.PropertyName} <= @1",
                        condition.Values);
                }

                else if (condition.Comparison == ExpressionUtils.StartsWith)
                {
                    //Sample: (e:TEntity) = >  e.[condition.PropertyName].StartWith(value)
                    var e = Expression.Parameter(typeof(TEntity), "e");
                    var pi = typeof(TEntity).GetProperty(condition.PropertyName);
                    if (pi == null)
                    {
                        throw new Exception($"There is no '{condition.PropertyName}' in the type of typeof(TEntity)");
                    }
                    var m = Expression.MakeMemberAccess(e, pi);
                    var valueExpr = Expression.Constant(value0, typeof(string));
                    var mi = typeof(string).GetMethod(ExpressionUtils.StartsWith, new Type[] { typeof(string) })!;
                    Expression call = Expression.Call(m, mi, valueExpr);

                    var lambda = Expression.Lambda<Func<TEntity, bool>>(call, e);
                    query = query.Where(lambda);
                }

                else if (condition.Comparison == ExpressionUtils.EndsWith)
                {
                    // Sample: (e: TEntity) = > e.[condition.PropertyName].EndsWith(value)

                    var e = Expression.Parameter(typeof(TEntity), "e");
                    var pi = typeof(TEntity).GetProperty(condition.PropertyName);
                    if (pi == null)
                    {
                        throw new Exception($"There is no '{condition.PropertyName}' in the type of typeof(TEntity)");
                    }
                    var m = Expression.MakeMemberAccess(e, pi);


                    var valueExpr = Expression.Constant(value0, typeof(string));
                    var mi = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) })!;
                    Expression call = Expression.Call(m, mi, valueExpr);

                    var lambda = Expression.Lambda<Func<TEntity, bool>>(call, e);
                    query = query.Where(lambda);
                }
                else if (condition.Comparison == ExpressionUtils.Contains)
                {
                    Expression<Func<TEntity, bool>> expression = entity => false;

                    for (var i = 0; i < condition.Values.Length; i++)
                    {
                        try
                        {
                            var value = condition.Values[i].ToString();
                            expression = ExpressionUtils.BuildPredicate(expression, condition.PropertyName, ExpressionUtils.Contains, value, ExpressionUtils.Or);

                        }
                        catch
                        {
                            // ignored
                        }
                    }

                    query = query.Where(expression);

                }
                else if (condition.Comparison == ExpressionUtils.InListAll || condition.Comparison == ExpressionUtils.InListAny)
                {
                    string where = "x => ";
                    var length = condition.Values.Length;
                    var opr = "and";
                    if (condition.Comparison == ExpressionUtils.InListAny)
                        opr = "or";
                    for (var i = 0; i < condition.Values.Length; i++)
                    {

                        var value = condition.Values[i].ToString();
                        if (condition.Values[i] is System.Text.Json.JsonElement)
                            value = ((System.Text.Json.JsonElement)condition.Values[i]).ToString();
                        try
                        {
                            where += $"x.{condition.PropertyName}.Contains({value})" + (i < length - 1 ? $" {opr} " : "");
                        }
                        catch
                        {
                            // ignored
                        }
                    }

                    query = query.Where(where);
                }
                else if (condition.Comparison == ExpressionUtils.IsNull || condition.Comparison == ExpressionUtils.IsNotNull)
                {
                    var comparisonTerm = condition.Comparison == ExpressionUtils.IsNull ? "== null" : "!= null";
                    query = query.Where($"{condition.PropertyName} {comparisonTerm}");
                }
                else
                {
                    Type? propertyType = GetPropertyType(typeof(TEntity), condition.PropertyName);
                    if (propertyType == typeof(DateTime?) || propertyType == typeof(DateTime))
                    {

                        var d = DateTime.Parse(value0);
                        query = query.Where($"{condition.PropertyName} {GetOperator(condition.Comparison)}(@0)", d);
                    }
                    else if (propertyType == typeof(DateOnly?) || propertyType == typeof(DateOnly))
                    {

                        var d = DateOnly.FromDateTime(DateTime.Parse(value0));
                        query = query.Where($"{condition.PropertyName} {GetOperator(condition.Comparison)}(@0)", d);
                    }
                    else if (propertyType == typeof(TimeOnly?) || propertyType == typeof(TimeOnly))
                    {

                        var d = TimeOnly.FromDateTime(DateTime.Parse(value0));
                        query = query.Where($"{condition.PropertyName} {GetOperator(condition.Comparison)}(@0)", d);
                    }
                    else
                    {
                        var where = "";
                        //if(condition.Comparison == ExpressionUtils.Not)
                        for (var i = 0; i < condition.Values.Length; i++)
                        {
                            where += $"{condition.PropertyName} {GetOperator(condition.Comparison)}(@{i.ToString()}) or ";
                        }

                        where = where.Substring(0, where.Length - 4);
                        var values = condition.Values.Select(value => value?.ToString()).ToArray();
                        query = query.Where(where, values);
                    }

                }
            }

            return query;
        }

        public static Type? GetPropertyType(Type src, string propName)
        {
            if (src == null) throw new ArgumentException("Value cannot be null.", "src");
            if (propName == null) throw new ArgumentException("Value cannot be null.", "propName");

            if (propName.Contains("."))//complex type nested
            {
                var temp = propName.Split(new char[] { '.' }, 2);
                return GetPropertyType(GetPropertyType(src, temp[0])!, temp[1]);
            }
            else
            {
                // we may multiple properties with the same name in a type when there is inheritance. For example see 'MessageMethod' property in 'MessageOutView' class.
                var props = src.GetProperties().Where(prp => prp.Name == propName);
                System.Reflection.PropertyInfo? prop = null;
                var propsFound = props.Count();

                if (propsFound == 1)
                {
                    // if there is only one instance of a property with the specified name, then take it!
                    prop = props.First();
                }
                else if (propsFound > 1)
                {
                    // if there are multiple, get the one at the top level, i.e., ignore the inheritance
                    prop = src.GetProperty(propName, System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                }

                return prop?.PropertyType;
            }
        }

        private static string WhereQueryMaker(List<Condition>? conditions)
        {
            var where = "";
            if (conditions is null)
            {
                return "";
            }

            foreach (var condition in conditions)
            {
                if (!string.IsNullOrWhiteSpace(where))
                {
                    where = where + " and ";
                }
                if (condition.Comparison == ExpressionUtils.Between)
                {
                    where = where + $"{condition.PropertyName} >= {condition.Values[0]} && {condition.PropertyName} <= {condition.Values[1]}";
                }
                else
                {
                    where = where + $"{condition.PropertyName} {condition.Comparison} {condition.Values[0]}";
                }

            }

            if (!string.IsNullOrWhiteSpace(where))
            {
                where = " where " + where;
            }
            return where;
        }

        private static string GetOperator(string operatorStr)
        {
            switch (operatorStr.ToLower())
            {
                case ExpressionUtils.Equal:
                    return "==";
                case ExpressionUtils.NotEqual:
                    return "!=";
                case ExpressionUtils.GreaterThan:
                    return ">";
                case ExpressionUtils.GreaterThanOrEqual:
                    return ">=";
                case ExpressionUtils.LessThan:
                    return "<";
                case ExpressionUtils.LessThanOrEqual:
                    return "<=";
                default:
                    return "==";

            }
        }

        public static IQueryable<TEntity> Condition<TEntity>(this IQueryable<TEntity> query,
              Expression<Func<TEntity, bool>> conditionExpression)
        {
            if (conditionExpression is null) { return query; }
            return query.Where(conditionExpression);
        }

        public static IQueryable<TEntity> Paginate<TEntity>(this IQueryable<TEntity> query,
          QueryParamModel.Paging? pagingProperties)
        {
            if (pagingProperties == default || pagingProperties.PageSize == 0) return query;
            return query.Skip(pagingProperties.PageIndex * pagingProperties.PageSize).Take(pagingProperties.PageSize);
        }



        public static IQueryable<TEntity> OrderByMultipleColumns<TEntity>(this IQueryable<TEntity> query, string? propertyNames)
        {
            if (propertyNames?.Length > 0)
            {
                var orderedQuery = query.OrderBy(propertyNames);
                return orderedQuery;
            }
            else
                return query;//.OrderBy(x => 0);
        }

    }
}
