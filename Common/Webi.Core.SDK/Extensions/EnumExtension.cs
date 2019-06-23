using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;

namespace System
{
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举类型的描述
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum input)
        {
            var type = input.GetType();
            //获取指定成员
            var field = type.GetField(input.ToString());
            //查找指定的特性，不继承查找
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            //无特性设置，直接返回
            if (attributes == null || attributes.Length == 0)
            {
                return input.ToString();
            }
            //读取第一个
            return (attributes.Single() as DescriptionAttribute).Description;
        }
    }
}
