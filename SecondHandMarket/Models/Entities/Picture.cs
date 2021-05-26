using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandMarket.Models
{
    public class Picture
    {

        public int Id { get; set; }

        public byte[] PicInByte { get; set; }

        public int AdvertisementId { get; set; }

        public virtual Advertisement Advertisement { get; set; }
    }
}
