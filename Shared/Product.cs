using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTHApplication.Shared
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool OutOfStock { get; set; }
        public List<Image> ImageURLs { get; set; } = new List<Image>();
        public string Description { get; set; } = string.Empty;
        public Category? Category { get; set; }
        public Guid CategoryId { get; set; }
        public List<OrderProduct> OrderProduct { get; set; } = new List<OrderProduct>();
    }
}
