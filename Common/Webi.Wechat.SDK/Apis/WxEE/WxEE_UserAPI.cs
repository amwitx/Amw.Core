using System;
using System.Threading.Tasks;
using Webi.Wechat.SDK.Models.WxEE;

namespace Webi.Wechat.SDK.WxEEApi
{
    public class WxEE_UserAPI
    {
        /// <summary>
        /// code获取访问用户身份
        /// https://work.weixin.qq.com/api/doc#90000/90135/91023
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<WxEE_GetUserinfoResult> GetUserinfo(string access_token, string code)
        {
            var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token={0}&code={1}", access_token, code);
            //请求
            return await ApplicationContext.Http.GetJsonAsync<WxEE_GetUserinfoResult>(url);
        }

        /// <summary>
        /// 使用user_ticket获取成员详情（信息少，建议使用通讯录-读取成员）
        /// https://work.weixin.qq.com/api/doc#10028
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="user_ticket"></param>
        /// <returns></returns>
        public async Task<WxEE_GetUserDetailResult> GetUserDetail(string access_token, string user_ticket)
        {
            var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/getuserdetail?access_token={0}", access_token);
            var ticket = "{\"user_ticket\":\"" + user_ticket + "\"}";
            //请求
            return await ApplicationContext.Http.PostJsonAsync<WxEE_GetUserDetailResult>(url, ticket);
        }

        /// <summary>
        /// 通讯录-读取成员
        /// https://work.weixin.qq.com/api/doc#90000/90135/90196
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public async Task<WxEE_ContactUserResult> GetContactUser(string access_token, string userid)
        {
            var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token={0}&userid={1}", access_token, userid);
            //请求
            return await ApplicationContext.Http.GetJsonAsync<WxEE_ContactUserResult>(url);
        }

        /// <summary>
        /// 获取成员个人名片url的接口，可用于推送短信邀请客户添加企业微信用户为外部联系人。
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public async Task<WxEE_GetUserNameCardUrlResult> GetUserNameCardUrl(string access_token, string userid)
        {
            var url = $"https://qyapi.weixin.qq.com/cgi-bin/user/get_name_card_url?access_token={access_token}";

            string json = "{\"userid\":\"" + userid + "\"}";

            return await ApplicationContext.Http.PostJsonAsync<WxEE_GetUserNameCardUrlResult>(url, json);
        }
        /// <summary>
        /// userid与openid互换
        /// https://work.weixin.qq.com/api/doc#90000/90135/90196
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public async Task<WxEE_UserIdToOpenId> UserIdToOpenId(string access_token, string userid)
        {
            var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/convert_to_openid?access_token={0}", access_token, userid);
            string json = "{\"userid\":\"" + userid + "\"}";
            //请求
            return await ApplicationContext.Http.PostJsonAsync<WxEE_UserIdToOpenId>(url, json);
        }
    }
}