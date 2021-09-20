using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandMarket.Models.Entities
{
    public class SubLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }

    }
}
