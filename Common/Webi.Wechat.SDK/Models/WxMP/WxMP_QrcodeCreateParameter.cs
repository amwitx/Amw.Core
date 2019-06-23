using System.Text;

namespace Webi.Wechat.SDK.Models.WxMP
{
    /// <summary>
    /// 生成带参数的二维码
    /// </summary>
    public class WxMP_QrcodeCreateParameter
    {
        /// <summary>
        /// 是否永久二维码（默认临时二维码）
        /// </summary>
        public bool IsLimit = false;

        /// <summary>
        /// 超时毫秒 2592000（默认30天）
        /// 该二维码有效时间，以秒为单位。 最大不超过2592000（即30天），此字段如果不填，则默认有效期为30秒。
        /// </summary>
        public int expire_seconds = 2592000;

        /// <summary>
        /// 场景值ID，临时二维码时为32位非0整型，永久二维码时最大值为100000（目前参数只支持1--100000）
        /// </summary>
        public int scene_id { get; set; } = 0;

        /// <summary>
        /// 场景值ID（字符串形式的ID），字符串类型，长度限制为1到64
        /// </summary>
        public string scene_str { get; set; }

        /// <summary>
        /// {"expire_seconds": 604800, "action_name": "QR_SCENE", "action_info": {"scene": {"scene_id": 123}}}
        /// {"action_name": "QR_LIMIT_SCENE", "action_info": {"scene": {"scene_id": 123}}}
        /// {"action_name": "QR_LIMIT_STR_SCENE", "action_info": {"scene": {"scene_str": "123"}}}
        /// action_name（二维码类型，QR_SCENE为临时,QR_LIMIT_SCENE为永久,QR_LIMIT_STR_SCENE为永久的字符串参数值）
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            var json = new StringBuilder();
            json.Append("{");
            //永久二维码没有超时时间
            if (!IsLimit)
            {
                //该二维码有效时间，以秒为单位。 最大不超过2592000（即30天），此字段如果不填，则默认有效期为30秒。
                json.Append("\"expire_seconds\":");
                json.Append(expire_seconds);
                json.Append(",");
            }
            //二维码类型，QR_SCENE为临时的整型参数值，QR_STR_SCENE为临时的字符串参数值，QR_LIMIT_SCENE为永久的整型参数值，QR_LIMIT_STR_SCENE为永久的字符串参数值
            json.Append("\"action_name\":");
            //永久
            if (IsLimit)
            {
                json.Append("\"QR_LIMIT_SCENE\"");
            }
            else
            {
                json.Append("\"QR_SCENE\"");
            }
            //二维码详细信息
            json.Append(",\"action_info\":");
            json.Append("{\"scene\":");
            if (scene_id > 0)
            {
                //场景值ID，临时二维码时为32位非0整型，永久二维码时最大值为100000（目前参数只支持1--100000）
                json.Append("{\"scene_id\":");
                json.Append("\"" + scene_id + "\"");
            }
            else
            {
                //场景值ID（字符串形式的ID），字符串类型，长度限制为1到64
                json.Append("{\"scene_str\":");
                json.Append("\"" + scene_str + "\"");
            }
            json.Append("}}}");
            return json.ToString();
        }
    }
}