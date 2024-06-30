using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WilliamsAPI.Models;

namespace WilliamsAPI.Utils
{
    public static class DataSourceReader
    {
        private static readonly string dataSourcePath = $"{Assembly.GetExecutingAssembly().Location}/../DataSources";
        private static readonly JsonSerializerOptions options = new()
        {
            Converters =
            {
                new NullableConverterFactory(
                [
                    Encoding.UTF8.GetBytes("\\N"),
                ])
            }
        };

        public async static Task<T> ReadJsonAsync<T>(string fileName, T defaultVal = default!)
        {
            using StreamReader r = new($"{dataSourcePath}/{fileName}.json");
            var json = await r.ReadToEndAsync();
            return JsonSerializer.Deserialize<T>(json, options) ?? defaultVal;
        }
    }
}
