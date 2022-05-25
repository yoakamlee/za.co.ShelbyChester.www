using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.ViewModels
{
    public class ContainerCategory
    {
        public string Id { get; set; }
        public string Category { get; set; }

        public int baseWeight { get; set; }

        public int size { get; set; }

        public ContainerCategory()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
