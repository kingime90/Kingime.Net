using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingime.Net.Core.Util
{
    /// <summary>
    /// 
    /// </summary>
    public class JsonUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string Serialize(object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string Serialize(object o, Formatting format)
        {
            return JsonConvert.SerializeObject(o, format);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static dynamic Deserialize(string value)
        {
            return JObject.Parse(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(string value, Type type)
        {
            return JsonConvert.DeserializeObject(value, type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// 反序列化的JSON的匿名类型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="anonymousTypeObject"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string value, T anonymousTypeObject)
        {
            try
            {
                return JsonConvert.DeserializeAnonymousType(value, anonymousTypeObject);
            }
            catch
            {
                return anonymousTypeObject;
            }
        }
    }
}
