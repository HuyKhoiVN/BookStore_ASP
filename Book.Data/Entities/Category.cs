﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100!")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
