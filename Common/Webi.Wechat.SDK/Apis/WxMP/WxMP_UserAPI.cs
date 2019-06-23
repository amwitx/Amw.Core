using System;
using System.Threading.Tasks;
using Webi.Wechat.SDK.Models.WxMP;

namespace Webi.Wechat.SDK.Apis.WxMP
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class Wechat_UserAPI
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public async Task<WxMP_UserinfoResult> GetUserinfo(string access_token, string openid)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN", access_token, openid);
            return await ApplicationContext.Http.GetJsonAsync<WxMP_UserinfoResult>(url);
        }
    }
}