using Amw.Core.SDK.Components;

namespace Amw.Core
{
    public class ApplicationContext
    {

        private static JsonHelper _Json = new JsonHelper();

        /// <summary>
        /// json
        /// </summary>
        public static JsonHelper Json
        {
            get { return _Json; }
        }

        private static HttpHelper _Http = new HttpHelper();

        /// <summary>
        /// 模拟http请求
        /// </summary>
        public static HttpHelper Http
        {
            get { return _Http; }
        }

        private static EncryptHelper _Encrypt = new EncryptHelper();

        /// <summary>
        /// 加密
        /// </summary>
        public static EncryptHelper Encrypt
        {
            get { return _Encrypt; }
        }

        private static EFHelper _EF = new EFHelper();

        /// <summary>
        /// Entity Framework
        /// </summary>
        public static EFHelper EF
        {
            get { return _EF; }
        }
        private static ConsulHelper _Consul = new ConsulHelper();

        /// <summary>
        /// Entity Framework
        /// </summary>
        public static ConsulHelper Consul
        {
            get { return _Consul; }
        }
    }
}