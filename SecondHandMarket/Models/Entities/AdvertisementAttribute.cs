using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandMarket.Models
{
    public class AdvertisementAttribute
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
        public int AttributId { get; set; }
        public Attribut Attribute { get; set; }
    }
}
