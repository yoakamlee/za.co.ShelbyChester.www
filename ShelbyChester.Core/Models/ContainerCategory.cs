using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.Models
{
    public class ContainerCategory : BaseEntity
    {
        public string ContainerName { get; set; }
        public int ContainerWeight { get; set; }
        public int ContainerSize { get; set; }

    }
}
