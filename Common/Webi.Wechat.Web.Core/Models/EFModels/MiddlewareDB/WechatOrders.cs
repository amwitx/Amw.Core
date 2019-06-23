using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class WechatOrders
    {
        public int Id { get; set; }
        public string SourceType { get; set; }
        public string Openid { get; set; }
        public string OutTradeNo { get; set; }
        public string Appid { get; set; }
        public string MchId { get; set; }
        public string Sign { get; set; }
        public string Body { get; set; }
        public int? TotalFee { get; set; }
        public string ProductId { get; set; }
        public string PostXml { get; set; }
        public bool? IsPost { get; set; }
        public string RetResultCode { get; set; }
        public string RetErrCode { get; set; }
        public string RetErrCodeDes { get; set; }
        public string PaySign { get; set; }
        public string PrepayId { get; set; }
        public string TransactionId { get; set; }
        public string ReturnXml { get; set; }
        public bool? IsFinish { get; set; }
        public DateTime? FinishTime { get; set; }
        public bool? IsSuccess { get; set; }
        public string FailMessage { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
