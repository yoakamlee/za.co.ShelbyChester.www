using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.Models
{
    public class Driver : BaseEntity
    {


        public enum Status
        {
            Dispatched, Delayed, Delivered
        }
        public class Delivery
        {
            public virtual Driver Driver { get; set; }


            [Display(Name = "Driver")]
            public int DriverID { get; set; }

            public string TruckType { get; set; }

            public string Brand { get; set; }

            public int TruckWeight { get; set; }

            public int CargoAmt { get; set; }

            public int CargoType { get; set; }

            //Possible Future Use
            public Status Status { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [Display(Name = "Date Dispatched")]
            public DateTime Dispatched_Date { get; set; }
        }
    }
}
