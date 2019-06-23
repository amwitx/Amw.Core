using Webi.Wechat.SDK.Components;

namespace Webi.Wechat.SDK
{
    public class WxContext
    {
        private static Common _Common = new Common();

        /// <summary>
        /// 网页开发-js api
        /// </summary>
        public static Common Common
        {
            get { return _Common; }
        }
    }
}