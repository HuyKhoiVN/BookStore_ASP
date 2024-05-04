using Books.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data.Profiles.Dtos
{
    [Table("Authors")]
    public class AuthorDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        [MaxLength(255)]
        public string? FullName { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
