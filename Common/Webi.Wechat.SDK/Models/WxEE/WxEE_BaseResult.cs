namespace Webi.Wechat.SDK.Models.WxEE
{
    public class WxEE_BaseResult
    {
        /// <summary>
        /// 错误码，0：请求成功
        /// </summary>
        public int errcode { get; set; } = 0;

        /// <summary>
        /// 错误信息
        /// </summary>
        public string errmsg { get; set; }
    }
}