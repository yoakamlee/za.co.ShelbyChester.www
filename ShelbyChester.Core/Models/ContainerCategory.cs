using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.Models
{
    public class ContainerCategory
    {
        public string Id { get; set; }
        public string ContainerName { get; set; }
        public int ContainerWeight { get; set; }
        public int ContainerSize { get; set; }

        public ContainerCategory()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
