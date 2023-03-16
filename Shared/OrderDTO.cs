using DTHApplication.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTHApplication.Shared
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; } = new DateTime();
        public DateTime? DateOfReceipt { get; set; }
        public string Address { get; set; } = string.Empty;
        public double TotalPrice { get; set; }
        public Status Status { get; set; }
        public List<Guid> ProductIds { get; set; } = new List<Guid>();
    }
}
