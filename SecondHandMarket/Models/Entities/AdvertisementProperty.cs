using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandMarket.Models.Entities
{
    public class AdvertisementProperty
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
