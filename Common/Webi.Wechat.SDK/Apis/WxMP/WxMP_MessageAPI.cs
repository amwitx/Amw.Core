using System;
using System.Threading.Tasks;
using Webi.Wechat.SDK.Models.WxMP;

namespace Webi.Wechat.SDK.Apis.WxMP
{
    /// <summary>
    /// 消息管理
    /// </summary>
    public class WxMP_MessageAPI
    {
        /// <summary>
        /// 签名校验
        /// https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421135319
        /// </summary>
        /// <param name="token">微信后台配置的token</param>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool CheckSignature(string token, WxMP_CheckSignatureParameter input)
        {
            var arr = new string[] { token, input.timestamp, input.nonce };
            //字典排序
            Array.Sort(arr);
            var res = string.Join("", arr);
            var sha1 = ApplicationContext.Encrypt.SHA1(res);
            return input.signature == sha1;
        }

        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<WxMP_BaseResult> SendTmplMessage(string access_token, WxMP_TemplateMessage message)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", access_token);
            var jsonData = ApplicationContext.Json.ObjectToJson(message, false);
            //请求
            return await ApplicationContext.Http.PostJsonAsync<WxMP_BaseResult>(url, jsonData);
        }
    }
}