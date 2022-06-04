using ShelbyChester.Core.Contracts;
using ShelbyChester.Core.Models;
using ShelbyChester.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShelbyChester.Services
{
    public class BasketService : IBasketService
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

        //Second half here :D
        public List<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext)
        {
            Basket basket = GetBasket(httpContext, false);

            if (basket != null)
            {
                var result = (from b in basket.BasketItems
                              join c in containerCategoryContext.Collection()
                              on b.Container_Id equals c.Id
                              select new BasketItemViewModel()
                              {
                                  Id = b.Id,
                                  Quantity = b.Quantity,
                                  ContainerName = c.ContainerName,
                                  Image = c.Image,
                                  ContainerPrice = c.ContainerPrice,
                              }
                              ).ToList();

                return result;
            }
            else
            {
                return new List<BasketItemViewModel>();
            }
        }

        public BasketSummaryViewModel GetBasketSummary(HttpContextBase httpContext)
        {
            Basket basket = GetBasket(httpContext, false);
            BasketSummaryViewModel model = new BasketSummaryViewModel(0,0);

            if (basket != null)
            {
                int? basketCount = (from item in basket.BasketItems
                                    select item.Quantity).Sum();

                decimal? basketTotal = (from item in basket.BasketItems
                                        join c in containerCategoryContext.Collection()
                                        on item.Container_Id equals c.Id
                                        select item.Quantity * c.ContainerPrice
                                        ).Sum();

                model.BasketCount = basketCount ?? 0;
                model.BasketTotal = basketTotal ?? decimal.Zero;

                return model;
            }
            else
            {
                return model;
            }
        }
    }
}
