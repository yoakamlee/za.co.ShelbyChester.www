using ShelbyChester.Core.Contracts;
using ShelbyChester.Core.Models;
using ShelbyChester.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ShelbyChester.WebUI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService basketService;
        IOrderService orderService;
        IRepo<Customer> customers;
        DataContext dc;

        public BasketController(IBasketService BasketService, IOrderService OrderService,
            IRepo<Customer> Customers)
        {
            this.basketService = BasketService;
            this.orderService = OrderService;
            this.customers = Customers;
        }
        // GET: Basket
        public ActionResult Index()
        {
            var model = basketService.GetBasketItems(this.HttpContext);
            return View(model);
        }

        public ActionResult AddToBasket(string Id)
        {
            basketService.AddToBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromBasket(string Id)
        {
            basketService.RemoveFromBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public PartialViewResult BasketSummary()
        {
            var basketSummary = basketService.GetBasketSummary(this.HttpContext);

            return PartialView(basketSummary);
        }

        [Authorize]
        public ActionResult CheckOut(string Id)
        {
            Customer customer = customers.Collection().FirstOrDefault(c => c.Email == User.Identity.Name);
            if (customer != null)
            {
                Order order = new Order()
                {
                    Email = customer.Email,
                    City = customer.City,
                    Address = customer.Address,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    postalCode = customer.postalCode,
                };
                return View(order);
            }
            
                if (Id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                OrderItem orderItem = new OrderItem();

                int Ttotal = Convert.ToInt32(orderItem.Price);
                //int Vattot = Convert.ToInt32(booking.VatTotal);
                //ViewBag.TotalForBooking = Ttotal;
                //ViewBag.Vattotal = Vattot;

                if (orderItem == null)
                {
                    return HttpNotFound();
                }
                //ViewBag.CateringId = new SelectList(db.Caterings, "Id", "Name", booking.CateringId);
                //ViewBag.RoomType = new SelectList(db.RoomSizes, "Id", "RoomName", booking.RoomType);
                return View(orderItem);
            
            
        }

        [HttpPost]
        //[Authorize]
        public ActionResult CheckOut(Order order, Order orderItem)
        {

            var basketItemspay = basketService.GetBasketItems(this.HttpContext);
            order.OrderStatus = "Order Created";
            order.Email = User.Identity.Name;

            //Process Payment

            //var FindOrder = db.Bookings.Where(x => x.Id == invoice.Id).Include(x => x.RoomSize).Include(x => x.ApplicationUser).Include(x => x.Catering).FirstOrDefault() ?? null;
            var FindOrder = dc.OrderItems.Where(x => x.Id == orderItem.Id).FirstOrDefault() ?? null;

            if (FindOrder != null)
            {
                //String Body = string.Format("Dear, " + FindBooking.ApplicationUser.Name + " " + "Please note you have a booking a room at our hotel , Please see invoice below" +
                //    ". Ref No: " + FindBooking.BookReferenceNumber + ". Your Check In Date is:" + " " + FindBooking.Check_In_Date + ". The Check Out Date is: " + FindBooking.Check_Out_Date + ". The room price is: r" + FindBooking.RoomPrice + ". Your Room Number/s are as follow: " + invoice.RoomNumber);


                //var EmailItems = new EmailItems()
                //{
                //    FirstName = FindBooking.ApplicationUser.Name,
                //    LastName = FindBooking.ApplicationUser.Surname,
                //    To = FindBooking.ApplicationUser.Email,
                //    Body = Body,
                //    Subject = "Booking at SkyNet",
                //    EmailAddress = FindBooking.ApplicationUser.Email
                //};
                //Email email = new Email();
                //var SendEmail = email.sends2(EmailItems);


                //  here i take the amount and other value from the booking i find an put them into varibles
                int amount = Convert.ToInt32(FindOrder.Price);
                string orderId = new Random().Next(1, 99999).ToString();
                string name = "SkyNet, Order#" + orderId;
                //string description = "Blissful Kiddies";

                // lines below just listing some varibles to use in future
                string site = "";
                string merchant_id = "";
                string merchant_key = "";

                // Check if we are using the test payfast or  live system
                // line below looks at web config to find setting

                string paymentMode = "test";


                // if the paymentmode is test use a sandbox to run system else if live , a real payemnt will go through else throw an error
                if (paymentMode == "test")
                {
                    // here im filling in values  for my test sandbox to use
                    site = "https://sandbox.payfast.co.za/eng/process?";
                    //merchant_id = "10000100";
                    //merchant_key = "46f0cd694581a";

                    merchant_id = "10026327";
                    merchant_key = "q08xrodezpb1t";
                }
                //else if (paymentMode == "live")
                //{
                //    site = "https://www.payfast.co.za/eng/process?";
                //    merchant_id = System.Configuration.ConfigurationManager.AppSettings["PF_MerchantID"];
                //    merchant_key = System.Configuration.ConfigurationManager.AppSettings["PF_MerchantKey"];
                //}
                else
                {
                    throw new InvalidOperationException("Cannot process payment if PaymentMode (in web.config) value is unknown.");
                }


                // Build the query string for payment site


                // here i put together all the values i need to send to payfast such ass amount , name , and the return url for when the payment is completed
                // and the merchant key and id ti access the sandbox
                //StringBuilder str = new StringBuilder();
                //str.Append("merchant_id=" + HttpUtility.UrlEncode(merchant_id));
                //str.Append("&merchant_key=" + HttpUtility.UrlEncode(merchant_key));
                //str.Append("&return_url=" + HttpUtility.UrlEncode(System.Configuration.ConfigurationManager.AppSettings["PF_ReturnURL"]));
                //str.Append("&cancel_url=" + HttpUtility.UrlEncode(System.Configuration.ConfigurationManager.AppSettings["PF_CancelURL"]));
                ////str.Append("&notify_url=" + HttpUtility.UrlEncode(System.Configuration.ConfigurationManager.AppSettings["PF_NotifyURL"]));

                //str.Append("&m_payment_id=" + HttpUtility.UrlEncode(orderId));
                //str.Append("&amount=" + HttpUtility.UrlEncode(Convert.ToString(amount)));
                //str.Append("&item_name=" + HttpUtility.UrlEncode(name));
                //str.Append("&item_description=" + HttpUtility.UrlEncode(description));


                var FindBooking2 = dc.OrderItems.FirstOrDefault(x => x.Id == orderItem.Id);
                if (FindBooking2 != null)
                {
                    //FindBooking2.PaidOrOutStanding = true;
                    //db.Entry(FindBooking2).State = EntityState.Modified;
                    //db.SaveChanges();
                }
                // Redirect to PayFast line below will send you to payfast with all your values and you can make payment
                Response.Redirect(site + dc.OrderItems.Where(x => x.Id == orderItem.Id).ToString());


                order.OrderStatus = "Payment Processed";
                orderService.CreateOrder(order, basketItemspay);
                basketService.ClearBasket(this.HttpContext);

                return View();
            }
            else
            {
                return View();
            }

            //


            //order.OrderStatus = "Payment Processed";
            //orderService.CreateOrder(order, basketItems);
            //basketService.ClearBasket(this.HttpContext);

            //return RedirectToAction("ThankYou", new { OrderId = order.Id });
        }

        public ActionResult ThankYou(string OrderId)
        {
            ViewBag.OrderId = OrderId;
            return View();
        }


        //payment
        
    }
}