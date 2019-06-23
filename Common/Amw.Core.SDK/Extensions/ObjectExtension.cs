using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class ObjectExtension
    {
        /// <summary>
        /// 如果为Null，则抛出异常 
        /// </summary>
        /// <param name="key"></param>
        public static void CheckNull(this object key, string name, string message = "参数不能为空")
        {
            if (key == null || string.IsNullOrEmpty(key.ToString()))
            {
                throw new ArgumentNullException(name, message);
            }
        }
    }
}
