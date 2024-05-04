﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data.Entities
{
    public class ShopingCart
    {
        public Guid Id { get; set; }

        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }

        public int ProductId { get; set; }

        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 - 1000")]
        public int Count { get; set; }

        public string? ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public double PriceHolder { get; set; }

        [NotMapped]
        public double _priceHolderRabat;

        public double PirceHolderRabat()
        {
            return _priceHolderRabat;
        }

        public double SetPriceHolderRabat(double priceHolderRabat)
        {
            _priceHolderRabat = priceHolderRabat;
            return _priceHolderRabat;
        }
    }
}