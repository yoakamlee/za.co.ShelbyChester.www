using ShelbyChester.Core.Contracts;
using ShelbyChester.Core.Models;
using ShelbyChester.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShelbyChester.WebUI.Controllers
{
    public class ContainerCategoryManagerController : Controller
    {


        IRepo<ContainerCategory> context;

        public ContainerCategoryManagerController(IRepo<ContainerCategory> containerCategoryContext)
        {
            context = containerCategoryContext;
        }
        // GET: ContainerCategoryManager
        public ActionResult Index()
        {
            List<ContainerCategory> containerCategories = context.Collection().ToList();
            return View(containerCategories);
        }

        public ActionResult Create()
        {
            ContainerCategory containerCategory = new ContainerCategory();
            return View(containerCategory);
        }
        [HttpPost]
        public ActionResult Create(ContainerCategory containerCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(containerCategory);
            }
            else
            {
                context.Insert(containerCategory);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ContainerCategory containerCategory = context.Find(Id);

            if (containerCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(containerCategory);
            }
        }
        [HttpPost]
        public ActionResult Edit(ContainerCategory containerCategory, string Id)
        {
            ContainerCategory containerCategoryToEdit = context.Find(Id);

            if (containerCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(containerCategory);
                }

                containerCategoryToEdit.ContainerName = containerCategory.ContainerName;
                containerCategoryToEdit.ContainerWeight = containerCategory.ContainerWeight;
                containerCategoryToEdit.ContainerSize = containerCategory.ContainerSize;


                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            ContainerCategory containerCategoryToDelete = context.Find(Id);

            if (containerCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(containerCategoryToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ContainerCategory containerCategoryToDelete = context.Find(Id);

            if (containerCategoryToDelete == null)
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
    }
}