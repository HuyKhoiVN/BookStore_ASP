using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Entities
{
    [Table("Author")]
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Full name")]
        [MaxLength(255)]
        public string? FullName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
