using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Webi.Core.SDK;
using Webi.Wechat.SDK;
using Webi.Wechat.SDK.Enums;
using Webi.Wechat.Web.Core.IService.WxMP;
using Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB;
using Webi.Wechat.Web.Core.Models.WxMP;

namespace Webi.Wechat.Web.Core.Service.WxMP
{
    public class WxMP_QrcodeService : WxMP_BaseService, IWxMP_QrcodeService
    {
        private readonly OLS_MiddlewareDBContext _middleDB;
        private readonly IWxMP_AuthorizeService _configService;

        public WxMP_QrcodeService(
            OLS_MiddlewareDBContext middleDB,
            IWxMP_AuthorizeService configService)
        {
            _middleDB = middleDB;
            _configService = configService;
        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        public async Task<ServiceResult<WxMP_QrcodeStreamOutput>> GenerateStream(WxMP_QrcodeStreamInput input)
        {
            try
            {
                input.CheckNull(nameof(WxMP_QrcodeStreamInput));
                input.wid.CheckZero(nameof(input.wid));
                input.business_id.CheckEmpty(nameof(input.business_id));
                input.module_type.CheckEmpty(nameof(input.module_type));

                var result = new ServiceResult<WxMP_QrcodeStreamOutput>();
                result.data = new WxMP_QrcodeStreamOutput();
                //获取临时二维码(业务ID)
                var scene = _middleDB.WechatQrscene.FirstOrDefault(w =>
                w.WechatId == input.wid && w.BusinessId == input.business_id && w.ModuleType == input.module_type);
                var ticket = string.Empty;
                var sceneId = 0;
                //未创建
                if (scene == null)
                {
                    scene = new WechatQrscene
                    {
                        BusinessId = input.business_id,
                        WechatId = input.wid,
                        ModuleType = input.module_type,
                        ActionName = WxMP_QRSceneActionType.QR_SCENE.ToString(),
                        ExpireTime = DateTime.Now.AddMinutes(-5),//5分钟之前
                        CreateTime = DateTime.Now
                    };
                    //添加数据
                    _middleDB.WechatQrscene.Add(scene);
                    _middleDB.SaveChanges();
                    sceneId = scene.SceneId;
                }
                else
                {
                    sceneId = scene.SceneId;
                    ticket = scene.Ticket;
                }

                //临时二维码，网址访问，到期后自动延时
                if (scene.ExpireTime < DateTime.Now || input.is_new)
                {
                    var access_token = _configService.GetAccessToken(new WxMP_AuthorizeAccessTokenInput { wid = input.wid });
                    //创建临时二维码，30天
                    var createResult = await WxMPContext.AcountAPI.CreateTempQRSceneById(access_token.data.access_token, sceneId, 60 * 60 * 24 * 30);
                    ticket = createResult.ticket;
                    //自动延时 30天-5分钟
                    var expireTime = DateTime.Now.AddSeconds(createResult.expire_seconds - (60 * 5));
                    //更新二维码信息
                    scene.Ticket = createResult.ticket;
                    scene.ExpireSeconds = createResult.expire_seconds;
                    scene.Url = createResult.url;
                    scene.ExpireTime = expireTime;
                    _middleDB.SaveChanges();
                }
                //获取图片
                var stream = await WxMPContext.AcountAPI.GetQRSceneImgStream(ticket);
                var image = new Bitmap(stream);
                var ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                result.data.stream = ms;
                return result;
            }
            catch (Exception ex)
            {
                return ServiceResult<WxMP_QrcodeStreamOutput>.Exception(ex.Message);
            }
        }
    }
}