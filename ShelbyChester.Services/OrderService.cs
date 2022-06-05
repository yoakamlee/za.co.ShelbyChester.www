using ShelbyChester.Core.Contracts;
using ShelbyChester.Core.Models;
using ShelbyChester.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelbyChester.Services
{
    public class OrderService : IOrderService
    {
        IRepo<Order> orderContext;
        public OrderService(IRepo<Order> OrderContext)
        {
            this.orderContext = OrderContext;
        }

        public void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems)
        {
            foreach(var item in basketItems)
            {
                baseOrder.OrderItems.Add(new OrderItem()
                {
                    ContainerCategoryId = item.Id,
                    Image = item.Image,
                    Price = item.ContainerPrice,
                    ContainerName = item.ContainerName,
                    Quaintity = item.Quantity

                });
            }

            orderContext.Insert(baseOrder);
            orderContext.Commit();
        }
    }
}
