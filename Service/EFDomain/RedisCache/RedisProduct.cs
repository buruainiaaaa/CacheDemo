using EFCode.Redis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFDomain.RedisCache
{
    public class RedisProduct : RedisCacheObject<CacheProduct>
    {

        protected override string DB_Name
        {
            get { return "Product_DbName"; }
        }
        public void UpdateCache(string productId, CacheProduct p)
        {
            this.Remove(productId);
            this.Insert(productId, p);
        }
        /// <summary>
        /// 锁，校验库存，防止库存超卖
        /// </summary>
        /// <param name="product"></param>
        /// <param name="count"></param>
        public void LockStore(string productId, int count)
        {
            var keyInfo = AddSysCustomKey(productId);

            if (!Exists(keyInfo))
            {
                throw new Exception("商品缓存缓存不存在");
            }
            var redisConfig = ReadRedisConfig.GetRedisConfig(DB_Name);
            var lockdb = redisConfig.GetDatabase(-1);
            var db = redisConfig.GetDatabase();
            var token = Environment.MachineName;
            while (true)
            {
                //db.LockRelease(keyInfo, token);
                var con = lockdb.LockTake(keyInfo, token, TimeSpan.FromSeconds(10.0), CommandFlags.None);
                //var con = db.LockTake(keyInfo, token, TimeSpan.FromSeconds(20), CommandFlags.None);
                if (con)
                {
                    try
                    {
                        var product = ConvertObj<CacheProduct>(db.StringGet(keyInfo));
                        if (product.Count < count)
                        {
                            throw new Exception("数量不够，下单失败");
                        }
                        product.Count -= count;
                        var json = ConvertJson(product);
                        db.StringSet(keyInfo, json);
                        
                    }
                    finally
                    {
                        lockdb.LockRelease(keyInfo, token);
                        
                    }
                    break;
                }
            }
           
        }
        //public void LockStore(string lockKey, int count)
        //{
        //    var redisConfig = ReadRedisConfig.GetRedisConfig(DB_Name);

        //    using (ConnectionMultiplexer connectionMultiplexer = redisConfig.Connection)
        //    {
        //        IDatabase database = redisConfig.GetDatabase();// connectionMultiplexer.GetDatabase(-1, null);
        //        RedisValue value = Environment.MachineName;
        //        Console.WriteLine("Start..........");
        //        bool flag = database.LockTake(lockKey, value, TimeSpan.FromSeconds(10.0), CommandFlags.None);
        //        if (flag)
        //        {
        //            try
        //            {
        //                Console.WriteLine("Working..........");
        //                Thread.Sleep(10000);
        //            }
        //            finally
        //            {
        //                database.LockRelease(lockKey, value, CommandFlags.None);
        //            }
        //        }
        //        Console.WriteLine("Over..........");
        //    }

        //    //using (ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379", null))
        //    //{
        //    //    IDatabase database = connectionMultiplexer.GetDatabase(-1, null);
        //    //    RedisValue value = Environment.MachineName;
        //    //    Console.WriteLine("Start..........");
        //    //    bool flag = database.LockTake(lockKey, value, TimeSpan.FromSeconds(10.0), CommandFlags.None);
        //    //    if (flag)
        //    //    {
        //    //        try
        //    //        {
        //    //            Console.WriteLine("Working..........");
        //    //            Thread.Sleep(10000);
        //    //        }
        //    //        finally
        //    //        {
        //    //            database.LockRelease(lockKey, value, CommandFlags.None);
        //    //        }
        //    //    }
        //    //    Console.WriteLine("Over..........");
        //    //}
        //}



    }
}
