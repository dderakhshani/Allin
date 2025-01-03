using Microsoft.EntityFrameworkCore;
using ServiceStack;
using System.Linq.Expressions;
using System.Reflection;

namespace Allin.Common.Data.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<int> ExecuteUpdateFromModelAsync<T>(
        this IQueryable<T> query,
        T model) where T : class
        {
            // Get all the properties of the model
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                      .Where(p => p.CanRead)
                                      .ToList();

            // Construct the update setters dynamically
            var updateExpression = new List<(Expression<Func<T, object>> property, Expression value)>();
            foreach (var property in properties)
            {
                var parameter = Expression.Parameter(typeof(T), "e");

                // Property selector (e => e.Property)
                var propertyExpression = Expression.Lambda<Func<T, object>>(
                    Expression.Convert(
                        Expression.Property(parameter, property.Name),
                        typeof(object)
                    ),
                    parameter
                );

                // Value expression (model.Property)
                var valueExpression = Expression.Constant(property.GetValue(model));

                updateExpression.Add((propertyExpression, valueExpression));
            }

            // Apply ExecuteUpdate with the constructed setters
            return await query.ExecuteUpdateAsync(setters =>
            {
                foreach (var (property, value) in updateExpression)
                {
                    setters.SetProperty(property, value);
                }
            });
        }
    }
}
