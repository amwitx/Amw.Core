using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webi.Wechat.SDK.Models.WxMP
{
    /// <summary>
    /// 模板消息内容
    /// </summary>
    public class WxMP_TemplateMessage
    {
        public WxMP_TemplateMessage() {
            data = new WxMP_TemplateMessageData();
        }
        /// <summary>
        /// 接收者openid
        /// </summary>
        public string touser { get; set; }

        /// <summary>
        /// 模板ID
        /// </summary>
        public string template_id { get; set; }

        /// <summary>
        /// 模板跳转链接（海外帐号没有跳转能力）
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 小程序，跳小程序所需数据，不需跳小程序可不用传该数据
        /// </summary>
        public WxMP_TemplateMessageMiniProgram miniprogram { get; set; }


        /// <summary>
        /// 模板数据
        /// </summary>
        public WxMP_TemplateMessageData data { get; set; }

        //public string ToJson()
        //{
        //    var sbJson = new StringBuilder();
        //    sbJson.Append("{");
        //    sbJson.AppendFormat(" \"touser\":\"{0}\",", touser);
        //    sbJson.AppendFormat(" \"template_id\":\"{0}\",", template_id);
        //    sbJson.AppendFormat(" \"url\":\"{0}\",", url);
        //    sbJson.Append(" \"data\":{");

        //    sbJson.Append("  \"first\": ");
        //    sbJson.Append(First.ToJson());
        //    sbJson.Append("  ,");
        //    for (int i = 0; i < Data.Count; i++)
        //    {
        //        var item = Data[i];
        //        sbJson.AppendFormat("  \"keyword{0}\":", i + 1);
        //        sbJson.Append(item.ToJson());
        //        if (i < Data.Count)
        //        {
        //            sbJson.Append(",");
        //        }
        //    }
        //    sbJson.Append("  \"remark\": ");
        //    sbJson.Append(Remark.ToJson());
        //    sbJson.Append(" }");
        //    sbJson.Append("}");
        //    return sbJson.ToString();
        //}
    }
    public class WxMP_TemplateMessageData
    {
        public WxMP_TemplateMessageData()
        {
            first = new WxMP_TemplateMessageDataItem();
            remark = new WxMP_TemplateMessageDataItem();
        }
        /// <summary>
        /// 顶部信息
        /// </summary>
        public WxMP_TemplateMessageDataItem first { get; set; }
        /// <summary>
        /// 元素
        /// </summary>
        public WxMP_TemplateMessageDataItem keyword1 { get; set; }
        /// <summary>
        /// 元素
        /// </summary>
        public WxMP_TemplateMessageDataItem keyword2 { get; set; }
        /// <summary>
        /// <summary>
        /// 元素
        /// </summary>
        public WxMP_TemplateMessageDataItem keyword3 { get; set; }
        /// <summary>
        /// <summary>
        /// 元素
        /// </summary>
        public WxMP_TemplateMessageDataItem keyword4 { get; set; }
        /// <summary>
        /// <summary>
        /// 元素
        /// </summary>
        public WxMP_TemplateMessageDataItem keyword5 { get; set; }
        /// <summary>
        /// <summary>
        /// 元素
        /// </summary>
        public WxMP_TemplateMessageDataItem keyword6 { get; set; }
        /// <summary>
        /// <summary>
        /// 备注
        /// </summary>
        public WxMP_TemplateMessageDataItem remark { get; set; }
    }
    /// <summary>
    /// 模板消息内容项
    /// </summary>
    public class WxMP_TemplateMessageDataItem
    {
        /// <summary>
        /// 模板内容
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// 模板内容字体颜色，#123456 不填默认为黑色
        /// </summary>
        public string color { get; set; }

        //public string ToJson()
        //{
        //    var sbJson = new StringBuilder();
        //    sbJson.Append("{");
        //    sbJson.AppendFormat("\"value\":\"{0}\"", value);
        //    if (!string.IsNullOrEmpty(color))
        //    {
        //        sbJson.AppendFormat(",\"color\":\"{0}\"", color);
        //    }
        //    sbJson.Append("}");
        //    return sbJson.ToString();
        //}
    }

    public class WxMP_TemplateMessageMiniProgram
    {
        /// <summary>
        /// 所需跳转到的小程序appid（该小程序appid必须与发模板消息的公众号是绑定关联关系，暂不支持小游戏）
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 所需跳转到小程序的具体页面路径，支持带参数,（示例index?foo=bar），要求该小程序已发布，暂不支持小游戏
        /// </summary>
        public string pagepath { get; set; }
    }
}
