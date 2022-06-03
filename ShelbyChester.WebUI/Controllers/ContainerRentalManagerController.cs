using ShelbyChester.Core.Contracts;
using ShelbyChester.Core.Models;
using ShelbyChester.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShelbyChester.WebUI.Controllers
{
    public class ContainerRentalManagerController : Controller
    {
        IRepo<ContainerRental> context;
        IRepo<ContainerCategory> containerRepo;

        public ContainerRentalManagerController(IRepo<ContainerRental> containerRentalContext,
                                                IRepo<ContainerCategory> containerCategoryContext)
        {
            context = containerRentalContext;
            containerRepo = containerCategoryContext;
        }
        // GET: ContainerRentalManager
        public ActionResult Index()
        {
            List<ContainerRental> containerRental = context.Collection().ToList();
            return View(containerRental);
        }

        //Container create
        public ActionResult Create()
        {
            ContainerCategoryViewModel viewModel = new ContainerCategoryViewModel();

            viewModel.ContainerRental = new ContainerRental();
            viewModel.ContainerCategories = containerRepo.Collection();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(ContainerRental containerRental)
        {
            if (!ModelState.IsValid)
            {
                return View(containerRental);
            }
            else
            {
                context.Insert(containerRental);
                context.Commit();

                return RedirectToAction("Index");
            }
        }
        //Edit ContainerRental
        public ActionResult Edit(string Id)
        {
            ContainerRental containerRental = context.Find(Id);

            if (containerRental == null)
            {
                return HttpNotFound();
            }
            else
            {
                ContainerCategoryViewModel viewModel = new ContainerCategoryViewModel();
                viewModel.ContainerRental = containerRental;
                viewModel.ContainerCategories = containerRepo.Collection();
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(ContainerRental containerRental, string Id)
        {
            ContainerRental containerRentalToEdit = context.Find(Id);

            if (containerRentalToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(containerRentalToEdit);
                }

                containerRentalToEdit.Descriptions = containerRental.Descriptions;
                containerRentalToEdit.loadingLocation = containerRental.loadingLocation;
                containerRentalToEdit.locationType = containerRental.locationType;
                containerRentalToEdit.numberOfContainers = containerRental.numberOfContainers;
                containerRentalToEdit.rentInDate = containerRental.rentInDate;
                containerRentalToEdit.weightPerItem = containerRental.weightPerItem;
                containerRentalToEdit.numberOfItems = containerRental.numberOfItems;
                containerRentalToEdit.Name = containerRental.Name;
                

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        //Delete container Booking
        public ActionResult Delete(string Id)
        {
            ContainerRental containerRentalToDelete = context.Find(Id);

            if (containerRentalToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(containerRentalToDelete);
            }
        }

        [HttpPost]
        [ActionName("Cancel")]
        public ActionResult ConfirmDelete(string Id)
        {
            ContainerRental ContainerRentalToDelete = context.Find(Id);

            if (ContainerRentalToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(string Id)
        {
            ContainerRental containerRental = context.Find(Id);

            if (containerRental == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(containerRental);
            }
        }

    }
}