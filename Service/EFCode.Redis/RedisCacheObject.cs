using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCode.Redis
{
    /// <summary>
    /// 缓存单个对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RedisCacheObject<T> : IRedisClient
    {

        public void Insert<T>(string key, T t, TimeSpan? span = default(TimeSpan?))
        {
            key = AddSysCustomKey(key);
            string json = ConvertJson(t);

            var redisConfig = ReadRedisConfig.GetRedisConfig(DB_Name);
            var db = redisConfig.GetDatabase();
            db.StringSet(key, json, span);
        }
        public T Get(string key)
        {
            key = AddSysCustomKey(key);

            var redisConfig = ReadRedisConfig.GetRedisConfig(DB_Name);
            var db = redisConfig.GetDatabase();

            return ConvertObj<T>(db.StringGet(key));
        }
        public void Remove(string key)
        {
            key = AddSysCustomKey(key);

            var redisConfig = ReadRedisConfig.GetRedisConfig(DB_Name);
            var db = redisConfig.GetDatabase();
            db.KeyDelete(key);
        }
        public bool Exists(string key)
        {
            key = AddSysCustomKey(key);

            var redisConfig = ReadRedisConfig.GetRedisConfig(DB_Name);
            var db = redisConfig.GetDatabase();
            return db.KeyExists(key);
        }


    }
}
