using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.Models
{
    public class FreightQuotation : BaseEntity
    {

        [Required(ErrorMessage = "enter the type of the container")]
        [DisplayName("Container Type")]
        public string name { get; set; }

        [Required(ErrorMessage = "enter the Price of the container")]
        [DisplayName("Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "enter the quantity")]
        [DisplayName("Quantity")]
        public int quantity { get; set; }


        [Required(ErrorMessage = "enter the weight of the container")]
        [DisplayName("Weight of a container")]
        public string Weight { get; set; }

        [Required(ErrorMessage = "enter the size of a container")]
        [DisplayName("size")]
        public string size { get; set; }
    }
}
