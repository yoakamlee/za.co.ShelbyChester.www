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
        

        // GET: OrderManager Admin View List // Index
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<Order> orders = orderService.GetOrderList();
            return View(orders);
        }
        //

        //Employee View List//Index
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
        //

        //Employee Manager Edit//Edit 
        public ActionResult EmployeeUpdate(string Id)
        {
            ViewBag.StatusList = new List<string>()
            {
                "Order Created",
                "Order Processed",
                "Order Packed",
                "Order On Route",
                "Order Shipped",
                "Order Complete",
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

        //

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public ActionResult EmployeeUpdate(Order updateOrder, string Id)
        {
            Order order = orderService.GetOrder(Id);

            order.OrderStatus = updateOrder.OrderStatus;
            orderService.UpdateOrder(order);

            return RedirectToAction("Employee");
        }
        //

        //Driver View

        
        [Authorize(Roles = "Driver")]
        public ActionResult Driver()
        {
            string driveID = "";
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=ShelbyChester;Integrated Security=True"))
            {
                connection.Open();
                string query = @"SELECT TOP 1 Id
	                               FROM AspNetUsers
	                               WHERE Email = '" + Session["CurrentUserEmail"] + "'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            driveID = reader.GetString(0);
                        }
                    }
                }
            }

            List<Order> orders = orderService.GetOrderList().Where(x => x.DriverId == driveID).ToList();

            return View(orders);
        }
        //
        

        [HttpPost]
        [Authorize(Roles = "Driver")]
        public ActionResult DriverUpdate(Order updateOrder, string Id)
        {
            Order order = orderService.GetOrder(Id);

            order.OrderStatus = updateOrder.OrderStatus;
            orderService.UpdateOrder(order);

            return RedirectToAction("Driver");
        }

        //Driver View Edit //Edit !!TO DO!!

        public ActionResult DriverUpdate(string Id)
        {
            ViewBag.StatusList = new List<string>()
            {
                "Order Created",
                "Order Processed",
                "Order Packed",
                "Order On Route",
                "Order Shipped",
                "Order Complete",
            };

            List<string> drivers = new List<string>();
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=ShelbyChester;Integrated Security=True"))
            {
                connection.Open();
                string query = @"SELECT UR.UserId
	                               FROM AspNetRoles r , AspNetUserRoles ur
	                               WHERE R.Id = UR.RoleId
	                               AND R.Name = 'Driver'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            drivers.Add(reader.GetString(0));
                        }
                    }
                }
            }

            List<ApplicationUser> drives = new List<ApplicationUser>();
            foreach (string driveID in drivers)
            {
                ApplicationUser user = db.Users.Where(x => x.Id == driveID).FirstOrDefault();
                if (user != null)
                    drives.Add(user);
            }

            if (drivers.Count > 0)
            {
                ViewBag.EmpList = drives;
            }

            Order order = orderService.GetOrder(Id);
            return View(order);
        }

        //

        //Admin view Manager// Edit (Manager orders
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateOrder(string Id)
        {
            ViewBag.StatusList = new List<string>()
            {
                "Order Created",
                "Order Processed",
                "Order Packed",
                "Order On Route",
                "Order Shipped",
                "Order Complete",
            };
            //EmloyeeList
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

            //DriverList
            List<string> drivers = new List<string>();
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=ShelbyChester;Integrated Security=True"))
            {
                connection.Open();
                string query = @"SELECT UR.UserId
	                               FROM AspNetRoles r , AspNetUserRoles ur
	                               WHERE R.Id = UR.RoleId
	                               AND R.Name = 'Driver'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            drivers.Add(reader.GetString(0));
                        }
                    }
                }
            }

            List<ApplicationUser> drive = new List<ApplicationUser>();
            foreach (string driveID in drivers)
            {
                ApplicationUser user = db.Users.Where(x => x.Id == driveID).FirstOrDefault();
                if (user != null)
                    drive.Add(user);
            }

            if (drivers.Count > 0)
            {
                ViewBag.DriveList = drive;
            }


            Order order = orderService.GetOrder(Id);
            return View(order);
        }
        //


        //Admin Manager // Edit
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateOrder(Order updateOrder, string Id)
        {
            Order order = orderService.GetOrder(Id);

            order.OrderStatus = updateOrder.OrderStatus;
            order.EmployeeId = updateOrder.EmployeeId;
            order.DriverId = updateOrder.DriverId;
            orderService.UpdateOrder(order);

            return RedirectToAction("Index");
        }
        //

        public ActionResult DeleteOrder()
        {
            return View();
        }
    }


    
}