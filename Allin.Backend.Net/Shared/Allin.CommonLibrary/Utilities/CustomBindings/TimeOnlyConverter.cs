using System;
using System.Text.Json;
using System.Text.Json.Serialization;
public class TimeOnlyConverter : JsonConverter<TimeOnly>
{
    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return TimeOnly.Parse(reader.GetString() ?? "");
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
    {
        WriteWithIncludingType(writer, value);
    }


    public static void WriteWithIncludingType(Utf8JsonWriter writer, TimeOnly value)
    {

        writer.WriteStartObject();
        writer.WriteString("typeToReviveInInterceptor", value.GetType().Name);
        writer.WritePropertyName("value");
        JsonSerializer.Serialize<TimeOnly>(writer, value);
        writer.WriteEndObject();
    }
}

public class NullableTimeOnlyConverter : JsonConverter<TimeOnly?>
{
    public override TimeOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var time = reader.GetString();
        if (time != null)
            return TimeOnly.Parse(time);
        else
            return null;
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly? value, JsonSerializerOptions options)
    {
        WriteWithIncludingType(writer, value);
    }


    public static void WriteWithIncludingType(Utf8JsonWriter writer, TimeOnly? value)
    {
        if (value == null)
        {
            writer.WriteStringValue((string?)null);
            return;
        }
        writer.WriteStartObject();
        writer.WriteString("typeToReviveInInterceptor", value.GetType().Name);
        writer.WritePropertyName("value");
        JsonSerializer.Serialize<TimeOnly?>(writer, value);
        writer.WriteEndObject();
    }
}