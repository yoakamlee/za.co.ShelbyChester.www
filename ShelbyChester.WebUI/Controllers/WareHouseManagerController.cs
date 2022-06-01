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
    public class WareHouseManagerController : Controller
    {

        IRepo<WarehouseStorage> context;

        public WareHouseManagerController(IRepo<WarehouseStorage> warehouseStorageContext)
        {
            context = warehouseStorageContext;
        }
        // GET: WarehouseManager
        public ActionResult Index()
        {
            List<WarehouseStorage> warehouseStorages = context.Collection().ToList();
            return View(warehouseStorages);
        }

        public ActionResult Create()
        {
            WarehouseStorage warehouseStorage = new WarehouseStorage();
            return View(warehouseStorage);
        }
        [HttpPost]
        public ActionResult Create(WarehouseStorage warehouseStorage)
        {
            if (!ModelState.IsValid)
            {
                return View(warehouseStorage);
            }
            else
            {
                context.Insert(warehouseStorage);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            WarehouseStorage warehouseStorage = context.Find(Id);

            if (warehouseStorage == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(warehouseStorage);
            }
        }
        [HttpPost]
        public ActionResult Edit(WarehouseStorage warehouseStorage, string Id)
        {
            WarehouseStorage warehouseStorageToEdit = context.Find(Id);

            if (warehouseStorageToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(warehouseStorage);
                }

                warehouseStorageToEdit.Name = warehouseStorage.Name;
                warehouseStorageToEdit.Location = warehouseStorage.Location;
      

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            WarehouseStorage warehouseStorageToDelete = context.Find(Id);

            if (warehouseStorageToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(warehouseStorageToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            WarehouseStorage warehouseStorageToDelete = context.Find(Id);

            if (warehouseStorageToDelete == null)
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