using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTHApplication.Shared
{
    public class Image
    {
        public Guid Id { get; set; }
        public bool IsMainImage { get; set; }
        public string URL { get; set; } = string.Empty;
        public Product? Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
