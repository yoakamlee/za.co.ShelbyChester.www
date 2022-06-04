using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.Models
{
    public class ContainerCategory : BaseEntity
    {
        [Display(Name ="Container Name")]
        public string ContainerName { get; set; }

        [Display(Name = "Container Capacity(cubic ft)")]
        public int ContainerCapacity { get; set; }

        [Display(Name = "Container height(ft)")]
        public int ContainerSize { get; set; }
        public string Image { get; set; }

    }
}
