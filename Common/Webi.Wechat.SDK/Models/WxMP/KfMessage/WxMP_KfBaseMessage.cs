using System;
using System.Collections.Generic;
using System.Text;

namespace Webi.Wechat.SDK.Models.WxMP.KfMessage
{
   public class WxMP_KfBaseMessage
    {
        /// <summary>
        /// 普通用户openid
        /// </summary>
        public string touser { get; set; }

        /// <summary>
        /// 消息类型，文本为text，图片为image，语音为voice，视频消息为video，音乐消息为music，图文消息（点击跳转到外链）为news，图文消息（点击跳转到图文消息页面）为mpnews，卡券为wxcard
        /// </summary>
        public string msgtype { get; set; }

        public WxMP_KfCustomServiceItem customservice { get; set; }

    }
    public class WxMP_KfCustomServiceItem {
        public string kf_account { get; set; }
    }
}
