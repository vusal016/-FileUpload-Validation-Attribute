using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PustokApp.Attributes
{
    public class FileLengthAttribute : ValidationAttribute
    {   
        private readonly int _maxLength;
        
        public FileLengthAttribute(int maxlength)
        {
            _maxLength = maxlength * 1024 * 1024;
        }
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > _maxLength)
                {
                    return new ValidationResult($"File size must be less than {_maxLength / (1024 * 1024)}MB");
                }
            }
            return ValidationResult.Success;
        }
    }
}
