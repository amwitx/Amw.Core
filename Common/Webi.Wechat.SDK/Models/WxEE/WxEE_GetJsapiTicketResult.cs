namespace Webi.Wechat.SDK.Models.WxEE
{
    /// <summary>
    /// jsapi返回
    /// </summary>
    public class WxEE_GetJsapiTicketResult : WxEE_BaseResult
    {
        /// <summary>
        /// ticket
        /// </summary>
        public string ticket { get; set; }

        /// <summary>
        /// 凭证有效时间，单位：秒
        /// </summary>
        public int expires_in { get; set; }
    }
}