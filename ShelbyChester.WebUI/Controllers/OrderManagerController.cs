using ShelbyChester.Core.Contracts;
using ShelbyChester.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShelbyChester.WebUI.Controllers
{
    public class OrderManagerController : Controller
    {
        IOrderService orderService;
        IRepo<Customer> customers;

        public OrderManagerController(IOrderService OrderService, IRepo<Customer> Customers)
        {
            this.orderService = OrderService;
            this.customers = Customers;
        }
        

        // GET: OrderManager
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<Order> orders = orderService.GetOrderList();
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
            Order order = orderService.GetOrder(Id);
            return View(order);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateOrder(Order updateOrder, string Id)
        {
            Order order = orderService.GetOrder(Id);

            order.OrderStatus = updateOrder.OrderStatus;
            orderService.UpdateOrder(order);

            return RedirectToAction("Index");
        }
    }
}