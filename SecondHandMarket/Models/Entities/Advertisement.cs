using SecondHandMarket.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandMarket.Models
{
    public class Advertisement
    {
        //public Advertisement()
        //{
        //    Pictures = new HashSet<Picture>();
        //}
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Display(Name ="Rubrik")]
        [Required(ErrorMessage = "Skriv en rubrik")]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        [Display(Name ="Beskrivning")]
        [Required(ErrorMessage = "Skriv en annonstext")]
        public string Description { get; set; }
        [Display(Name = "Pris")]
        [Required(ErrorMessage = "Du måste ange ett pris")]
        public int Price { get; set; }
        public DateTime PublishDate { get; set; }
        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Välj en kategori")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public  ICollection<Picture> Pictures { get; set; } //virtual
        //TODO ändra till bara en picture från början? 0 eller 1 int? picId eller som nu 0 eller många, Se källan...
        public ICollection<AdvertisementProperty> AdvertisementProperties { get; set; }
        public ICollection<CategoryProperty> CategoryProperties { get; set; }
        [Display(Name = "Plats")]
        [Required(ErrorMessage = "Välj en plats")]
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
