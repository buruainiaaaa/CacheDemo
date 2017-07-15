using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDomain.Model
{
    public class OrderItem
    {
        public string Id { get; set; }

        public Product Product { get; set; }

        public int Count { get; set; }

        public Order Order { get; set; }
    }
}
