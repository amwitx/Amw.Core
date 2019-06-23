using Newtonsoft.Json;

namespace Amw.Core.SDK.Components
{
    public class JsonHelper
    {
        internal JsonHelper()
        {
        }

        #region json

        /// <summary>
        /// Json转对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public T JsonToObject<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 对象转json，默认包含空字段
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="isContainsNullProperty">包含空字段</param>
        /// <returns></returns>
        public string ObjectToJson(object obj, bool isContainsNullProperty = true)
        {
            if (obj == null) { return ""; }
            if (isContainsNullProperty)
            {
                //包含
                return JsonConvert.SerializeObject(obj);
            }
            var jsonSetting = new JsonSerializerSettings();
            jsonSetting.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(obj, Formatting.Indented, jsonSetting);
        }

        #endregion json
    }
}