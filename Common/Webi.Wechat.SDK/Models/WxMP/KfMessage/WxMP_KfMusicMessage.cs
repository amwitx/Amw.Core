using Webi.Wechat.SDK.Enums;

namespace Webi.Wechat.SDK.Models.WxMP.KfMessage
{
    /// <summary>
    /// 客服消息，音乐消息
    /// </summary>
    public class WxMP_KfMusicMessage : WxMP_KfBaseMessage
    {
        public WxMP_KfMusicMessage()
        {
            base.msgtype = WxMP_KFMessageType.music.ToString();
            music = new Post_KF_MusicMessageItem();
        }

        public Post_KF_MusicMessageItem music { get; set; }
    }

    public class Post_KF_MusicMessageItem
    {
        /// <summary>
        /// 图文消息/视频消息/音乐消息的标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 图文消息/视频消息/音乐消息的描述
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// 音乐链接
        /// </summary>
        public string musicurl { get; set; }

        /// <summary>
        /// 高品质音乐链接，wifi环境优先使用该链接播放音乐
        /// </summary>
        public string hqmusicurl { get; set; }

        /// <summary>
        /// 缩略图的媒体ID
        /// </summary>
        public string thumb_media_id { get; set; }
    }
}