using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.Models
{
    public class BasketItem : BaseEntity
    {
        public string BasketId { get; set; }
        public string ContainerCategoryId { get; set; }
        public int Quantity { get; set; }
        public string ContainerName { get; set; }
    }
}
