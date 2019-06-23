using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Amw.Core.SDK.Components
{
    public class HttpHelper
    {
        internal HttpHelper()
        {
        }

        #region web sync

        public string Get(string url, Dictionary<string, string> headers = null)
        {
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
                    return client.DownloadString(url);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Post(string url, string postData, Dictionary<string, string> headers = null)
        {
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
                    return Encoding.UTF8.GetString(buffer);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion web sync

        #region http async

        public async Task<string> GetAsync(string url, Dictionary<string, string> headers = null)
        {
            var code = HttpStatusCode.OK;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    //异步Post
                    var response = await httpClient.GetAsync(url);
                    //输出Http响应状态码
                    code = response.StatusCode;
                    //确保Http响应成功
                    if (response.IsSuccessStatusCode)
                    {
                        //异步读取json
                        return await response.Content.ReadAsStringAsync();
                    }
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return $"{code}|{ex.Message}";
            }
        }

        public async Task<string> PostAsync(string url, string postData, Dictionary<string, string> headers = null)
        {
            var code = HttpStatusCode.OK;
            try
            {
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
                    code = response.StatusCode;
                    //确保Http响应成功
                    if (response.IsSuccessStatusCode)
                    {
                        //异步读取返回值
                        return await response.Content.ReadAsStringAsync();
                    }
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return $"{code}|{ex.Message}";
            }
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

        #endregion http async
    }
}