using ShelbyChester.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.Models
{
    public class ContainerRent : BaseEntity
    {
        public string Location { get; set; }
        public string DeliverTo { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int NumberOfItem { get; set; }
        public int WeightOfItem { get; set; }
        public string ContainerName { get; set; }
        public ContainerCategory ContainerCategory { get; set; }



    }
}
