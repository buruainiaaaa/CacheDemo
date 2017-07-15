using EFDomain.RedisCache;
using Service.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateOrderQueue queue = new CreateOrderQueue();
            queue.CreateOrder();
            Console.ReadLine();
        }
    }
}
