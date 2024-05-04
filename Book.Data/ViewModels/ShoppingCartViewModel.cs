using Books.Data.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data.ViewModels
{
#pragma warning disable CS8618

    public class ShoppingCartViewModel
    {
        [ValidateNever]
        public IEnumerable<ShopingCart> ShopingCarts { get; set; }

        [ValidateNever]
        public OrderHeader OrderHeader { get; set; }
    }
}
