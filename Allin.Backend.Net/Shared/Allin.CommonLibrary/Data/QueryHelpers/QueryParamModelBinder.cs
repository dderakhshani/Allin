using Allin.Common.Data.QueryHelpers.QueryParsing;
using Allin.Common.Utilities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Allin.Common.Data.QueryHelpers
{
    public class QueryParamModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var model = new QueryParamModel
            {
                Group = bindingContext.ValueProvider.GetValue("group").ToString().ToTitleCase(),
                OrderByProperties = bindingContext.ValueProvider.GetValue("orderByProperties").ToString().ToTitleCase(),
                ColumnsNamesToShow = bindingContext.ValueProvider.GetValue("columnsNamesToShow").ToString().ComplexModelQueryStringRemoveExtraChars()!,
                SearchTerm = bindingContext.ValueProvider.GetValue("searchTerm").ToString().ToLower(),
            };
            var pagingProperties = bindingContext.ValueProvider.GetValue("pagingProperties").ToString().ComplexModelQueryStringRemoveExtraChars()!.Split(',');

            if (pagingProperties != null && pagingProperties.Length > 0)
            {
                model.PagingProperties = new QueryParamModel.Paging();
                AdjustComplexModel(pagingProperties, model.PagingProperties, typeof(QueryParamModel.Paging));
            }
            var conditionProperties = bindingContext.ValueProvider.GetValue("conditions").ToString().ComplexListModelQueryStringRemoveExtraChars()!.Split("@");

            if (conditionProperties != null && conditionProperties.Length > 0)
            {
                model.Conditions = new List<Condition>();
                foreach (var conditionProperty in conditionProperties)
                {
                    if (string.IsNullOrEmpty(conditionProperty)) continue;
                    var adjustedCondition = new Condition();
                    AdjustComplexModel(conditionProperty.ComplexModelQueryStringRemoveExtraChars()!.Split(','), adjustedCondition, typeof(Condition));
                    adjustedCondition.Comparison = adjustedCondition.Comparison.ToLower();
                    model.Conditions.Add(adjustedCondition);
                }
            }
            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
        private void AdjustComplexModel(string[] properties, object setValueFor, Type complexModelType)
        {
            if (properties != null && properties.Length > 0)
            {
                foreach (var property in properties)
                {
                    int indexOfColon = property.IndexOf(':');
                    if (indexOfColon > 0)
                    {
                        string propertyName = property.Substring(0, indexOfColon);
                        string propertyValue = property.Substring(indexOfColon + 1);

                        PropertyInfo propertyInfo = complexModelType.GetProperty(propertyName)!;
                        if (propertyInfo != null && propertyInfo.CanWrite)
                        {
                            if (propertyInfo.PropertyType.Name == "Object[]")
                                propertyInfo.SetValue(setValueFor, new object[] { propertyValue.Trim() });
                            else
                                propertyInfo.SetValue(setValueFor, Convert.ChangeType(propertyValue.Trim(), propertyInfo.PropertyType));
                        }
                    }
                }
            }
        }
    }
}
