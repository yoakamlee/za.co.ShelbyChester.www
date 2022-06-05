using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.Models
{
    public class OrderItem : BaseEntity
    {
        public string OrderId { get; set; }
        public string ContainerCategoryId { get; set; }
        public string ContainerName { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Quaintity { get; set; }
    }
}
