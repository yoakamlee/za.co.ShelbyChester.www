using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.Models
{
    public class Basketitem : BaseEntity
    {
        public virtual ICollection<BasketItem> BasketItems { get; set; }
        public ICollection<ContainerRent> ContainerRents { get; set; }

        public Basketitem()
        {
            this.BasketItems = new List<BasketItem>();
        }
    }
}
