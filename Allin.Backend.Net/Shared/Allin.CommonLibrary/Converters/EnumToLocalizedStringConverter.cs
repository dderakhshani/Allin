using Allin.Common.Utilities;
using Allin.CommonLibrary.Localizations;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Allin.Common.Converters
{
    public class EnumToLocalizedStringConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert) => typeToConvert.IsEnum;

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
            (JsonConverter)Activator.CreateInstance(typeof(CustomConverter<>).MakeGenericType(typeToConvert))!;

        class CustomConverter<T> : JsonConverter<T> where T : struct, Enum
        {
            private ILocalizator _localizator;
            public CustomConverter()
            {
                _localizator = GlobalContainer.ServiceProvider.GetRequiredService<ILocalizator>();
            }

            public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => default(T);

            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            {
                var enumType = value.GetType();
                var field = enumType.GetField(value.ToString());

                var title = _localizator[$"{enumType.Name}.{field.Name}"];
                writer.WriteStringValue(title);
            }

        }
    }
}
