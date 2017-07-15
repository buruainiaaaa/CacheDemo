using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDomain.Model
{
    public class Order
    {
        public string Id { get; set; }

        public string OrderNo { get; set; }

        public DateTime CreateTime { get; set; }

        public List<OrderItem> OrderItem { get; set; }
    }
}
