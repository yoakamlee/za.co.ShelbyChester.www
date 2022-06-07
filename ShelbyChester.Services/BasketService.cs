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
        IRepo<Basketitem> basketContext;

        public const string BasketSessionName = "eCommerceBasket";

        public BasketService(IRepo<ContainerCategory> ContainerCategoryContext, IRepo<Basketitem> BasketContext)
        {
            this.basketContext = BasketContext;
            this.containerCategoryContext = ContainerCategoryContext;
        }

        private Basketitem GetBasket(HttpContextBase httpContext, bool createIfNull)
         {
            HttpCookie cookie = httpContext.Request.Cookies.Get(BasketSessionName);

            Basketitem basket = new Basketitem();

            if (cookie != null)
            {
                string BasketId = cookie.Value;
                if (!string.IsNullOrEmpty(BasketId)) 
                {
                    //TO DO  add null check
                    basket = basketContext.Find(BasketId) ?? CreateNewBasket(httpContext);
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

        private Basketitem CreateNewBasket(HttpContextBase httpContext)
        {
            Basketitem basket = new Basketitem();
            basketContext.Insert(basket);
            basketContext.Commit();

            HttpCookie cookie = new HttpCookie(BasketSessionName);
            cookie.Value = basket.Id;
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);

            return basket;
        }

        public void AddToBasket(HttpContextBase httpContext, string containerId)
        {
            Basketitem basket = GetBasket(httpContext, true);

            BasketItem item = basket.BasketItems.FirstOrDefault(x => x.ContainerCategoryId == containerId);

            if (item == null)
            {
                item = new BasketItem()
                {
                    BasketId = basket.Id,
                    ContainerCategoryId = containerId,
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
            Basketitem basket = GetBasket(httpContext, true);
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
            Basketitem basket = GetBasket(httpContext, false);

            if (basket != null)
            {
                var result = (from b in basket.BasketItems
                              join c in containerCategoryContext.Collection()
                              on b.ContainerCategoryId equals c.Id
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
            Basketitem basket = GetBasket(httpContext, false);
            BasketSummaryViewModel model = new BasketSummaryViewModel(0,0);

            if (basket != null)
            {
                int? basketCount = (from item in basket.BasketItems
                                    select item.Quantity).Sum();

                decimal? basketTotal = (from item in basket.BasketItems
                                        join c in containerCategoryContext.Collection()
                                        on item.ContainerCategoryId equals c.Id
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

        public void ClearBasket(HttpContextBase httpContext)
        {
            Basketitem basket = GetBasket(httpContext, false);
            basket.BasketItems.Clear();
            basketContext.Commit();
        }


    }
}
