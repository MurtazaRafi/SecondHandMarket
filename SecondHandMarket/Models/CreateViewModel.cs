using Microsoft.AspNetCore.Http;
using SecondHandMarket.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandMarket.Models
{
    public class CreateViewModel
    {
        public Advertisement Advertisement { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif", "tiff" })]
        public  List<IFormFile> Files { get; set; }
    }
}
