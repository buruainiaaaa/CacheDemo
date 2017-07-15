using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCode.Redis
{
    /// <summary>
    /// 消息队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ReidsMessageQueueObject<T> : IRedisClient
    {
        protected virtual bool IsTran { get; set; }

        protected virtual string MessageQueueType { get; set; }

        /// <summary>
        /// 将指定的值插入到存储在键的列表尾部
        /// </summary>
        /// <param name="key"></param>
        /// <param name="t"></param>
        private void Push(string key, T t)
        {
            var redisConfig = ReadRedisConfig.GetRedisConfig(DB_Name);
            var lockdb = redisConfig.GetDatabase(-1);
            var db = redisConfig.GetDatabase();
            var keyInfo = AddSysCustomKey(key);
            if (IsTran)
            {
                var token = Environment.MachineName;
                if (lockdb.LockTake(keyInfo, token, TimeSpan.FromSeconds(20)))
                {
                    try
                    {
                        db.ListRightPush(keyInfo, ConvertJson(t));
                    }
                    finally
                    {
                        lockdb.LockRelease(keyInfo, token);
                    }
                }
            }
            else
            {
                db.ListRightPush(keyInfo, ConvertJson(t));
            }

        }
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="t"></param>
        public void Push(T t)
        {
            Push(MessageQueueType, t);
        }
        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            var keyInfo = AddSysCustomKey(MessageQueueType);
            var redisConfig = ReadRedisConfig.GetRedisConfig(DB_Name);
            var lockdb = redisConfig.GetDatabase(-1);
            var db = redisConfig.GetDatabase();
            if (IsTran)
            {
                var token = Environment.MachineName;
                if (lockdb.LockTake(keyInfo, token, TimeSpan.FromSeconds(20)))
                {
                    try
                    {
                        var json = db.ListLeftPop(keyInfo);
                        if (json==default(RedisValue))
                        {
                            return default(T);
                        }
                        return ConvertObj<T>(json);
                    }
                    finally
                    {
                        lockdb.LockRelease(keyInfo, token);
                    }
                }
                return default(T);
            }
            else
            {
                var json = db.ListLeftPop(keyInfo);
                if (json == default(RedisValue))
                {
                    return default(T);
                }
                return ConvertObj<T>(json);
            }
        }

        /// <summary>
        /// 数量
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            var redisConfig = ReadRedisConfig.GetRedisConfig(DB_Name);
            var db = redisConfig.GetDatabase();
            var keyInfo = AddSysCustomKey(MessageQueueType);
            var l = db.ListLength(keyInfo);

            return Convert.ToInt32(l);
        }
        
    }
}
