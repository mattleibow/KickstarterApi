namespace KickstarterApi
{
    using System;
    using System.Collections.Generic;
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

        public static T GetParameterValue<T>(this Uri uri, string parameter, T defaultValue)
        {
            // get the query string
            string s = uri.Query;
            if (s.Length > 0 && s[0] == '?')
            {
                s = s.Substring(1);
            }

            // search the parameters
            foreach (var pair in s.Split('&'))
            {
                var values = pair.Split('=');
                if (values.Length == 2 && string.Compare(values[0], parameter, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    defaultValue = (T)Convert.ChangeType(values[1], typeof(T));
                    break;
                }
            }

            // return the value, or the default
            return defaultValue;
        }
    }
}