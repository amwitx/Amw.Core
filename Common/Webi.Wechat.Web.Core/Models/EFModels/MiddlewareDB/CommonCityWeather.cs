using System;
using System.Collections.Generic;

namespace Webi.Wechat.Web.Core.Models.EFModels.MiddlewareDB
{
    public partial class CommonCityWeather
    {
        public int Id { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public int? Wendu { get; set; }
        public string Weather { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
