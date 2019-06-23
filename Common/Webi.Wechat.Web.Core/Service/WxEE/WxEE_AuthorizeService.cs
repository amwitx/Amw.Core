using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Webi.Core.SDK;
using Webi.Wechat.SDK;
using Webi.Wechat.SDK.Enums;
using Webi.Wechat.SDK.Models.WxEE;
using Webi.Wechat.Web.Core.IService.WxEE;
using Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB;
using Webi.Wechat.Web.Core.Models.WxEE;

namespace Webi.Wechat.Web.Core.Service.WxEE
{
    public class WxEE_AuthorizeService : WxEE_BaseService, IWxEE_AuthorizeService
    {
        private readonly OLS_MiddlewareDBContext _middleDB;

        public WxEE_AuthorizeService(OLS_MiddlewareDBContext middleDB)
        {
            _middleDB = middleDB;
        }

        private object lock_token = new object();

        /// <summary>
        /// 获取授权地址
        /// </summary>
        public ServiceResult<string> GetAuthUrl(int weid, string url)
        {
            if (weid <= 0 || string.IsNullOrWhiteSpace(url))
            {
                return ServiceResult<string>.Failed(StatusCodes.Status400BadRequest, "参数不可为空");
            }
            var wechat = _middleDB.WechatEeappConfig.FirstOrDefault(w => w.Id == weid);
            //第一步 获取静默授权code
            var authUrl = WxEEContext.AuthAPI.GenerateAuthorizeLink(
                wechat.CorpId,
               $"{wechat.AuthDomain}/ee_oauth/authorize",
                WxEE_OAuthScopeType.snsapi_privateinfo,
                wechat.AgentId,
                HttpUtility.UrlEncode(weid + "|" + url));
            return ServiceResult<string>.Success(authUrl);
        }

        /// <summary>
        /// 授权用户信息
        /// </summary>
        public async Task<ServiceResult<string>> AuthorizeUserinfo(string code, string state)
        {
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(state))
            {
                return ServiceResult<string>.Failed(StatusCodes.Status400BadRequest, "无效授权");
            }
            //验证参数
            var ids = state.Split('|');
            var weid = ids[0].ToInt();
            if (ids.Length > 1 && weid <= 0)
            {
                return ServiceResult<string>.Failed(StatusCodes.Status400BadRequest, "无效授权");
            }
            var returnUrl = ids[1];
            try
            {
                //读取微信配置
                var wechat = _middleDB.WechatEeappConfig.FirstOrDefault(w => w.Id == weid);
                if (wechat == null)
                {
                    return ServiceResult<string>.Failed(StatusCodes.Status404NotFound, "微信配置无效");
                }
                //获取授权access_token
                var access_token = GetAccessToken(new WxEE_AuthorizeAccessTokenInput { guid = wechat.Guid });
                //code转换用户信息
                var userinfo = await WxEEContext.UserApi.GetUserinfo(
                    access_token.data.access_token,
                    code);

                if (userinfo.errcode != 0)
                {
                    return ServiceResult<string>.Failed(StatusCodes.Status401Unauthorized, userinfo.errmsg);
                }

                //企业微信用户
                var wechatUser = _middleDB.WechatEeappUser.FirstOrDefault(w => w.UserId == userinfo.UserId);
                //用户已授权
                if (wechatUser != null)
                {
                    await UpdateUser(wechatUser.UserId, access_token.data.access_token);
                    returnUrl = $"{returnUrl}{(returnUrl.Contains("?") ? "&" : "?")}eeid={wechatUser.Guid}";
                    return ServiceResult<string>.Success(returnUrl);
                }
                //保存信息
                var eeUser = await CreateUser(weid, userinfo.DeviceId, userinfo.UserId, access_token.data.access_token);
                returnUrl = $"{returnUrl}{(returnUrl.Contains("?") ? "&" : "?")}eeid={eeUser.Guid}";
                return ServiceResult<string>.Success(returnUrl);
            }
            catch (Exception ex)
            {
                return ServiceResult<string>.Exception(ex.Message);
            }
        }

        private async Task UpdateUser(string userId, string access_token)
        {
            //查询
            var first = _middleDB.WechatEeappUser.FirstOrDefault(w => w.UserId == userId);
            //理论上不会出现找到的情况
            if (first != null)
            {
                //每天更新一次
                if (DateTime.Now < (first.UpdateTime ?? DateTime.Now).AddDays(1))
                {
                    return;
                }
                //获取通讯录
                var userGet = await WxEEContext.UserApi.GetContactUser(access_token, userId);
                if (userGet.errcode != 0) { return; }
                //更新
                first.Name = userGet.name;
                //修改岗位
                first.Position = userGet.position;
                first.Mobile = userGet.mobile;
                first.Gender = userGet.gender == 1;
                first.Email = userGet.email;
                first.Avatar = userGet.avatar;
                first.QrCode = userGet.qr_code;
                first.UpdateTime = DateTime.Now;
                if (string.IsNullOrEmpty(first.Openid))
                {
                    //转OpenId
                    var convert = await WxEEContext.UserApi.UserIdToOpenId(access_token, userId);
                    first.Openid = convert.errcode == 0 ? convert.openid : convert.errmsg;
                }
            }
            await _middleDB.SaveChangesAsync();
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        private async Task<WechatEeappUser> CreateUser(int weid, string device_id, string userId, string access_token)
        {
            //获取通讯录
            var user = await WxEEContext.UserApi.GetContactUser(access_token, userId);
            if (user.errcode != 0) { return new WechatEeappUser(); }

            bool? gender = null;
            if (user.gender == 1)
            {
                gender = true;
            }
            else if (user.gender == 2)
            {
                gender = false;
            }
            //查询
            var first = _middleDB.WechatEeappUser.FirstOrDefault(w => w.UserId == user.userid);
            //理论上不会出现找到的情况
            if (first != null)
            {
                //更新
                first.DeviceId = device_id;
                first.Name = user.name;
                first.Mobile = user.mobile;
                first.Gender = gender;
                first.Email = user.email;
                first.Avatar = user.avatar;
                first.QrCode = user.qr_code;
            }
            else
            {
                first = new WechatEeappUser
                {
                    Guid = Guid.NewGuid(),
                    WxeeId = weid,
                    UserId = user.userid,
                    DeviceId = device_id,
                    Name = user.name,
                    Mobile = user.mobile,
                    Position = user.position,
                    Gender = gender,
                    Email = user.email,
                    Avatar = user.avatar,
                    QrCode = user.qr_code,
                    CreateTime = DateTime.Now
                };
                //转OpenId
                var convert = await WxEEContext.UserApi.UserIdToOpenId(access_token, first.UserId);
                first.Openid = convert.errcode == 0 ? convert.openid : convert.errmsg;
                //创建
                _middleDB.WechatEeappUser.Add(first);
            }
            await _middleDB.SaveChangesAsync();
            return first;
        }

        /// <summary>
        /// 获取企业微信应用配置
        /// </summary>
        public ServiceResult<WxEE_AuthorizeAccessTokenOutput> GetAccessToken(WxEE_AuthorizeAccessTokenInput input)
        {
            input.CheckNull(nameof(WxEE_AuthorizeAccessTokenInput));

            var result = new ServiceResult<WxEE_AuthorizeAccessTokenOutput>();
            result.data = new WxEE_AuthorizeAccessTokenOutput();
            WechatEeappConfig wechatEEAppConfig = null;
            //微信配置
            if (input.aid == 0)
            {
                input.guid.CheckEmpty(nameof(input.guid));
                wechatEEAppConfig = _middleDB.WechatEeappConfig.FirstOrDefault(w => w.Guid == input.guid);
            }
            else
            {
                wechatEEAppConfig = _middleDB.WechatEeappConfig.FirstOrDefault(w => w.Id == input.aid);
            }
            if (wechatEEAppConfig == null)
            {
                return ServiceResult<WxEE_AuthorizeAccessTokenOutput>.Failed(StatusCodes.Status404NotFound, "企业微信应用配置获取失败，请联系系统客服");
            }
            //过期时间
            if (!string.IsNullOrEmpty(wechatEEAppConfig.AccessToken) &&
                DateTime.Now < (wechatEEAppConfig.TokenExpireTime ?? DateTime.Now.AddMinutes(-1)))
            {
                result.data.access_token = wechatEEAppConfig.AccessToken;
                result.data.expire_stamp = new DateTimeOffset(wechatEEAppConfig.TokenExpireTime.Value).ToUnixTimeMilliseconds();
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
                            //从企业微信获取
                            var token = WxEEContext.BaseAPI.GetAccessToken(wechatEEAppConfig.CorpId, wechatEEAppConfig.Secret);
                            if (token.errcode != 0)
                            {
                                result.data.access_token = token.errmsg;
                                return result;
                            }
                            //修改
                            wechatEEAppConfig.AccessToken = token.access_token;
                            wechatEEAppConfig.TokenExpireTime = DateTime.Now.AddMinutes(90);
                            _middleDB.SaveChanges();

                            result.data.access_token = token.access_token;
                            result.data.expire_stamp = new DateTimeOffset(wechatEEAppConfig.TokenExpireTime.Value).ToUnixTimeMilliseconds();
                        }
                    }
                }
            }
            return result;
        }
    }
}