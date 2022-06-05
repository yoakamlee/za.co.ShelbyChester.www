using ShelbyChester.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.ViewModels
{
    public class ContainerRentViewModel
    {
        public ContainerRent ContainerRent { get; set; }
        public virtual IEnumerable<ContainerCategory> ContainerCategories { get; set; }

    }
}
