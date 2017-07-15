using EFDomain.RedisCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EFDomain.Model;


namespace EFDomain.Service
{
    public class RedisOrderModel
    {
        public string OrderNo { get; set; }

        public int ProductId { get; set; }

        public int Count { get; set; }

        public void CreateOrder()
        {
            try
            {
                 using (ECContext context = new ECContext())
            {
                Console.WriteLine("开始生成订单");
                RedisProduct caceh = new RedisProduct();
                var product = context.Product.FirstOrDefault(p => p.Id == ProductId);
               
                Thread.Sleep(5000);
                //var cacheProduct = caceh.Get(product.Id.ToString());
                Order model = new Order()
                {
                    Id = Guid.NewGuid().ToString(),
                    CreateTime = DateTime.Now,
                    OrderNo = OrderNo,
                    OrderItem = new List<OrderItem>(),
                };
                model.OrderItem.Add(new OrderItem() { Count = Count, Id = Guid.NewGuid().ToString(), Product = product, Order = model });
                //if (cacheProduct.Count <= Count)
                //{
                //    throw new Exception("库存不足");
                //}
                caceh.LockStore(product.Id.ToString(), Count);
                context.Order.Add(model);
                context.SaveChanges();
                //cacheProduct.Count -= Count;
                //caceh.UpdateCache(product.Id.ToString(), cacheProduct);
               
                Console.WriteLine("下单完成");
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+","+ex.StackTrace);
            }

        }

    }
}
