using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using Webi.Core.SDK;
using Webi.Wechat.SDK;
using Webi.Wechat.Web.Core.IService.WxMP;
using Webi.Wechat.Web.Core.Models;
using Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB;
using Webi.Wechat.Web.Core.Models.WxMP;

namespace Webi.Wechat.Web.Core.Service.WxMP
{
    public class WxMP_AuthorizeService : WxMP_BaseService, IWxMP_AuthorizeService
    {
        private readonly OLS_MiddlewareDBContext _middleDB;

        public WxMP_AuthorizeService(OLS_MiddlewareDBContext middleDB)
        {
            _middleDB = middleDB;
        }

        private object lock_token = new object();

        /// <summary>
        /// 获取微信配置
        /// </summary>
        /// <param name="mp_id"></param>
        /// <returns></returns>
        public ServiceResult<WxMP_AuthorizeAccessTokenOutput> GetAccessToken(WxMP_AuthorizeAccessTokenInput input)
        {
            try
            {
                input.CheckNull(nameof(WxMP_AuthorizeAccessTokenInput));

                var result = new ServiceResult<WxMP_AuthorizeAccessTokenOutput>();
                result.data = new WxMP_AuthorizeAccessTokenOutput();
                WechatConfig wechatConfig = null;
                //微信配置
                if (input.wid == 0)
                {
                    input.guid.CheckEmpty(nameof(input.guid));
                    wechatConfig = _middleDB.WechatConfig.FirstOrDefault(w => w.Guid == input.guid);
                }
                else
                {
                    wechatConfig = _middleDB.WechatConfig.FirstOrDefault(w => w.Id == input.wid);
                }
                if (wechatConfig == null)
                {
                    return ServiceResult<WxMP_AuthorizeAccessTokenOutput>.Failed(StatusCodes.Status404NotFound, "微信配置获取失败，请联系系统客服");
                }
                //数据库中
                if (!string.IsNullOrEmpty(wechatConfig.AccessToken) &&
                    DateTime.Now < (wechatConfig.TokenUpdateTime ?? DateTime.Now.AddMinutes(-1)))
                {
                    result.data.access_token = wechatConfig.AccessToken;
                }
                else
                {
                    //双重验证
                    if (string.IsNullOrEmpty(result.data.access_token))
                    {
                        lock (lock_token)
                        {
                            if (string.IsNullOrEmpty(result.data.access_token))
                            {
                                //从微信获取
                                var token = WxMPContext.BaseAPI.GetAccessToken(wechatConfig.AppId, wechatConfig.AppSecret);
                                if (token.errcode != 0)
                                {
                                    result.data.access_token = token.errmsg;
                                    return result;
                                }
                                //修改
                                wechatConfig.Token = token.access_token;
                                wechatConfig.TokenUpdateTime = DateTime.Now.AddMinutes(60);
                                _middleDB.SaveChanges();

                                result.data.access_token = token.access_token;
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return ServiceResult<WxMP_AuthorizeAccessTokenOutput>.Exception(ex.Message);
            }
        }
    }
}