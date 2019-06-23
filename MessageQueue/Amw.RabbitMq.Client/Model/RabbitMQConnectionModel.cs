using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amw.RabbitMq.Client.Model
{
    /// <summary>
    /// 连接实体类
    /// </summary>
    public class RabbitMQConnectionModel
    {
        /// <summary>
        /// 主机地址
        /// </summary>
        public string HostName { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; } = AmqpTcpEndpoint.UseDefaultPort;
        /// <summary>
        /// 虚机
        /// </summary>
        public string VirtualHost { get; set; } = "/";
        /// <summary>
        /// 协议
        /// </summary>
        public IProtocol Protocol { get; set; } = Protocols.DefaultProtocol;
        /// <summary>
        /// 自动恢复启动
        /// </summary>
        public bool AutomaticRecoveryEnabled { get; set; } = true;
        /// <summary>
        /// 拓扑恢复启动
        /// </summary>
        public bool TopologyRecoveryEnabled { get; set; } = true;

        /// <summary>
        /// 连接实体类
        /// </summary>
        public RabbitMQConnectionModel(string hostName, string userName, string password)
        {
            HostName = hostName;
            UserName = userName;
            Password = password;
        }

        public ConnectionFactory Factory
        {
            get
            {
                return new ConnectionFactory
                {
                    HostName = HostName,
                    UserName = UserName,
                    Password = Password,
                    Port = Port,
                    VirtualHost = VirtualHost,
                    //协议
                    Protocol = Protocol,
                    //自动恢复
                    AutomaticRecoveryEnabled = AutomaticRecoveryEnabled,
                    //拓扑恢复
                    TopologyRecoveryEnabled = TopologyRecoveryEnabled
                };
            }
        }
    }
}
