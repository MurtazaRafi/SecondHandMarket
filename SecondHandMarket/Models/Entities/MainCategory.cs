using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandMarket.Models
{
    public class MainCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
