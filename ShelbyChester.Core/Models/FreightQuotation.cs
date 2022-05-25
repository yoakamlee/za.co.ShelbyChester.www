using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.Models
{
    public class FreightQuotation
    {
        public string Id { get; set; }

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

        public double basicprice { get; set; }

        public double totalPrice { get; set; }


        public double basicCost()
        {
            return Price * quantity;
        }

        public double calctot()
        {
            double total = 0;
            total = +basicCost();
            return (total);
        }

        public FreightQuotation()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
