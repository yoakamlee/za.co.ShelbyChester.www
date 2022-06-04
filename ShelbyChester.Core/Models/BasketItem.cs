using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.Models
{
    public class BasketItem : BaseEntity
    {
        public string Basket_Id { get; set; }
        public string Container_Id { get; set; }
        public int Quantity { get; set; }
    }
}
