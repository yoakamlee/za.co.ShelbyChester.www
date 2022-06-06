using System;
using System.Collections.Generic;
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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string postalCode { get; set; }
        public string DeliverTo { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int NumberOfItem { get; set; }
        public int WeightOfItem { get; set; }
        public string OrderStatus { get; set; }
        public string EmployeeId { get; set; }
        public string DriverId { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
