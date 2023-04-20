using DTHApplication.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTHApplication.Shared
{
    public class UserUpdate
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public List<Image> ProfileImages { get; set; } = new List<Image>();
    }
}
