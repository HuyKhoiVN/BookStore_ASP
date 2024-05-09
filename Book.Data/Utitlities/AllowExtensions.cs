using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Utitlities
{
#pragma warning disable CS8603
#pragma warning disable CS8765
    public class AllowExtensions : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowExtensions(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage());
                } 
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"This photo extension is not allowed!";
        }
    }
}
