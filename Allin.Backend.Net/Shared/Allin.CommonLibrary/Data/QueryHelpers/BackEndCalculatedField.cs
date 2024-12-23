using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json.Serialization;
using Allin.Common.Utilities;

namespace Allin.Common.Data.QueryHelpers
{

    public class BackEndCalculatedField<TClass, TProperty>
    {
        /// <summary>
        /// The calculated value being sent to front-end to show the data.
        /// </summary>
        public TProperty? Value { get; set; }

        public string? GroupingField { get; private set; } = null;

        /// <summary>
        /// The expression that gives a property of <typeparamref name="TClass"/> that will be used for grouping of records.
        /// </summary>
        [JsonIgnore]
        public Expression<Func<TClass, object?>> GroupingFieldExpression
        {
            set
            {
                if (value == null)
                {
                    GroupingField = null;
                }
                else
                {
                    GroupingField = NameOf<TClass>.Full(value);
                }
            }
        }

        public IEnumerable<string>? OrderingField { get; private set; }


        /// <summary>
        /// The expression that gives an array of properties of <typeparamref name="TClass"/> that will be used for ordering of records.
        /// The order of array items are important.
        /// </summary>
        [JsonIgnore]
        public Expression<Func<TClass, object?>>[] OrderingFieldExpression
        {
            set
            {
                if (value == null)
                {
                    OrderingField = null;
                }
                else
                {
                    OrderingField = value.Select(v => NameOf<TClass>.Full(v));
                }
            }
        }


        public string? FilteringField { get; private set; } = null;

        /// <summary>
        /// The expression that gives a property of <typeparamref name="TClass"/> that will be used for filtering of records.
        /// </summary>
        [JsonIgnore]
        public Expression<Func<TClass, object?>> FilteringFieldExpression
        {
            set
            {
                if (value == null)
                {
                    FilteringField = null;
                }
                else
                {
                    FilteringField = NameOf<TClass>.Full(value);
                }
            }
        }

    }
}