using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Webi.Wechat.Web.Core.Models
{
    /// <summary>
    /// 通用返回状态输出对象
    /// </summary>
    public class CommonResultStateOutput
    {
        [Description("结果状态")]
        public string result_state { get; set; }
    }
}
