using ShelbyChester.Core.Contracts;
using ShelbyChester.Core.Models;
using ShelbyChester.Core.ViewModels;
using ShelbyChester.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShelbyChester.WebUI.Controllers
{
    public class ContainerRentManagerController : Controller
    {
        DataContext db = new DataContext();

        IRepo<ContainerRent> rentContext;
        IRepo<ContainerCategory> containerRepo;
        IRepo<BasketItem> basketItems;

        public ContainerRentManagerController(IRepo<ContainerRent> RentContext,
                                              IRepo<ContainerCategory> ContainerRepo,
                                              IRepo<BasketItem> BasketItems)
        {
            rentContext = RentContext;
            containerRepo = ContainerRepo;
            basketItems = BasketItems;
        }

        // GET: ContainerRentManager
        public ActionResult Index()
        {
            List<ContainerRent> containerRents = rentContext.Collection().ToList();
            return View(containerRents);
        }


        public ActionResult Create()
        {

            ContainerRentViewModel viewModel = new ContainerRentViewModel();

            viewModel.ContainerRent = new ContainerRent();
            viewModel.ContainerCategories = containerRepo.Collection();
            return View(viewModel);

            //ContainerRent containerRent = new ContainerRent();
            //return View(containerRent);
        }

        [HttpPost]
        public ActionResult Create(ContainerRent containerRent)
        {
            if (!ModelState.IsValid)
            {
                return View(containerRent);
            }
            else
            {
                rentContext.Insert(containerRent);
                rentContext.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(string Id)
        {
                ContainerRent containerRent = rentContext.Find(Id);

                if (containerRent == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(containerRent);
                }
        }
    }
}