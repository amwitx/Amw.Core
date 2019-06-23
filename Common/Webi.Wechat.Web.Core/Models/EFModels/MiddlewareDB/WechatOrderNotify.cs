using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WechatOrderNotify
    {
        public int Id { get; set; }
        public string Openid { get; set; }
        public string OutTradeNo { get; set; }
        public string Appid { get; set; }
        public string MchId { get; set; }
        public string Sign { get; set; }
        public string ResultCode { get; set; }
        public string ErrCode { get; set; }
        public string ErrCodeDes { get; set; }
        public bool? IsSubscribe { get; set; }
        public int? TotalFee { get; set; }
        public string TransactionId { get; set; }
        public string NotifyXml { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
