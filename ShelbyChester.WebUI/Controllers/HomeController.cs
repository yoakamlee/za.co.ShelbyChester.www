using ShelbyChester.Core.Contracts;
using ShelbyChester.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShelbyChester.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepo<ContainerRental> context;
        IRepo<ContainerCategory> containerRepo;

        public HomeController(IRepo<ContainerRental> containerRentalContext,
                                                IRepo<ContainerCategory> containerCategoryContext)
        {
            context = containerRentalContext;
            containerRepo = containerCategoryContext;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ContainerRentList()
        {
            List<ContainerCategory> containerCategories = containerRepo.Collection().ToList();
            return View(containerCategories);
        }

        public ActionResult Details(string Id)
        {
            ContainerCategory containerCategory = containerRepo.Find(Id);
            if (containerCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(containerCategory);
            }
        }

    }
}