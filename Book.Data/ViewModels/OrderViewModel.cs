using Books.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data.ViewModels
{
    public class OrderViewModel
    {
        public OrderHeader OrderHeader { get; set; } = new();
        public IEnumerable<OrderDetail>? OrderDetail { get; set; }
    }
}
