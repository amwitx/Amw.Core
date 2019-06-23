using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class StringExtension
    {
        /// <summary>
        /// 如果为""，则抛出异常 
        /// </summary>
        /// <param name="key"></param>
        public static void CheckEmpty(this string key, string name, string message = "参数不能为空")
        {
            if (key == null || string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(name, message);
            }
        }
        /// <summary>
        /// 互斥为空，则抛出异常 
        /// </summary>
        /// <param name="key"></param>
        public static void MutualCheckEmpty(this string key, string value, string name, string message = "参数不能为空")
        {
            if ((key == null || string.IsNullOrEmpty(key)) && (value == null || string.IsNullOrEmpty(value)))
            {
                throw new ArgumentNullException(name, message);
            }
        }
        /// <summary>
        /// int.TryParse(s, out i)
        /// </summary>
        /// <param name="s"></param>
        /// <returns>0</returns>
        public static int ToInt(this string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            var i = 0;
            int.TryParse(s, out i);
            return i;
        }
        /// <summary>
        /// decimal.TryParse(s, out d)
        /// </summary>
        /// <param name="s"></param>
        /// <returns>0</returns>
        public static decimal ToDecimal(this string s, decimal defaultValue = 0)
        {
            if (string.IsNullOrEmpty(s)) return defaultValue;
            var d = defaultValue;
            return decimal.TryParse(s, out d) ? d : defaultValue;
        }

        /// <summary>
        /// double.TryParse(s, out d)
        /// </summary>
        /// <param name="s"></param>
        /// <returns>0d</returns>
        public static double ToDouble(this string s, double defaultValue = 0d)
        {
            if (string.IsNullOrEmpty(s)) return defaultValue;
            var d = defaultValue;
            return double.TryParse(s, out d) ? d : defaultValue;
        }

        /// <summary>
        /// float.TryParse(s, out d)
        /// </summary>
        /// <param name="s"></param>
        /// <returns>0f</returns>
        public static float ToFloat(this string s)
        {
            if (string.IsNullOrEmpty(s)) return 0f;
            var d = 0f;
            float.TryParse(s, out d);
            return d;
        }

        /// <summary>
        /// DateTime.TryParse(s, out dt)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string s)
        {
            if (string.IsNullOrEmpty(s)) return DateTime.Now;
            var dt = DateTime.Now;
            DateTime.TryParse(s, out dt);
            return dt;
        }
    }
}
