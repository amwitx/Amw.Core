using System;
using System.Threading.Tasks;
using Webi.Wechat.SDK.Models.WxEE;

namespace Webi.Wechat.SDK.WxEEApi
{
    public class WxEE_BaseAPI
    {
        /// <summary>
        /// 获取微信Token
        /// </summary>
        /// <param name="corpid">企业ID
        /// https://work.weixin.qq.com/api/doc#90000/90135/90665/corpid</param>
        /// <param name="corpSecret">应用秘钥
        /// https://work.weixin.qq.com/api/doc#90000/90135/90665/secret</param>
        /// <returns></returns>
        public WxEE_GetTokenResult GetAccessToken(string corpId, string corpSecret)
        {
            //生成URL
            var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}", corpId, corpSecret);
            //请求
            return  ApplicationContext.Http.GetJson<WxEE_GetTokenResult>(url);
        }
    }
}