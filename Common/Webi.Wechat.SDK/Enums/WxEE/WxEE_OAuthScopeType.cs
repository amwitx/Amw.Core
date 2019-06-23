namespace Webi.Wechat.SDK.Enums
{
    /// <summary>
    /// 应用授权作用域
    /// </summary>
    public enum WxEE_OAuthScopeType
    {
        /// <summary>
        /// snsapi_base：静默授权，可获取成员的基本信息；
        /// </summary>
        snsapi_base,

        /// <summary>
        /// snsapi_userinfo：静默授权，可获取成员的敏感信息，但不包含手机、邮箱；
        /// </summary>
        snsapi_userinfo,

        /// <summary>
        /// snsapi_privateinfo：手动授权，可获取成员的敏感信息，包含手机、邮箱
        /// </summary>
        snsapi_privateinfo
    }
}