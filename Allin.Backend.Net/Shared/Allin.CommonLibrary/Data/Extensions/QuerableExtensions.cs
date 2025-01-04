namespace Allin.Common.Data
{
    //public static class QueryableExtensions
    //{
    //    public static async Task<int> ExecuteUpdateFromModelAsync<TEntity, TModel>(
    //    this IQueryable<TEntity> query,
    //    TModel model) where TModel : class
    //    {

    //        // Apply ExecuteUpdate with the constructed setters
    //        if (model == null)
    //            throw new ArgumentNullException(nameof(model));

    //        var entityType = typeof(TEntity);
    //        var properties = typeof(TModel).GetProperties(BindingFlags.Public | BindingFlags.Instance)
    //                                  .Where(p => p.CanRead)
    //                                  .ToList();

    //        // The parameter for the lambda (SetPropertyCalls<TEntity> setProperty)
    //        var parameter = Expression.Parameter(typeof(SetPropertyCalls<TEntity>), "setProperty");

    //        Expression body = parameter;

    //        foreach (var property in properties)
    //        {
    //            var value = property.GetValue(model);
    //            if (value == null) continue;

    //            // Build the SetProperty expression
    //            var propertyName = property.Name;

    //            var setPropertyCall = Expression.Call(
    //                typeof(SetPropertyCalls<TEntity>),
    //                nameof(SetPropertyCalls<TEntity>.SetProperty),
    //                new Type[] { typeof(object) },
    //                body,
    //                Expression.Lambda(
    //                    Expression.Call(
    //                        typeof(EF),
    //                        nameof(EF.Property),
    //                        new Type[] { typeof(object) },
    //                        Expression.Parameter(typeof(TEntity), "entity"),
    //                        Expression.Constant(propertyName)
    //                    ),
    //                    Expression.Parameter(typeof(TEntity), "entity")
    //                ),
    //                Expression.Lambda(
    //                    Expression.Constant(value),
    //                    Expression.Parameter(typeof(TEntity), "entity")
    //                )
    //            );

    //            body = setPropertyCall;
    //        }

    //        // Compile the final lambda: setProperty => setProperty.SetProperty(...)
    //        var lambda = Expression.Lambda<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>>(body, parameter);

    //        return await query.ExecuteUpdateAsync(lambda);

    //    }
    //}
}
