namespace Webi.Wechat.SDK.Models.WxMP
{
    /// <summary>
    /// 校验签名参数对象
    /// </summary>
    public class WxMP_CheckSignatureParameter
    {
        /// <summary>
        /// 微信配置Id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 微信加密签名
        /// </summary>
        public string signature { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        /// 随机数
        /// </summary>
        public string nonce { get; set; }

        /// <summary>
        /// 输出字符串
        /// </summary>
        public string echostr { get; set; }

        /// <summary>
        /// 是否包含值
        /// </summary>
        public bool HasValue
        {
            get
            {
                if (id == 0
                    || string.IsNullOrWhiteSpace(signature)
                    || string.IsNullOrWhiteSpace(timestamp)
                    || string.IsNullOrWhiteSpace(nonce))
                {
                    return false;
                }
                return true;
            }
        }
    }
}