using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTHApplication.Shared
{
    public class Category
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new List<Product>();

    }
}
