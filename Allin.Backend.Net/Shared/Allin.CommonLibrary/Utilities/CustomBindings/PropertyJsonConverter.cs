using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Allin.Common.Utilities
{
    public class PropertyJsonConverter : JsonConverter<string>
    {
        public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString()?.ToTitleCase();
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value == null ? null : value.ToCamelCase());
        }
    }

}