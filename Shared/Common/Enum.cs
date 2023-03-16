using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTHApplication.Shared.Common
{
    public enum Status
    {
        Ordered,
        Preparing,
        Delivering,
        Received,
        Done
    }

    public enum Role
    {
        Admin,
        Manager,
        Seller,
        User,
        Guest
    }
}
