using System;
using System.Text.Json;
using System.Text.Json.Serialization;
public class DateOnlyConverter : JsonConverter<DateOnly>
{
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.FromDateTime(DateTime.Parse(reader.GetString()!));
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        WriteWithIncludingType(writer, value);
    }


    public static void WriteWithIncludingType(Utf8JsonWriter writer, DateOnly value)
    {

        writer.WriteStartObject();
        writer.WriteString("typeToReviveInInterceptor", value.GetType().Name);
        writer.WritePropertyName("value");
        JsonSerializer.Serialize<DateOnly>(writer, value);
        writer.WriteEndObject();
    }
}

public class NullableDateOnlyConverter : JsonConverter<DateOnly?>
{
    public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateOnly = reader.GetString();
        if (dateOnly != null)
        {
            return DateOnly.FromDateTime(DateTime.Parse(dateOnly));
        }
        else
            return null;
    }

    public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
    {
        WriteWithIncludingType(writer, value);
    }


    public static void WriteWithIncludingType(Utf8JsonWriter writer, DateOnly? value)
    {
        if (value == null)
        {
            writer.WriteStringValue((string?)null);
            return;
        }
        writer.WriteStartObject();
        writer.WriteString("typeToReviveInInterceptor", value.GetType().Name);
        writer.WritePropertyName("value");
        JsonSerializer.Serialize<DateOnly?>(writer, value);
        writer.WriteEndObject();
    }
}