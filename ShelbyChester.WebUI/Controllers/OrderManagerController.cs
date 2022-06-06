using ShelbyChester.Core.Contracts;
using ShelbyChester.Core.Models;
using ShelbyChester.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShelbyChester.WebUI.Controllers
{
    public class OrderManagerController : Controller
    {
        IOrderService orderService;
        IRepo<Customer> customers;
        ApplicationDbContext db = new ApplicationDbContext();

        public OrderManagerController(IOrderService OrderService, IRepo<Customer> Customers, ApplicationDbContext Db)
        {
            this.orderService = OrderService;
            this.customers = Customers;
            this.db = Db;
        }
        

        // GET: OrderManager
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<Order> orders = orderService.GetOrderList();
            return View(orders);
        }

        //Employee View
        [Authorize(Roles = "Employee")]
        public ActionResult Employee()
        {
            string empID = "";
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=ShelbyChester;Integrated Security=True"))
            {
                connection.Open();
                string query = @"SELECT TOP 1 Id
	                               FROM AspNetUsers
	                               WHERE Email = '"+ Session["CurrentUserEmail"]+"'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            empID = reader.GetString(0);
                        }
                    }
                }
            }

            List<Order> orders = orderService.GetOrderList().Where(x => x.EmployeeId == empID).ToList();
  
            return View(orders);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult UpdateOrder(string Id)
        {
            ViewBag.StatusList = new List<string>()
            {
                "Order Created",
                "Order Processed",
                "Order Shipped",
                "Order Complete"
            };

            List<string> employees = new List<string>();
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=ShelbyChester;Integrated Security=True"))
            {
                connection.Open();
                string query = @"SELECT UR.UserId
	                               FROM AspNetRoles r , AspNetUserRoles ur
	                               WHERE R.Id = UR.RoleId
	                               AND R.Name = 'Employee'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(reader.GetString(0));
                        }
                    }
                }
            }

            List<ApplicationUser> emps = new List<ApplicationUser>();
            foreach (string empID in employees)
            {
               ApplicationUser user = db.Users.Where(x => x.Id == empID).FirstOrDefault();
                if (user != null)
                    emps.Add(user);
            }

            if (employees.Count > 0)
            {
            ViewBag.EmpList = emps;
            }


            Order order = orderService.GetOrder(Id);
            return View(order);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateOrder(Order updateOrder, string Id)
        {
            Order order = orderService.GetOrder(Id);

            order.OrderStatus = updateOrder.OrderStatus;
            order.EmployeeId = updateOrder.EmployeeId;
            orderService.UpdateOrder(order);

            return RedirectToAction("Index");
        }
    }
}