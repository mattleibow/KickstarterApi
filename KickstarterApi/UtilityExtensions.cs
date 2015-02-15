namespace KickstarterApi
{
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    internal static class UtilityExtensions
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static Task<T> ParsedAsJson<T>(this string json)
        {
            var settings = new JsonSerializerSettings
            {
                Converters = new JsonConverter[] { new KickstarterDateTimeConverter() }
            };

            return Task.Run(() => JsonConvert.DeserializeObject<T>(json, settings));
        }
    }
}