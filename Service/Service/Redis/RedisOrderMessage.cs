using EFCode.Redis;
using EFDomain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Redis
{
    public class RedisOrderMessage : ReidsMessageQueueObject<RedisOrderModel>
    {
        protected override string MessageQueueType { get { return "Order_Create"; } }
        protected override bool IsTran { get { return true; } }

        protected override string DB_Name { get { return "Order_DBName"; } }

    }
}
