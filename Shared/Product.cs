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
        public List<Image> ImageURL { get; set; } = new List<Image>();
        public string Description { get; set; } = string.Empty;
        public Category? Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
