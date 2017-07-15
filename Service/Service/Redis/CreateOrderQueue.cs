using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Service.Redis
{
    public class CreateOrderQueue
    {
        private int ThreadCount = 50;

        public void CreateOrder() {
            for (int i = 0; i < 1; i++)
            {
                Thread thread = new Thread(new ThreadStart(QueueList));
                thread.Start();
            }
        }
        public void QueueList()
        {
            RedisOrderMessage redis = new RedisOrderMessage();
            while (true)
            {
                try
                {
                    //if (redis.Count() <= 0)
                    //{
                    //    Console.WriteLine("无订单，休息1000毫秒");
                    //    Thread.Sleep(1000);
                    //    continue;
                    //}
                    var cacheOrder = redis.Pop();
                    if (cacheOrder == null)
                    {
                        Console.WriteLine("无订单，休息100毫秒");
                        Thread.Sleep(1000);
                        continue;
                    }

                    while (ThreadCount<=0)
                    {
                        Thread.Sleep(100);
                    }
                    ThreadCount--;
                    Thread thread = new Thread(new ThreadStart(cacheOrder.CreateOrder));
                    thread.Start();
                    Console.WriteLine("正在处理订单，休息100毫秒");
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "," + ex.StackTrace);
                    Thread.Sleep(1000);
                }
                finally
                {
                    ThreadCount++;
                }

            }
        }
    }
}
