using ShelbyChester.Core.Contracts;
using ShelbyChester.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShelbyChester.Services
{
    public class BasketService
    {
        IRepo<ContainerCategory> containerCategoryContext;
        IRepo<Basket> basketContext;

        public const string BasketSessionName = "eCommerceBasket";

        public BasketService(IRepo<ContainerCategory> ContainerCategoryContext, IRepo<Basket> BasketContext)
        {
            this.basketContext = BasketContext;
            this.containerCategoryContext = ContainerCategoryContext;
        }

        private Basket GetBasket(HttpContextBase httpContext, bool createIfNull)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(BasketSessionName);

            Basket basket = new Basket();

            if (cookie != null)
            {
                string Basket_Id = cookie.Value;
                if (!string.IsNullOrEmpty(Basket_Id))
                {
                    basket = basketContext.Find(Basket_Id);
                }
                else
                {
                    if (createIfNull)
                    {
                        basket = CreateNewBasket(httpContext);
                    }
                }
            }
            else
            {
                if (createIfNull)
                {
                    basket = CreateNewBasket(httpContext);
                }
            }
            return basket;
        }

        private Basket CreateNewBasket(HttpContextBase httpContext)
        {
            Basket basket = new Basket();
            basketContext.Insert(basket);
            basketContext.Commit();

            HttpCookie cookie = new HttpCookie(BasketSessionName);
            cookie.Value = basket.Id;
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);

            return basket;
        }

        public void AddToBasket(HttpContextBase httpContext, string container_Id)
        {
            Basket basket = GetBasket(httpContext, true);
            BasketItem item = basket.BasketItems.FirstOrDefault(x => x.Container_Id == container_Id);

            if (item == null)
            {
                item = new BasketItem()
                {
                    Basket_Id = basket.Id,
                    Container_Id = container_Id,
                    Quantity = 1,
                };
                basket.BasketItems.Add(item);
            }
            else
            {
                item.Quantity = item.Quantity + 1;
            }

            basketContext.Commit();
        }

        public void RemoveFromBasket(HttpContextBase httpContext, string item_Id)
        {
            Basket basket = GetBasket(httpContext, true);
            BasketItem item = basket.BasketItems.FirstOrDefault(i => i.Id == item_Id);

            if (item != null)
            {
                basket.BasketItems.Remove(item);
                basketContext.Commit();
            }
        }
    }
}
