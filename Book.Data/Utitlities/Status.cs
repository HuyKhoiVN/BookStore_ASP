using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data.Utitlities
{
    public static class Status
    {
        public enum StatusType
        {
            Pending,
            Approved,
            InProgress,
            Shipped,
            Canceled,
            Refunded
        }

        public enum Payment
        {
            Pending,
            Approved,
            Delayed,
            Rejected
        }
    }
}
