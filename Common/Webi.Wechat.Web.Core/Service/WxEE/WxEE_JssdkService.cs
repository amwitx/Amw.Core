using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net;
using Webi.Core.SDK;
using Webi.Wechat.SDK;
using Webi.Wechat.Web.Core.IService.WxEE;
using Webi.Wechat.Web.Core.IService.WxEE;
using Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB;
using Webi.Wechat.Web.Core.Models.WxEE;

namespace Webi.Wechat.Web.Core.Service.WxEE
{
    public class WxEE_JssdkService : WxEE_BaseService, IWxEE_JssdkService
    {
        private readonly OLS_MiddlewareDBContext _middleDB;
        private readonly IWxEE_AuthorizeService _configService;

        public WxEE_JssdkService(
            OLS_MiddlewareDBContext middleDB,
            IWxEE_AuthorizeService configService)
        {
            _middleDB = middleDB;
            _configService = configService;
        }

        private object lock_ticket = new object();

        /// <summary>
        /// 获取jssdk票据
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public ServiceResult<WxEE_JssdkJsapiTicketOutput> GetJsapiTicket(WxEE_JssdkJsapiTicketInput input)
        {
            try
            {
                input.CheckNull(nameof(WxEE_JssdkJsapiTicketInput));
                input.guid.CheckEmpty(nameof(input.guid));
                input.access_token.CheckEmpty(nameof(input.access_token));

                var result = new ServiceResult<WxEE_JssdkJsapiTicketOutput>();
                result.data = new WxEE_JssdkJsapiTicketOutput();
                //NOLOCK
                var wechatConfig = ApplicationContext.EF.WithNolock<WechatEeappConfig>(() =>
                {
                    //微信配置
                    return _middleDB.WechatEeappConfig.FirstOrDefault(w => w.Guid == input.guid);
                });
                if (wechatConfig == null)
                {
                    return ServiceResult<WxEE_JssdkJsapiTicketOutput>.Failed(StatusCodes.Status404NotFound, "微信配置获取失败，请联系系统客服");
                }
                //数据库中
                if (!string.IsNullOrEmpty(wechatConfig.JssdkTicket) &&
                    DateTime.Now < (wechatConfig.JssdkTicketExpireTime ?? DateTime.Now.AddMinutes(-1)))
                {
                    result.data.jsapi_ticket = wechatConfig.JssdkTicket;
                }
                else
                {
                    //双重验证
                    if (string.IsNullOrEmpty(result.data.jsapi_ticket))
                    {
                        lock (lock_ticket)
                        {
                            if (string.IsNullOrEmpty(result.data.jsapi_ticket))
                            {
                                //从微信获取
                                var ticket = WxEEContext.JsApi.GetTicket(input.access_token);
                                //修改
                                wechatConfig.JssdkTicket = ticket.ticket;
                                wechatConfig.JssdkTicketExpireTime = DateTime.Now.AddMinutes(60);
                                _middleDB.SaveChanges();

                                result.data.jsapi_ticket = ticket.ticket;
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return ServiceResult<WxEE_JssdkJsapiTicketOutput>.Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取jssdk配置
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public ServiceResult<WxEE_JssdkConfigOutput> GetConfig(WxEE_JssdkConfigInput input)
        {
            try
            {
                input.CheckNull(nameof(WxEE_JssdkConfigInput));
                input.guid.CheckEmpty(nameof(input.guid));
                input.url.CheckEmpty(nameof(input.url));

                var config = new WxEE_JssdkConfigOutput();
                //时间戳
                config.time_stamp = WxContext.Common.GenerateTimeStamp();
                //随机字符
                config.nonce_str = WxContext.Common.GenerateNonceStr();
                //获取微信配置
                var wechatConfig = _middleDB.WechatEeappConfig.Select(s => new { s.Id, s.Guid, s.CorpId }).FirstOrDefault(w => w.Guid == input.guid);
                config.corpid = wechatConfig.CorpId;
                //token
                var token = _configService.GetAccessToken(new WxEE_AuthorizeAccessTokenInput { guid = wechatConfig.Guid });
                if (token.code != StatusCodes.Status200OK)
                {
                    return ServiceResult<WxEE_JssdkConfigOutput>.Failed(token.code, token.msg);
                }
                //jsapi_ticket
                var ticket = GetJsapiTicket(new WxEE_JssdkJsapiTicketInput { guid = wechatConfig.Guid, access_token = token.data.access_token });
                //signature
                config.signature = WxContext.Common.GenerateSignature(config.time_stamp, config.nonce_str, ticket.data.jsapi_ticket, input.url);
                return ServiceResult<WxEE_JssdkConfigOutput>.Success(config);
            }
            catch (Exception ex)
            {
                return ServiceResult<WxEE_JssdkConfigOutput>.Exception(ex.Message);
            }
        }
    }
}