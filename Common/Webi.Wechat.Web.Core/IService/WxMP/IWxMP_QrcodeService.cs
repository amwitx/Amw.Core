using System.Threading.Tasks;
using Webi.Core.SDK;
using Webi.Wechat.Web.Core.Models.WxMP;

namespace Webi.Wechat.Web.Core.IService.WxMP
{
    public interface IWxMP_QrcodeService
    {
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="business_id"></param>
        /// <param name="module_type"></param>
        /// <param name="is_new"></param>
        /// <returns></returns>
        Task<ServiceResult<WxMP_QrcodeStreamOutput>> GenerateStream(WxMP_QrcodeStreamInput input);
    }
}