using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.Models
{
    public class WarehouseStorage
    {
        public int Id { get; set; }

        [DisplayName("Warehouse Name")]
        public string Name { get; set; }

        [DisplayName("Wrehouse Location")]
        public string Location { get; set; }

    }
}
}
