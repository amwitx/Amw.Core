using API.Wiki.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webi.Wechat.Web.Core.Models.WxMP
{
    public class WxMP_AuthorizeAccessTokenInput
    {
        [WikiRequired]
        [Description("公众号自增ID，内部代码使用")]
        public int wid { get; set; } = 0;

        [WikiRequired]
        [Description("公众号唯一ID，所有外部调用")]
        public string guid { get; set; }
    }
}