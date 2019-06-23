using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Webi.Core.SDK;
using Webi.Wechat.SDK;
using Webi.Wechat.SDK.Models.WxMP.KfMessage;
using Webi.Wechat.Web.Core.IService.WxMP;
using Webi.Wechat.Web.Core.Models;
using Webi.Wechat.Web.Core.Models.WxMP;

namespace Webi.Wechat.Web.Core.Service.WxMP
{
    public class WxMP_KfMsgService : WxMP_BaseService, IWxMP_KfMsgService
    {
        private readonly IWxMP_AuthorizeService _tokenService;

        public WxMP_KfMsgService(
            IWxMP_AuthorizeService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// 发送客服文本消息
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="openid"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task<ServiceResult<CommonResultStateOutput>> SendText(WxMP_KfMsgTextMsgInput input)
        {
            try
            {
                input.CheckNull(nameof(WxMP_KfMsgTextMsgInput));
                input.guid.CheckEmpty(nameof(input.guid));
                input.openid.CheckEmpty(nameof(input.openid));
                input.content.CheckEmpty(nameof(input.content));

                var token = _tokenService.GetAccessToken(new WxMP_AuthorizeAccessTokenInput { guid = input.guid });
                if (token.code != 200)
                {
                    return ServiceResult<CommonResultStateOutput>.Failed(StatusCodes.Status400BadRequest, token.msg);
                }
                var text = new WxMP_KfTextMessage();
                text.touser = input.openid;
                text.text.content = input.content;
                var result = await WxMPContext.KfMessageAPI.SendKfMessage(token.data.access_token, text);
                return ServiceResult<CommonResultStateOutput>.Success(new CommonResultStateOutput { result_state = result.errmsg });
            }
            catch (Exception ex)
            {
                return ServiceResult<CommonResultStateOutput>.Exception(ex.Message);
            }
        }
    }
}