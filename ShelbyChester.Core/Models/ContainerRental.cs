using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.Models
{
    public  class ContainerRental : BaseEntity
    {

        [Display(Name ="Your Full name")]
        [Required(ErrorMessage ="Please complete missing information")]
        public string Name { get; set; }

        [Display(Name ="Number of items")]
        [Required(ErrorMessage = "Please complete missing information")]
        public int numberOfItems { get; set; }

        [Display(Name ="Weight of individual item(s) (Kg)")]
        [Required(ErrorMessage = "Please complete missing information")]
        public decimal weightPerItem { get; set; }

        [Display(Name ="Breif description on items")]
        [Required(ErrorMessage = "Please comeplete missing information")]
        public string Descriptions { get; set; }

        [Display(Name = "Container Type")]
        public string ContainerType { get; set; }

        [Display(Name ="Number of containers")]
        [Required(ErrorMessage = "Please complete missing information")]
        public int numberOfContainers { get; set; }

        [Display(Name ="Where to pick up?")]
        [Required(ErrorMessage = "Please complete missing information")]
        public LocationType locationType { get; set; }

        [Display(Name ="Loading Location (Full address)")]
        [Required(ErrorMessage = "Please complete missing information")]
        public string loadingLocation { get; set; }

        //[Display(Name ="Pick up Date")]
        //[Required(ErrorMessage = "Please complete missing information")]
        //public DateTime rentInDate { get; set; }
        
        public string Image { get; set; }

        //public DateTime RentOutDate { get; set; }

        public enum LocationType
        {
            Home,
            Warehouse,
            Depot,
            Yard,
        }

    }
}
