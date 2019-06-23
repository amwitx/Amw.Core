using System;
using System.Collections.Generic;
using System.Text;
using Webi.Wechat.SDK.Enums.WxEE;

namespace Webi.Wechat.SDK.Models.WxEE.PushMessage
{
    /// <summary>
    /// markdown消息
    /// 目前仅支持markdown语法的子集
    /// 微工作台（原企业号）不支持展示markdown消息
    /// </summary>
    public class WxEE_PushAppMarkdownMessage : WxEE_PushAppBaseMessage
    {
        public WxEE_PushAppMarkdownMessage()
        {
            base.msgtype = WxEE_PushMessageType.markdown.ToString();
            markdown = new WxEE_PushAppMarkdownMessageItem();
        }
        public WxEE_PushAppMarkdownMessageItem markdown { get; set; }
    }
    public class WxEE_PushAppMarkdownMessageItem
    {
        public string content { get; set; }
    }
}
/* 
支持的markdown语法
目前应用消息中支持的markdown语法是如下的子集：

标题 （支持1至6级标题，注意#与文字中间要有空格）
# 标题一
## 标题二
### 标题三
#### 标题四
##### 标题五
###### 标题六

加粗
**bold**

链接
[这是一个链接](http://work.weixin.qq.com/api/doc)

行内代码段（暂不支持跨行）
`code`

引用
> 引用文字

字体颜色(只支持3种内置颜色)
<font color="info">绿色</font>
<font color="comment">灰色</font>
<font color="warning">橙红色</font>
*/
