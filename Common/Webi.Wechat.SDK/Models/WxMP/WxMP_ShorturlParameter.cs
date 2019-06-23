using System.Text;

namespace Webi.Wechat.Models.Input.Account
{
    public class WxMP_ShorturlParameter
    {
        /// <summary>
        /// 此处填long2short，代表长链接转短链接
        /// </summary>
        //public string action { get; set; }
        /// <summary>
        /// 需要转换的长链接，支持 http://、https://、weixin://wxpay 格式的url
        /// </summary>
        public string long_url { get; set; }

        internal string ToJson()
        {
            var json = new StringBuilder();
            json.Append("{\"action\":\"long2short\",");
            json.Append("\"long_url\":\"");
            json.Append(long_url);
            json.Append("\"}");
            return json.ToString();
        }
    }
}