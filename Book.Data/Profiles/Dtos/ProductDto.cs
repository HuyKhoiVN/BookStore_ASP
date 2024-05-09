using Books.Domain.Entities;
using Books.Domain.Utitlities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Profiles.Dtos
{
    public class ProductDto
    {
        [Required]
        [MaxLength(50)]
        public string? Tittle { get; set; }

        [Required]
        public string? ISBN { get; set; }

        public string? Description { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }

        [MaxFileSize(5 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is 5 MB")]
        [AllowExtensions(new string[] { ".png", ".jpg", ".jpeg", ".svg" })]
        [DataType(DataType.Upload)]
        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }

        [Required]
        [Display(Name = "Cover")]
        public int CoverId { get; set; }
        public Cover? Cover { get; set; }

        [Range(0, 100)]
        public int InStock { get; set; }
    }
}
