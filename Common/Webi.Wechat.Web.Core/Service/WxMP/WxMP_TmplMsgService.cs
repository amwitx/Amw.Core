using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Webi.Core.SDK;
using Webi.Wechat.SDK;
using Webi.Wechat.SDK.Models.WxMP;
using Webi.Wechat.Web.Core.IService.WxMP;
using Webi.Wechat.Web.Core.Models;
using Webi.Wechat.Web.Core.Models.WxMP;

namespace Webi.Wechat.Web.Core.Service.WxMP
{
    public class WxMP_TmplMsgService : IWxMP_TmplMsgService
    {
        private readonly IWxMP_AuthorizeService _tokenService;

        public WxMP_TmplMsgService(
            IWxMP_AuthorizeService tokenService)
        {
            _tokenService = tokenService;
        }
        public async Task<ServiceResult<CommonResultStateOutput>> Send(WxMP_TmplMsgInput input)
        {
            try
            {
                input.CheckNull(nameof(WxMP_KfMsgTextMsgInput));
                input.guid.CheckEmpty(nameof(input.guid));
                input.openid.CheckEmpty(nameof(input.openid));
                input.first.value.CheckEmpty(nameof(input.first));
                input.remark.value.CheckEmpty(nameof(input.remark));

                var token = _tokenService.GetAccessToken(new WxMP_AuthorizeAccessTokenInput { guid = input.guid });
                if (token.code != 200)
                {
                    return ServiceResult<CommonResultStateOutput>.Failed(StatusCodes.Status400BadRequest, token.msg);
                }
                var msg = new WxMP_TemplateMessage();
                msg.touser = input.openid;
                msg.template_id = input.template_id;
                msg.url = "http://www.baidu.com";
                if (input.miniprogram != null)
                {
                    msg.miniprogram = new WxMP_TemplateMessageMiniProgram
                    {
                        appid = input.miniprogram.appid,
                        pagepath = input.miniprogram.pagepath
                    };
                }
                msg.data.first.value = input.first.value;
                msg.data.first.color = input.first.color;
                #region keyword1-6
                if (input.items.Count > 0)
                {
                    msg.data.keyword1 = new WxMP_TemplateMessageDataItem
                    {
                        value = input.items[0].value,
                        color = input.items[0].color
                    };
                }
                if (input.items.Count > 1)
                {
                    msg.data.keyword2 = new WxMP_TemplateMessageDataItem
                    {
                        value = input.items[1].value,
                        color = input.items[1].color
                    };
                }
                if (input.items.Count > 2)
                {
                    msg.data.keyword3 = new WxMP_TemplateMessageDataItem
                    {
                        value = input.items[2].value,
                        color = input.items[2].color
                    };
                }
                if (input.items.Count > 3)
                {
                    msg.data.keyword4 = new WxMP_TemplateMessageDataItem
                    {
                        value = input.items[3].value,
                        color = input.items[3].color
                    };
                }
                if (input.items.Count > 4)
                {
                    msg.data.keyword5 = new WxMP_TemplateMessageDataItem
                    {
                        value = input.items[4].value,
                        color = input.items[4].color
                    };
                }
                if (input.items.Count > 5)
                {
                    msg.data.keyword6 = new WxMP_TemplateMessageDataItem
                    {
                        value = input.items[5].value,
                        color = input.items[5].color
                    };
                }
                #endregion

                msg.data.remark.value = input.remark.value;
                msg.data.remark.color = input.remark.color;
                var result = await WxMPContext.MessageAPI.SendTmplMessage(token.data.access_token, msg);
                if (result.errcode != 0)
                {
                    return ServiceResult<CommonResultStateOutput>.Failed(StatusCodes.Status400BadRequest, $"{result.errcode}:{result.errmsg}");
                }
                return ServiceResult<CommonResultStateOutput>.Success(new CommonResultStateOutput { result_state = result.errmsg });
            }
            catch (Exception ex)
            {
                return ServiceResult<CommonResultStateOutput>.Exception(ex.Message);
            }
        }
    }
}
