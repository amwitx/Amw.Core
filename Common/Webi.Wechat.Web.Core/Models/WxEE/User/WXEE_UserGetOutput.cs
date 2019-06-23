using System;
using System.ComponentModel;

namespace Webi.Wechat.Web.Core.Models.WxEE
{
    public class WXEE_UserGetOutput
    {
        [Description("Guid")]
        public Guid guid { get; set; }

        [Description("成员UserID")]
        public string userid { get; set; }
        [Description("OpenId")]
        public string openid { get; set; }

        [Description("成员名称")]
        public string name { get; set; }

        [Description("职务信息")]
        public string position { get; set; }

        [Description("性别。null表示未定义，true表示男性，false表示女性")]
        public bool? gender { get; set; }

        [Description("邮箱")]
        public string email { get; set; }

        [Description("头像url。注：如果要获取小图将url最后的”/0”改成”/100”即可")]
        public string avatar { get; set; }

        [Description("员工个人二维码，扫描可添加为外部联系人")]
        public string qr_code { get; set; }
    }
}