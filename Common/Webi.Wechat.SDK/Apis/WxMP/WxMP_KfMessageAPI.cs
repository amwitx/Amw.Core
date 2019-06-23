using System;
using System.Threading.Tasks;
using Webi.Wechat.SDK.Enums;
using Webi.Wechat.SDK.Models.WxMP;
using Webi.Wechat.SDK.Models.WxMP.KfMessage;

namespace Webi.Wechat.SDK.Apis.WxMP
{
    public class WxMP_KfMessageAPI
    {
        /// <summary>
        /// 客服发送消息接口
        /// https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140547
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="message"></param>
        public async Task<WxMP_BaseResult> SendKfMessage(string access_token, WxMP_KfBaseMessage message)
        {
            //逻辑
            var msgtype = (WxMP_KFMessageType)Enum.Parse(typeof(WxMP_KFMessageType), message.msgtype);
            var jsonData = "";
            switch (msgtype)
            {
                case WxMP_KFMessageType.text:
                    jsonData = ApplicationContext.Json.ObjectToJson((WxMP_KfTextMessage)message);
                    break;

                case WxMP_KFMessageType.image:
                    jsonData = ApplicationContext.Json.ObjectToJson((WxMP_KfImageMessage)message);
                    break;

                default:
                    return new WxMP_BaseResult { errcode = 404, errmsg = "目前只支持text/image消息" };
            }
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}", access_token);
            //请求
            return await ApplicationContext.Http.PostJsonAsync<WxMP_BaseResult>(url, jsonData);
        }
    }
}