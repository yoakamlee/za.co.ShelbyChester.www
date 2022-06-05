using ShelbyChester.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShelbyChester.Core.Contracts
{
    public  interface IBasketService
    {
        void AddToBasket(HttpContextBase httpContext, string container_Id);
        void RemoveFromBasket(HttpContextBase httpContext, string item_Id);
        List<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext);
        BasketSummaryViewModel GetBasketSummary(HttpContextBase httpContext);
        void ClearBasket(HttpContextBase httpContext);

    }
}
