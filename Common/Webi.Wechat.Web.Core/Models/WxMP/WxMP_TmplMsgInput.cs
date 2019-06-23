using API.Wiki.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webi.Wechat.Web.Core.Models.WxMP
{
    public class WxMP_TmplMsgInput
    {
        public WxMP_TmplMsgInput()
        {
            miniprogram = new WxMP_TmplMsgInputMiniProgram();
            first = new WxMP_TmplMsgInputItem();
            items = new List<WxMP_TmplMsgInputItem>();
            items.Add(new WxMP_TmplMsgInputItem());
            remark = new WxMP_TmplMsgInputItem();
        }
        [WikiRequired]
        [Description("公众号配置唯一ID")]
        public string guid { get; set; }

        [WikiRequired]
        [Description("接收者openid")]
        public string openid { get; set; }

        [WikiRequired]
        [Description("模板ID")]
        public string template_id { get; set; }

        [Description("模板跳转链接，不传则不跳转")]
        public string url { get; set; }

        [Description("跳小程序所需数据，不需跳小程序可不用传该数据")]
        public WxMP_TmplMsgInputMiniProgram miniprogram { get; set; }

        [WikiRequired]
        [Description("模板消息头部")]
        public WxMP_TmplMsgInputItem first { get; set; }

        [WikiRequired]
        [Description("消息内容")]
        public List<WxMP_TmplMsgInputItem> items { get; set; }

        [WikiRequired]
        [Description("模板消息备注")]
        public WxMP_TmplMsgInputItem remark { get; set; }
    }

    public class WxMP_TmplMsgInputMiniProgram
    {
        [Description("所需跳转到的小程序appid")]
        public string appid { get; set; }

        [Description("所需跳转到小程序的具体页面路径，支持带参数")]
        public string pagepath { get; set; }
    }

    public class WxMP_TmplMsgInputItem
    {
        [Description("模板内容")]
        public string value { get; set; }

        [Description("模板内容字体颜色，#123456 不填默认为黑色")]
        public string color { get; set; }
    }
}