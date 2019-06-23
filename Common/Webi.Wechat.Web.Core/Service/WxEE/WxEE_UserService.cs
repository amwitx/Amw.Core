using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webi.Core.SDK;
using Webi.Wechat.Web.Core.IService.WxEE;
using Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB;
using Webi.Wechat.Web.Core.Models.WxEE;

namespace Webi.Wechat.Web.Core.Service.WxEE
{
    public class WxEE_UserService : WxEE_BaseService, IWxEE_UserService
    {
        private readonly OLS_MiddlewareDBContext _middleDB;

        public WxEE_UserService(OLS_MiddlewareDBContext middleDB)
        {
            _middleDB = middleDB;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ServiceResult<WXEE_UserGetOutput> GetUser(WXEE_UserGetInput input)
        {
            input.CheckNull(nameof(WXEE_UserGetInput));
            input.userid.MutualCheckEmpty(input.guid, $"{nameof(input.userid)}|{nameof(input.guid)}");

            var result = new ServiceResult<WXEE_UserGetOutput>();

            //用户
            var guid = new Guid();
            Guid.TryParse(input.guid, out guid);
            var user = _middleDB.WechatEeappUser.FirstOrDefault(w => w.UserId == input.userid || w.Guid == guid);
            if (user == null)
            {
                return ServiceResult<WXEE_UserGetOutput>.Failed(StatusCodes.Status404NotFound, "用户不存在");
            }
            result.data = new WXEE_UserGetOutput
            {
                guid=user.Guid,
                userid = user.UserId,
                openid = user.Openid,
                name = user.Name,
                gender = user.Gender,
                email = user.Email,
                position = user.Position,
                avatar = user.Avatar,
                qr_code = user.QrCode
            };
            return result;
        }
    }
}
