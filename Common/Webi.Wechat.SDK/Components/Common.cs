using System;

namespace Webi.Wechat.SDK.Components
{
    public class Common
    {
        /// <summary>
        /// 生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
        /// </summary>
        public string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>
        /// 生成随机字符串 Guid.NewGuid().ToString().Replace("-", "")
        /// </summary>
        /// <returns></returns>
        public string GenerateNonceStr()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        /// <summary>
        /// 生成微信配置签名
        /// https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141115 签名算法
        /// </summary>
        /// <returns></returns>
        public string GenerateSignature(string timestamp, string noncestr, string jsapi_ticket, string url)
        {
            var parameter = "jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}";
            var value = string.Format(parameter, jsapi_ticket, noncestr, timestamp, url);
            return ApplicationContext.Encrypt.SHA1(value);
        }
    }
}