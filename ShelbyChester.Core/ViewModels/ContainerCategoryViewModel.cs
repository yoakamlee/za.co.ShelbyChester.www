using ShelbyChester.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.ViewModels
{
    public class ContainerCategoryViewModel
    {
        public ClientPreAdvice ClientPreAdvice { get; set; }
        public ContainerRental ContainerRental { get; set; }
        public IEnumerable<ContainerCategory> ContainerCategories { get; set; }
    }
}
