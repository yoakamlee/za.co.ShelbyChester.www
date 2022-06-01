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
    public class FreightQuotationManagerController : Controller
    {

        IRepo<FreightQuotation> context;

        public FreightQuotationManagerController(IRepo<FreightQuotation> freightQuotationContext)
        {
            context = freightQuotationContext;
        }
        // GET: FreightQuotationManager
        public ActionResult Index()
        {
            List<FreightQuotation> freightQuotations = context.Collection().ToList();
            return View(freightQuotations);
        }

        public ActionResult Create()
        {
            FreightQuotation freightQuotation = new FreightQuotation();
            return View(freightQuotation);
        }
        [HttpPost]
        public ActionResult Create(FreightQuotation freightQuotation)
        {
            if (!ModelState.IsValid)
            {
                return View(freightQuotation);
            }
            else
            {
                context.Insert(freightQuotation);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            FreightQuotation freightQuotation = context.Find(Id);

            if (freightQuotation == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(freightQuotation);
            }
        }
        [HttpPost]
        public ActionResult Edit(FreightQuotation freightQuotation, string Id)
        {
            FreightQuotation freightQuotationToEdit = context.Find(Id);

            if (freightQuotationToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(freightQuotation);
                }

                freightQuotationToEdit.name = freightQuotation.name;
                freightQuotationToEdit.Price = freightQuotation.Price;
                freightQuotationToEdit.quantity = freightQuotation.quantity;
                freightQuotationToEdit.size = freightQuotation.size;
                freightQuotationToEdit.Weight = freightQuotation.Weight;


                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            FreightQuotation freightQuotationToDelete = context.Find(Id);

            if (freightQuotationToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(freightQuotationToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            FreightQuotation freightQuotationToDelete = context.Find(Id);

            if (freightQuotationToDelete == null)
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