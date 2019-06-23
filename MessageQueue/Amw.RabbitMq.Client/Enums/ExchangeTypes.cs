using System.ComponentModel;

namespace Amw.RabbitMq.Client.Enums
{
    public enum ExchangeTypes
    {
        /// <summary>
        /// 默认模式
        /// </summary>
        [Description("默认模式")]
        defult,

        /// <summary>
        /// 直连模式
        /// </summary>
        [Description("直连模式")]
        direct,

        /// <summary>
        /// 广播模式
        /// </summary>
        [Description("广播模式")]
        fanout,

        /// <summary>
        /// 主题模式
        /// </summary>
        [Description("主题模式")]
        topic
    }
}