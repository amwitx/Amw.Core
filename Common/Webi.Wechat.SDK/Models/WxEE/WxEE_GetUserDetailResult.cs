namespace Webi.Wechat.SDK.Models.WxEE
{
    public class WxEE_GetUserDetailResult : WxEE_BaseResult
    {
        /// <summary>
        /// 成员UserID
        /// </summary>
        public string userid { get; set; }

        /// <summary>
        /// 成员姓名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 成员手机号，仅在用户同意snsapi_privateinfo授权时返回
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// 性别。0表示未定义，1表示男性，2表示女性
        /// </summary>
        public int gender { get; set; }

        /// <summary>
        /// 成员邮箱，仅在用户同意snsapi_privateinfo授权时返回
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 头像url。注：如果要获取小图将url最后的”/0”改成”/100”即可
        /// </summary>
        public string avatar { get; set; }

        /// <summary>
        /// 员工个人二维码，扫描可添加为外部联系人
        /// </summary>
        public string qr_code { get; set; }
    }
}