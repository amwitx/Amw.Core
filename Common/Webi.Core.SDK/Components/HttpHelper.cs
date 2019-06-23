using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Webi.Core.SDK.Components
{
    public class HttpHelper
    {
        internal HttpHelper()
        {
        }
        #region http

        public ServiceResult<string> Get(string url, Dictionary<string, string> headers = null)
        {
            var result = new ServiceResult<string>();
            try
            {
                using (var client = new WebClient())
                {
                    //设置请求头信息
                    if (headers != null)
                    {
                        foreach (var item in headers)
                        {
                            client.Headers.Add(item.Key, item.Value);
                        }
                    }
                    client.Encoding = Encoding.UTF8;
                    result.data = client.DownloadString(url);
                }
            }
            catch (Exception ex)
            {
                result = ServiceResult<string>.Exception(ex.Message);
            }
            return result;
        }
        public T GetJson<T>(string url, Dictionary<string, string> headers = null) where T : class, new()
        {
            var result = Get(url, headers);
            if (result.code != StatusCodes.Status200OK)
            {
                return default(T);
            }
            return ApplicationContext.Json.JsonToObject<T>(result.data);
        }
        public ServiceResult<string> Post(string url, string postData, Dictionary<string, string> headers = null)
        {
            var result = new ServiceResult<string>();
            try
            {
                using (var client = new WebClient())
                {
                    //设置请求头信息
                    if (headers != null)
                    {
                        foreach (var item in headers)
                        {
                            client.Headers.Add(item.Key, item.Value);
                        }
                    }
                    var sendData = Encoding.UTF8.GetBytes(postData);
                    client.Headers.Add("ContentLength", sendData.Length.ToString());
                    var buffer = client.UploadData(url, "POST", sendData);
                    result.data = Encoding.UTF8.GetString(buffer);
                }
            }
            catch (Exception ex)
            {
                result = ServiceResult<string>.Exception(ex.Message);
            }
            return result;
        }

        public T PostJson<T>(string url, string postData, Dictionary<string, string> headers = null) where T : class, new()
        {
            var result = Post(url, postData, headers);
            if (result.code != StatusCodes.Status200OK)
            {
                return default(T);
            }
            return ApplicationContext.Json.JsonToObject<T>(result.data);
        }
        #endregion

        #region http async

        public async Task<ServiceResult<string>> GetAsync(string url, Dictionary<string, string> headers = null)
        {
            var result = new ServiceResult<string>();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    //异步Post
                    var response = await httpClient.GetAsync(url);
                    //输出Http响应状态码
                    result.code = (int)response.StatusCode;
                    //确保Http响应成功
                    if (response.IsSuccessStatusCode)
                    {
                        //异步读取json
                        result.data = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                result = ServiceResult<string>.Exception(ex.Message);
            }
            return result;
        }

        public async Task<T> GetJsonAsync<T>(string url, Dictionary<string, string> headers = null) where T : class, new()
        {
            var result = await GetAsync(url, headers);
            if (result.code != StatusCodes.Status200OK)
            {
                return default(T);
            }
            return ApplicationContext.Json.JsonToObject<T>(result.data);
        }

        public async Task<Stream> GetStreamAsync(string url, Dictionary<string, string> headers = null)
        {
            using (var httpClient = new HttpClient())
            {
                //异步Post
                var response = await httpClient.GetAsync(url);
                //确保Http响应成功
                if (response.IsSuccessStatusCode)
                {
                    //异步读取json
                    return await response.Content.ReadAsStreamAsync();
                }
            }
            return null;
        }

        public async Task<ServiceResult<string>> PostAsync(string url, string postData, Dictionary<string, string> headers = null)
        {
            var result = new ServiceResult<string>();
            //设置Http的正文
            HttpContent httpContent = new StringContent(postData);
            //设置Http的内容标头
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //设置Http的内容标头的字符
            httpContent.Headers.ContentType.CharSet = "utf-8";

            using (var httpClient = new HttpClient())
            {
                //异步Post
                var response = await httpClient.PostAsync(url, httpContent);
                //输出Http响应状态码
                result.code = (int)response.StatusCode;
                //确保Http响应成功
                if (response.IsSuccessStatusCode)
                {
                    //异步读取返回值
                    result.data = await response.Content.ReadAsStringAsync();
                }
            }
            return result;
        }

        public async Task<T> PostJsonAsync<T>(string url, string postData, Dictionary<string, string> headers = null) where T : class, new()
        {
            var result = await PostAsync(url, postData, headers);
            if (result.code != StatusCodes.Status200OK)
            {
                return default(T);
            }
            return ApplicationContext.Json.JsonToObject<T>(result.data);
        }

        #endregion http
    }
}