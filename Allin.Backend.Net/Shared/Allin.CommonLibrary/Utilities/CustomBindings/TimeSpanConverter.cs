using System;
using System.Text.Json;
using System.Text.Json.Serialization;
public class TimeSpanConverter : JsonConverter<TimeSpan>
{
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return TimeSpan.Parse(reader.GetString() ?? "");
    }

    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
    {
        WriteWithIncludingType(writer, value);
    }


    public static void WriteWithIncludingType(Utf8JsonWriter writer, TimeSpan value)
    {

        writer.WriteStartObject();
        writer.WriteString("typeToReviveInInterceptor", value.GetType().Name);
        writer.WritePropertyName("value");
        JsonSerializer.Serialize<TimeSpan>(writer, value);
        writer.WriteEndObject();
    }
}

public class NullableTimeSpanConverter : JsonConverter<TimeSpan?>
{
    public override TimeSpan? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var timespan = reader.GetString();
        if (timespan != null)
            return TimeSpan.Parse(timespan);
        else
            return null;
    }

    public override void Write(Utf8JsonWriter writer, TimeSpan? value, JsonSerializerOptions options)
    {
        WriteWithIncludingType(writer, value);
    }


    public static void WriteWithIncludingType(Utf8JsonWriter writer, TimeSpan? value)
    {
        if (value == null)
        {
            writer.WriteStringValue((string?)null);
            return;
        }
        writer.WriteStartObject();
        writer.WriteString("typeToReviveInInterceptor", value.GetType().Name);
        writer.WritePropertyName("value");
        JsonSerializer.Serialize<TimeSpan?>(writer, value);
        writer.WriteEndObject();
    }
}