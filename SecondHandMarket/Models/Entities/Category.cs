using SecondHandMarket.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandMarket.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
        public int MainCategoryId { get; set; }

        public ICollection<CategoryProperty> CategoryProperties { get; set; }
    }
}
