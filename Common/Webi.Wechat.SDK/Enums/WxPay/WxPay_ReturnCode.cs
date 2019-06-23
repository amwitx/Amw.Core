namespace Webi.Wechat.SDK.Enums
{
    public enum WxPay_ReturnCode
    {
        //SUCCESS/FAIL
        //此字段是通信标识，非交易标识，交易是否成功需要查看result_code来判断
        /// <summary>
        /// 成功
        /// </summary>
        SUCCESS,

        /// <summary>
        /// 失败
        /// </summary>
        FAIL,

        //详细错误
        /// <summary>
        /// 商户无此接口权限    商户未开通此接口权限  请商户前往申请此接口权限
        /// </summary>
        NOAUTH,

        /// <summary>
        /// 余额不足    用户帐号余额不足    用户帐号余额不足，请用户充值或更换支付卡后再支付
        /// </summary>
        NOTENOUGH,

        /// <summary>
        /// 商户订单已支付 商户订单已支付，无需重复操作  商户订单已支付，无需更多操作
        /// </summary>
        ORDERPAID,

        /// <summary>
        /// 订单已关闭   当前订单已关闭，无法支付    当前订单已关闭，请重新下单
        /// </summary>
        ORDERCLOSED,

        /// <summary>
        /// 系统错误    系统超时    系统异常，请用相同参数重新调用
        /// </summary>
        SYSTEMERROR,

        /// <summary>
        /// APPID不存在    参数中缺少APPID  请检查APPID是否正确
        /// </summary>
        APPID_NOT_EXIST,

        /// <summary>
        /// MCHID不存在    参数中缺少MCHID  请检查MCHID是否正确
        /// </summary>
        MCHID_NOT_EXIST,

        /// <summary>
        /// appid和mch_id不匹配 appid和mch_id不匹配 请确认appid和mch_id是否匹配
        /// </summary>
        APPID_MCHID_NOT_MATCH,

        /// <summary>
        /// 缺少参数    缺少必要的请求参数   请检查参数是否齐全
        /// </summary>
        LACK_PARAMS,

        /// <summary>
        /// 商户订单号重复 同一笔交易不能多次提交 请核实商户订单号是否重复提交
        /// </summary>
        OUT_TRADE_NO_USED,

        /// <summary>
        /// 签名错误    参数签名结果不正确   请检查签名参数和方法是否都符合签名算法要求
        /// </summary>
        SIGNERROR,

        /// <summary>
        /// XML格式错误 XML格式错误 请检查XML参数格式是否正确
        /// </summary>
        XML_FORMAT_ERROR,

        /// <summary>
        /// 请使用post方法   未使用post传递参数     请检查请求参数是否通过post方法提交
        /// </summary>
        REQUIRE_POST_METHOD,

        /// <summary>
        /// post数据为空    post数据不能为空  请检查post数据是否为空
        /// </summary>
        POST_DATA_EMPTY,

        /// <summary>
        /// 编码格式错误  未使用指定编码格式   请使用UTF-8编码格式
        /// </summary>
        NOT_UTF8
    }
}