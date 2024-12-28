using System.Text.Json.Serialization;
using Allin.Common.Utilities.CustomBindings;

namespace Allin.Common.Data.QueryHelpers.QueryParsing
{
    public class Condition
    {
        [JsonConverter(typeof(PropertyJsonConverter))]
        public string PropertyName { get; set; } = default!;
        public string Comparison { get; set; } = default!;

        public object[] Values { get; set; } = new object[] { };

    }
}
