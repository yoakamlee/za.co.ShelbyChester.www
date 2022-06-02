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

        [Display(Name = "Container Weight(kg)")]
        public int ContainerWeight { get; set; }

        [Display(Name = "Container height(ft)")]
        public int ContainerSize { get; set; }
        public string Image { get; set; }

    }
}
