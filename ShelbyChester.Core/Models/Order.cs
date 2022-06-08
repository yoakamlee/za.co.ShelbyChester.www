using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Core.Models
{
    public class Order : BaseEntity
    {
        public Order()
        {
            this.OrderItems = new List<OrderItem>();
        }

        [Display(Name ="First Name(s)")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name(s)")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Postal Code")]
        public string postalCode { get; set; }
        [Display(Name = "Deliver To Location")]
        public string DeliverTo { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }
        [Display(Name = "Number of Items")]
        public int NumberOfItem { get; set; }
        [Display(Name = "Weight of items(Optional)")]
        public int WeightOfItem { get; set; }
        public string OrderStatus { get; set; }
        public string EmployeeId { get; set; }
        public string DriverId { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
