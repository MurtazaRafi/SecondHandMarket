using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandMarket.Models.Entities
{
    public class CategoryProperty
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category{ get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
