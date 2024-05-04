using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data.Utitlities
{
    public class MaxFileSize : ValidationAttribute
    {
        private readonly int _maxFielSize;

        public MaxFileSize(int maxFielSize)
        {
            _maxFielSize = maxFielSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if(file.Length > _maxFielSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Max file size is {_maxFielSize} bytes";
        }
    }
}
