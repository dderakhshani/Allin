using System.Text.Json.Serialization;
using Allin.Common.Utilities;

namespace Allin.Common.Data
{
    public class Condition
    {
        [JsonConverter(typeof(PropertyJsonConverter))]
        public string PropertyName { get; set; } = default!;
        public string Comparison { get; set; } = default!;

        public object[] Values { get; set; } = new object[] { };

    }
}
