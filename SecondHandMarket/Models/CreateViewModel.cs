using Microsoft.AspNetCore.Http;
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
        public IFormFile File { get; set; }
    }
}
