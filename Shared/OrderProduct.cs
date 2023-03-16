using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTHApplication.Shared
{
    public class OrderProduct
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = new Product();
        public Order Order { get; set; } = new Order();
    }
}
