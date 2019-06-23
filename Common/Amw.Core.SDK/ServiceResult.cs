using Microsoft.AspNetCore.Http;
using System;
using System.Net;

namespace Amw.Core.SDK
{
    public class ServiceResult<T>
    {
        /// <summary>
        /// code=200表示成功，非200为异常
        /// </summary>
        public int code { get; set; } = StatusCodes.Status200OK;

        /// <summary>
        /// 返回数据
        /// </summary>
        public T data { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 解决方法
        /// </summary>
        public string solve { get; set; }

        /// <summary>
        /// 服务器时间戳
        /// </summary>
        public long timestamp { get { return DateTimeOffset.Now.ToUnixTimeMilliseconds(); } }

        public ServiceResult()
        {
        }

        public ServiceResult(int _code, T _data, string _msg, string _solve)
        {
            this.code = _code;
            this.data = _data;
            this.msg = _msg;
            this.solve = _solve;
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="_data"></param>
        /// <returns></returns>
        public static ServiceResult<T> Success(T _data, int code = StatusCodes.Status200OK)
        {
            return new ServiceResult<T>(code, _data, "", "");
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="_code"></param>
        /// <param name="_msg"></param>
        /// <returns></returns>
        public static ServiceResult<T> Failed(int _code, string _msg, string _solve = "", T _data = default(T))
        {
            return new ServiceResult<T>(_code, _data, _msg, _solve);
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="_msg"></param>
        /// <returns></returns>
        public static ServiceResult<T> Exception(string _msg)
        {
            return new ServiceResult<T>(StatusCodes.Status500InternalServerError, default(T), _msg, "");
        }
    }
}