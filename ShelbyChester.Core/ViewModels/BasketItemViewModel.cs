using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.ViewModels
{
    public class BasketItemViewModel
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public string ContainerName { get; set; }
        public decimal ContainerPrice { get; set; }
        public string Image { get; set; }
    }
}
