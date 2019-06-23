namespace System
{
    public static class StringExtension
    {
        #region Empty

        /// <summary>
        /// 如果为""，则抛出异常（ArgumentNullException）
        /// </summary>
        public static void CheckEmpty(this string key, string name, string message = "参数不能为空")
        {
            if (key == null || string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(name, message);
            }
        }

        /// <summary>
        /// 互斥为空，则抛出异常（ArgumentNullException）
        /// </summary>
        public static void MutualCheckEmpty(this string key, string value, string name, string message = "参数不能为空")
        {
            if ((key == null || string.IsNullOrEmpty(key)) && (value == null || string.IsNullOrEmpty(value)))
            {
                throw new ArgumentNullException(name, message);
            }
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        public static bool IsEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// 如果为空返回新值
        /// </summary>
        public static void IfEmptyValue(this string s, string value, out string output)
        {
            output = s;
            if (!string.IsNullOrEmpty(value))
            {
                output = value;
            }
        }

        #endregion Empty

        /// <summary>
        /// 截取字符串，包含判断长度及为空部分
        /// </summary>
        /// <returns></returns>
        public static string SubStrings(this string s, int startIndex, int length = 0)
        {
            if (length == 0) length = s.Length - startIndex;
            return string.IsNullOrEmpty(s) ? "" : s.Substring(startIndex, length);
        }

        #region Convert

        /// <summary>
        /// int.TryParse(s, out i)
        /// </summary>
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
        public static decimal ToDecimal(this string s, decimal defaultValue = 0)
        {
            if (string.IsNullOrEmpty(s)) return defaultValue;
            var d = defaultValue;
            return decimal.TryParse(s, out d) ? d : defaultValue;
        }

        /// <summary>
        /// double.TryParse(s, out d)
        /// </summary>
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
        public static DateTime ToDateTime(this string s)
        {
            if (string.IsNullOrEmpty(s)) return DateTime.Now;
            var dt = DateTime.Now;
            DateTime.TryParse(s, out dt);
            return dt;
        }

        #endregion Convert
    }
}