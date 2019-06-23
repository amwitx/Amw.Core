using System;
using System.Threading.Tasks;
using Webi.Wechat.SDK.Enums.WxEE;
using Webi.Wechat.SDK.Models.WxEE;
using Webi.Wechat.SDK.Models.WxEE.PushMessage;

namespace Webi.Wechat.SDK.Apis.WxEE
{
    public class WxEE_PushAppMessageAPI
    {
        /// <summary>
        /// 发送应用消息
        /// https://work.weixin.qq.com/api/doc#90000/90135/90236
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public async Task<WxEE_MessageSendResult> SendAppMessage(string access_token, WxEE_PushAppBaseMessage message)
        {
            var msgtype = (WxEE_PushMessageType)Enum.Parse(typeof(WxEE_PushMessageType), message.msgtype);
            var jsonData = "";
            switch (msgtype)
            {
                case WxEE_PushMessageType.text:
                    jsonData = ApplicationContext.Json.ObjectToJson((WxEE_PushAppTextMessage)message, false);
                    break;

                case WxEE_PushMessageType.image:
                    jsonData = ApplicationContext.Json.ObjectToJson((WxEE_PushAppImageMessage)message, false);
                    break;

                case WxEE_PushMessageType.textcard:
                    jsonData = ApplicationContext.Json.ObjectToJson((WxEE_PushAppTextcardMessage)message, false);
                    break;

                default:
                    return new WxEE_MessageSendResult { invaliduser = "目前只支持text/image/textcard消息" };
            }
            //生成URL
            var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}", access_token);
            //请求
            return await ApplicationContext.Http.PostJsonAsync<WxEE_MessageSendResult>(url, jsonData);
        }
    }
}