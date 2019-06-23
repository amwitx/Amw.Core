namespace Webi.Wechat.SDK.Models.WxEE
{
    public class WxEE_GetTokenResult : WxEE_BaseResult
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 凭证有效时间，单位：秒
        /// </summary>
        public int expires_in { get; set; }
    }
}