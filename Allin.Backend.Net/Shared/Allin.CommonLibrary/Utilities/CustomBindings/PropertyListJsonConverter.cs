using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Allin.Common.Utilities
{
    public class PropertyListJsonConverter : JsonConverter<List<string?>>
    {
        public override List<string?> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }

            var value = new List<string?>();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    return value;
                }

                if (reader.TokenType != JsonTokenType.String)
                {
                    throw new JsonException();
                }

                value.Add(reader.GetString()?.ToTitleCase());
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, List<string?> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();

            foreach (string? item in value)
            {
                writer.WriteStringValue(item == null ? null : item.ToCamelCase());
            }

            writer.WriteEndArray();
        }
    }

}