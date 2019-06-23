using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class IntExtension
    {
        /// <summary>
        /// 如果为0，则抛出异常 
        /// </summary>
        /// <param name="key"></param>
        public static void CheckZero(this int key, string name, string message = "参数不能为空")
        {
            if (key == 0)
            {
                throw new ArgumentNullException(name, message);
            }
        }
    }
}
