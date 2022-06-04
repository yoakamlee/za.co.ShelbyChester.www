using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.Models
{
    public class WarehouseStorage : BaseEntity
    {

        [DisplayName("Warehouse Name")]
        public string Name { get; set; }

        [DisplayName("Warehouse Location")]
        public string Location { get; set; }

    }
}

