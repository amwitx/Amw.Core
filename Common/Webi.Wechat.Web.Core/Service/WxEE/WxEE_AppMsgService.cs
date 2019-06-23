using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using Webi.Core.SDK;
using Webi.Wechat.SDK;
using Webi.Wechat.SDK.Models.WxEE.PushMessage;
using Webi.Wechat.Web.Core.IService.WxEE;
using Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB;
using Webi.Wechat.Web.Core.Models.WxEE;

namespace Webi.Wechat.Web.Core.Service.WxEE
{
    public class WxEE_AppMsgService : WxEE_BaseService, IWxEE_AppMsgService
    {
        private readonly OLS_MiddlewareDBContext _middleDB;
        private readonly IWxEE_AuthorizeService _tokenService;

        public WxEE_AppMsgService(OLS_MiddlewareDBContext middleDB, IWxEE_AuthorizeService tokenService)
        {
            _middleDB = middleDB;
            _tokenService = tokenService;
        }

        /// <summary>
        /// 发送应用文本消息
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResult<WxEE_AppMsgTextMsgOutput>> PushTextMessage(WxEE_AppMsgTextMsgInput input)
        {
            input.CheckNull(nameof(WxEE_AppMsgTextMsgInput));
            input.guid.CheckEmpty(nameof(input.guid));
            input.userid.CheckEmpty(nameof(input.userid));
            input.content.CheckEmpty(nameof(input.content));

            //读取配置
            var wechatEEApp = _middleDB.WechatEeappConfig.FirstOrDefault(w => w.Guid == input.guid);
            if (wechatEEApp == null)
            {
                return ServiceResult<WxEE_AppMsgTextMsgOutput>.Failed(StatusCodes.Status404NotFound, "微信配置获取失败，请联系系统客服");
            }
            var token = _tokenService.GetAccessToken(new WxEE_AuthorizeAccessTokenInput { guid = input.guid });
            var text = new WxEE_PushAppTextMessage();
            text.agentid = wechatEEApp.AgentId;
            text.touser = input.userid;
            text.text.content = input.content;
            //发送
            var result = await WxEEContext.PushAppMessageAPI.SendAppMessage(token.data.access_token, text);
            return ServiceResult<WxEE_AppMsgTextMsgOutput>.Success(new WxEE_AppMsgTextMsgOutput { invaliduser = result.invaliduser });
        }

        /// <summary>
        /// 发送应用文本卡片消息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ServiceResult<WxEE_AppMsgTextMsgOutput>> PushTextCardMessage(WxEE_AppMsgTextCardMsgInput input)
        {
            input.CheckNull(nameof(WxEE_AppMsgTextCardMsgInput));
            input.guid.CheckEmpty(nameof(input.guid));
            input.userid.CheckEmpty(nameof(input.userid));
            input.title.CheckEmpty(nameof(input.title));
            input.description.CheckEmpty(nameof(input.description));
            input.url.CheckEmpty(nameof(input.url));

            //读取配置
            var wechatEEApp = _middleDB.WechatEeappConfig.FirstOrDefault(w => w.Guid == input.guid);
            if (wechatEEApp == null)
            {
                return ServiceResult<WxEE_AppMsgTextMsgOutput>.Failed(StatusCodes.Status404NotFound, "微信配置获取失败，请联系系统客服");
            }
            var token = _tokenService.GetAccessToken(new WxEE_AuthorizeAccessTokenInput { guid = input.guid });
            var requestObj = new WxEE_PushAppTextcardMessage();
            requestObj.agentid = wechatEEApp.AgentId;
            requestObj.touser = input.userid;
            requestObj.textcard.title = input.title;
            requestObj.textcard.description = input.description;
            requestObj.textcard.url = input.url;
            requestObj.textcard.btntxt = input.btn_text;
            //发送
            var result = await WxEEContext.PushAppMessageAPI.SendAppMessage(token.data.access_token, requestObj);
            return ServiceResult<WxEE_AppMsgTextMsgOutput>.Success(new WxEE_AppMsgTextMsgOutput { invaliduser = result.invaliduser });
        }
    }
}