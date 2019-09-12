using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Demo.Core.Utils
{
    /// <summary>
    /// json相关帮助类
    /// </summary>
    public class JsonManager
    {
        /// <summary>
        /// 将传入对象序列化成json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
        }

        public static string SerializeByConverter(object obj, params JsonConverter[] converters)
        {
            return JsonConvert.SerializeObject(obj, converters);
        }

        /// <summary>
        /// 将传入json字符串反序列化成指定对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        public static T DeserializeByConverter<T>(string input, params JsonConverter[] converter)
        {
            return JsonConvert.DeserializeObject<T>(input, converter);
        }

        public static T DeserializeBySetting<T>(string input, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(input, settings);
        }
    }
}
