using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandMarket.Models
{
    public class Advertisement
    {
        public Advertisement()
        {
            Pictures = new HashSet<Picture>();
        }
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime PublishDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }

    }
}
