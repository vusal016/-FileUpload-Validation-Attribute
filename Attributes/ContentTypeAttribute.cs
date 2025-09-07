using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace PustokApp.Attributes
{
    public class ContentTypeAttribute : ValidationAttribute 
    {
        private readonly string[] _allowTypes;
        
        public ContentTypeAttribute(params string[] allowedTypes)
        {
            _allowTypes = allowedTypes; 
        }
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (!_allowTypes.Contains(file.ContentType))
                {
                    return new ValidationResult($"File Type must be one of the following: {string.Join(", ", _allowTypes)}.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
