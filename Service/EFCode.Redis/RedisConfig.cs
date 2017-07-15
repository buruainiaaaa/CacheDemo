using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCode.Redis
{
    public class RedisConfig
    {
        public RedisConfig(string redisHosts, int num)
        {
            this.RedisHosts = redisHosts;
            this.Num = num;
            GetConnectionMultiplexer();
        }

        public string DbName { get; set; }

        public string RedisHosts { get; set; }

        public int Num { get; set; }

        public ConnectionMultiplexer Connection { get; set; }

        public IDatabase GetDatabase(int? num = null)
        {
            if (Connection != null)
            {
                return Connection.GetDatabase(num.HasValue ? num.Value : Num, null);
            }
            return null;
        }

        private void GetConnectionMultiplexer()
        {
            var connectionString = RedisHosts;

            Connection = ConnectionMultiplexer.Connect(connectionString);
            Connection.ConnectionFailed += Connection_ConnectionFailed;
            Connection.ConnectionRestored += Connection_ConnectionRestored;
            Connection.ErrorMessage += Connection_ErrorMessage;
            Connection.ConfigurationChanged += Connection_ConfigurationChanged;
            Connection.InternalError += Connection_InternalError; ;
        }

        private void Connection_InternalError(object sender, InternalErrorEventArgs e)
        {
            throw new Exception("redis 内部错误" + e.Exception.Message);
        }



        /// <summary>
        /// 当检测到配置更改时提高
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Connection_ConfigurationChanged(object sender, EndPointEventArgs e)
        {
            Console.WriteLine("redis 配置更改");
        }

        /// <summary>
        /// 服务器以错误消息回应;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Connection_ErrorMessage(object sender, RedisErrorEventArgs e)
        {
            throw new Exception(string.Format("redis 异常，{0}", e.Message));
        }

        /// <summary>
        /// 当建立物理连接时就会触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Connection_ConnectionRestored(object sender, ConnectionFailedEventArgs e)
        {
            Console.WriteLine("链接成功");
        }

        /// <summary>
        /// 当物理连接失败时，它会被触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Connection_ConnectionFailed(object sender, ConnectionFailedEventArgs e)
        {
            throw new Exception(e.Exception.Message);
        }

    }
}
