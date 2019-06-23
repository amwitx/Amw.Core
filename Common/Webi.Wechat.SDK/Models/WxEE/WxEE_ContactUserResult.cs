using System.Collections.Generic;

namespace Webi.Wechat.SDK.Models.WxEE
{
    /// <summary>
    /// 通讯录用户信息
    /// </summary>
    public class WxEE_ContactUserResult : WxEE_BaseResult
    {
        /// <summary>
        /// 成员UserID。对应管理端的帐号，企业内必须唯一。不区分大小写，长度为1~64个字节
        /// </summary>
        public string userid { get; set; }

        /// <summary>
        /// 成员名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 成员所属部门id列表，仅返回该应用有查看权限的部门id
        /// </summary>
        public List<int> department { get; set; }

        /// <summary>
        /// 部门内的排序值，默认为0。数量必须和department一致，数值越大排序越前面。值范围是[0, 2^32)
        /// </summary>
        public List<int> order { get; set; }

        /// <summary>
        /// 职务信息；第三方仅通讯录应用可获取
        /// </summary>
        public string position { get; set; }

        /// <summary>
        /// 手机号码，第三方仅通讯录应用可获取
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// 性别。0表示未定义，1表示男性，2表示女性
        /// </summary>
        public int gender { get; set; }

        /// <summary>
        /// 邮箱，第三方仅通讯录应用可获取
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 表示在所在的部门内是否为上级。；第三方仅通讯录应用可获取
        /// </summary>
        public string isleader { get; set; }

        /// <summary>
        /// 头像url。注：如果要获取小图将url最后的”/0”改成”/100”即可。第三方仅通讯录应用可获取
        /// </summary>
        public string avatar { get; set; }

        /// <summary>
        /// 座机。第三方仅通讯录应用可获取
        /// </summary>
        public string telephone { get; set; }

        /// <summary>
        /// 成员启用状态。1表示启用的成员，0表示被禁用。注意，服务商调用接口不会返回此字段
        /// </summary>
        public string enable { get; set; }

        /// <summary>
        /// 别名；第三方仅通讯录应用可获取
        /// </summary>
        public string alias { get; set; }

        /// <summary>
        /// 扩展属性，第三方仅通讯录应用可获取
        /// </summary>
        //public WxEE_ContactUserExtattrResult extattr { get; set; }

        /// <summary>
        /// 激活状态: 1=已激活，2=已禁用，4=未激活。
        /// 已激活代表已激活企业微信或已关注微工作台（原企业号）。未激活代表既未激活企业微信又未关注微工作台（原企业号）。
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 员工个人二维码，扫描可添加为外部联系人；第三方仅通讯录应用可获取
        /// </summary>
        public string qr_code { get; set; }

        /// <summary>
        /// 对外职务，如果设置了该值，则以此作为对外展示的职务，否则以position来展示。
        /// </summary>
        public string external_position { get; set; }

        /// <summary>
        /// 成员对外属性，字段详情见对外属性；第三方仅通讯录应用可获取
        /// </summary>
        //public string external_profile { get; set; }
    }

    public class WxEE_ContactUserExtattrResult
    {
        public WxEE_ContactUserExtattrAttrsResult attrs { get; set; }
    }

    public class WxEE_ContactUserExtattrAttrsResult
    {
        public string type { get; set; }
        public string name { get; set; }
        public WxEE_ContactUserExtattrAttrsTextResult text { get; set; }

        public WxEE_ContactUserExtattrAttrsWebResult web { get; set; }
    }
    public class WxEE_ContactUserExtattrAttrsTextResult
    {
        public string value { get; set; }
    }
    public class WxEE_ContactUserExtattrAttrsWebResult
    {
        public string url { get; set; }
        public string title { get; set; }
    }
}