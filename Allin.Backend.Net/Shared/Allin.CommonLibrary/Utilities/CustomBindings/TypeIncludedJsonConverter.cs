using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Allin.Common.Utilities
{
    public class TypeIncludedJsonConverter<T> : JsonConverter<T>
    {

        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<T>(ref reader);
        }

        public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options)
        {
            WriteWithIncludingType(writer, value);
        }


        public static void WriteWithIncludingType(Utf8JsonWriter writer, T? value)
        {
            if (value == null)
            {
                writer.WriteStringValue((string?)null);
                return;
            }
            writer.WriteStartObject();
            writer.WriteString("typeToReviveInInterceptor", value.GetType().Name);
            writer.WritePropertyName("value");
            JsonSerializer.Serialize<T>(writer, value);
            writer.WriteEndObject();
        }
    }

}