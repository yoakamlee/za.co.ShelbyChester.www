using ShelbyChester.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public Driver Driver { get; set; }
        public virtual IEnumerable<ContainerRent> ContainerRents { get; set; }
    }
}
