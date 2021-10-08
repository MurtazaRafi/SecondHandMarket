using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandMarket.Validations
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var files = value as LinkedList<IFormFile>;

                foreach (IFormFile file in files)
                {
                    if (file != null)
                    {
                        var extension = Path.GetExtension(file.FileName);
                        if (!_extensions.Contains(extension.ToLower()))
                        {
                            return new ValidationResult("Du måste ladda upp en bildfil");
                        }
                    }

                }

                if (files.Count > 6)
                {
                    return new ValidationResult("Kan ej ladda upp fler än 6 bilder");
                }
            }
            return ValidationResult.Success;
        }
    }
}
