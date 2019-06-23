using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Webi.Wechat.Models.Input.Account;
using Webi.Wechat.SDK.Models.WxMP;

namespace Webi.Wechat.SDK.Apis.WxMP
{
    /// <summary>
    /// 账号管理
    /// </summary>
    public class WxMP_AcountAPI
    {
        /// <summary>
        /// 创建临时二维码
        /// https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1443433542
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="sceneId">场景ID</param>
        /// <param name="callback">回调方法</param>
        /// <param name="expire_seconds">超时毫秒 2592000（默认30天）</param>
        /// <returns></returns>
        public async Task<WxMP_QRSceneResult> CreateTempQRSceneById(string access_token, int scene_id, int expire_seconds = 2592000)
        {
            var postUrl = string.Format("https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}", access_token);
            var para = new WxMP_QrcodeCreateParameter();
            para.expire_seconds = expire_seconds;
            para.scene_id = scene_id;
            //请求
            return await ApplicationContext.Http.PostJsonAsync<WxMP_QRSceneResult>(postUrl, para.ToJson());
        }

        /// <summary>
        /// 创建临时二维码
        /// https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1443433542
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="scene_str">场景字符串</param>
        /// <param name="callback">回调方法</param>
        /// <param name="expire_seconds">超时毫秒 2592000（默认30天）</param>
        /// <returns></returns>
        public async Task<WxMP_QRSceneResult> CreateTempQRSceneByStr(string access_token, string scene_str, int expire_seconds = 2592000)
        {
            var postUrl = string.Format("https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}", access_token);
            var para = new WxMP_QrcodeCreateParameter();
            para.expire_seconds = expire_seconds;
            para.scene_str = scene_str;
            //请求
            return await ApplicationContext.Http.PostJsonAsync<WxMP_QRSceneResult>(postUrl, para.ToJson());
        }

        /// <summary>
        /// 创建永久二维码
        /// https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1443433542
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="scene_str">场景ID</param>
        /// <param name="callback">回调方法</param>
        /// <param name="expire_seconds">超时毫秒 2592000（默认30天）</param>
        /// <returns></returns>
        public async Task<WxMP_QRSceneResult> CreateQRLimitScene(string access_token, int scene_id, string scene_str)
        {
            var postUrl = string.Format("https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}", access_token);
            var para = new WxMP_QrcodeCreateParameter();
            para.IsLimit = true;
            para.scene_id = scene_id;
            para.scene_str = scene_str;
            //请求
            return await ApplicationContext.Http.PostJsonAsync<WxMP_QRSceneResult>(postUrl, para.ToJson());
        }

        /// <summary>
        /// 获取二维码
        /// https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1443433542
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public async Task<Stream> GetQRSceneImgStream(string ticket)
        {
            var url = string.Format("https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={0}", HttpUtility.UrlEncode(ticket));
            return await ApplicationContext.Http.GetStreamAsync(url);
        }

        /// <summary>
        /// 长链接转短链接接口
        /// https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1443433600
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="long_url"></param>
        /// <returns></returns>
        public async Task<WxMP_ShorturlResult> GetShortUrl(string access_token, string long_url)
        {
            //地址
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/shorturl?access_token={0}", access_token);
            var para = new WxMP_ShorturlParameter();
            //参数
            para.long_url = long_url;
            return await ApplicationContext.Http.PostJsonAsync<WxMP_ShorturlResult>(url, para.ToJson());
        }
    }
}