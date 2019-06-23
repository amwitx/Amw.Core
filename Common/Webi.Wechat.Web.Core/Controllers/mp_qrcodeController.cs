using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Webi.Core.SDK.Enums;
using Webi.Wechat.Web.Core.IService.WxMP;
using Webi.Wechat.Web.Core.Models.WxMP;

namespace Webi.Wechat.Web.Core.Controllers
{
    public class mp_qrcodeController : Controller
    {
        private readonly IWxMP_QrcodeService _mp_qrcode;

        public mp_qrcodeController(IWxMP_QrcodeService mp_qrcode)
        {
            _mp_qrcode = mp_qrcode;
        }

        /// <summary>
        /// 临时二维码图片
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="business_id"></param>
        /// <param name="module_type"></param>
        /// <returns></returns>
        public async Task<IActionResult> temp_file(int wid, string business_id, string module_type, int is_new = 0)
        {
            var result = await _mp_qrcode.GenerateStream(
                new WxMP_QrcodeStreamInput
                {
                    wid = wid,
                    business_id = business_id,
                    module_type = module_type,
                    is_new = is_new == 1
                });
            if (result.code != StatusCodes.Status200OK)
            {
                Response.StatusCode = result.code;
                return Content(result.msg);
            }
            return File(result.data.stream.ToArray(), HttpContentTypes.gif);
        }

        /// <summary>
        /// 临时二维码base64
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="business_id"></param>
        /// <param name="module_type"></param>
        /// <returns></returns>
        public async Task<IActionResult> temp_base64(int wid, string business_id, string module_type)
        {
            var result = await _mp_qrcode.GenerateStream(
                new WxMP_QrcodeStreamInput
                {
                    wid = wid,
                    business_id = business_id,
                    module_type = module_type
                });
            if (result.code != StatusCodes.Status200OK)
            {
                Response.StatusCode = result.code;
                return Content(result.msg);
            }
            return Content(Convert.ToBase64String(result.data.stream.ToArray()));
        }
    }
}