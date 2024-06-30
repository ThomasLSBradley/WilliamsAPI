using System.Text.Json.Serialization;
using System.Text.Json;
using System.Reflection;

namespace WilliamsAPI.Utils
{
    // Taken from https://stackoverflow.com/questions/73614053/system-text-json-custom-null-values

    /// <summary>
    /// Converter that can parse nullable types. int? decimal? etc
    /// </summary>
    public class NullableConverterFactory : JsonConverterFactory
    {
        private static readonly byte[] EMPTY = [];

        private static readonly HashSet<byte[]> NULL_VALUES = [EMPTY];

        /// <summary>
        /// empty constructor.
        /// </summary>
        public NullableConverterFactory()
        {
        }

        /// <summary>
        /// Supply additional accepted null values as byte[] here.
        /// </summary>
        /// <param name="additionalNullValues"></param>
        public NullableConverterFactory(HashSet<byte[]> additionalNullValues)
        {
            foreach (byte[] nullValue in additionalNullValues)
            {
                NULL_VALUES.Add(nullValue);
            }
        }

        /// <summary>
        /// Returns true if this converter can convert the value.
        /// </summary>
        /// <param name="typeToConvert"></param>
        /// <returns></returns>
        public override bool CanConvert(Type typeToConvert) => Nullable.GetUnderlyingType(typeToConvert) != null;

        public override JsonConverter CreateConverter(Type type, JsonSerializerOptions options) =>
            (JsonConverter)Activator.CreateInstance(
                typeof(NullableConverter<>).MakeGenericType(
                [Nullable.GetUnderlyingType(type)!]),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: [options, NULL_VALUES],
                culture: null)!;

        class NullableConverter<T> : JsonConverter<T?> where T : struct
        {
            private readonly HashSet<byte[]> _nullValues;

            // DO NOT CACHE the return of (JsonConverter<T>)options.GetConverter(typeof(T)) as DoubleConverter.Read() and DoubleConverter.Write()
            // DO NOT WORK for nondefault values of JsonSerializerOptions.NumberHandling which was introduced in .NET 5
            public NullableConverter(JsonSerializerOptions options, HashSet<byte[]> nullValues)
            {
                _nullValues = nullValues;
            }

            public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.String)
                {
                    return JsonSerializer.Deserialize<T>(ref reader, options);
                }

                foreach (byte[] nullValue in _nullValues)
                {
                    if (reader.ValueTextEquals(nullValue))
                    {
                        return null;
                    }
                }

                return JsonSerializer.Deserialize<T>(ref reader, options);
            }

            public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options) =>
                JsonSerializer.Serialize(writer, value!.Value, options);
        }
    }
}

