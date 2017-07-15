using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCode.Redis
{
    public abstract class IRedisClient
    {
        protected virtual string DB_Name { get; set; }
        protected string AddSysCustomKey(string oldKey)
        {
            return oldKey;
        }
        protected string ConvertJson<T>(T value)
        {
            string result = value is string ? value.ToString() : JsonConvert.SerializeObject(value);
            return result;
        }
        protected T ConvertObj<T>(string json)
        {
            T t = string.IsNullOrEmpty(json) ? default(T) : JsonConvert.DeserializeObject<T>(json);
            return t;
        }
        protected T ConvertObj<T>(RedisValue value)
        {
            if (value.IsNullOrEmpty)
                return default(T);
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
