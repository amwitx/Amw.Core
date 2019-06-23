namespace Webi.Wechat.SDK.Models.WxEE
{
    public class WxEE_GetUserinfoResult : WxEE_BaseResult
    {
        /// <summary>
        /// 成员UserID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 手机设备号(由企业微信在安装时随机生成，删除重装会改变，升级不受影响)
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 成员票据，最大为512字节。
        /// scope为snsapi_userinfo或snsapi_privateinfo，且用户在应用可见范围之内时返回此参数。
        /// 后续利用该参数可以获取用户信息或敏感信息。
        /// </summary>
        public string user_ticket { get; set; }

        /// <summary>
        /// user_ticket的有效时间（秒），随user_ticket一起返回
        /// </summary>
        public string expires_in { get; set; }
    }
}