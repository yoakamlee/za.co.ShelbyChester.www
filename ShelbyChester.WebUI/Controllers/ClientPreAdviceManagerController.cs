using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShelbyChester.Core.Models;
using ShelbyChester.DataAccess.InMemory;

namespace ShelbyChester.WebUI.Controllers
{
    public class ClientPreAdviceManagerController : Controller
    {
         ClientPreAdviceRepo context;

        public ClientPreAdviceManagerController()
        {
            context = new ClientPreAdviceRepo();
        }
        // GET: ClientPreAdviceManager
        public ActionResult Index()
        {
            List<ClientPreAdvice> clientPreAdvices = context.Collection().ToList();
            return View(clientPreAdvices);
        }

        public ActionResult Create()
        {
            ClientPreAdvice clientPreAdvice = new ClientPreAdvice();
            return View(clientPreAdvice);
        }
        [HttpPost]
        public ActionResult Create(ClientPreAdvice clientPreAdvice)
        {
            if (ModelState.IsValid)
            {
                return View(clientPreAdvice);
            }
            else
            {
                context.Insert(clientPreAdvice);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ClientPreAdvice clientPreAdvice = context.Find(Id);

            if (clientPreAdvice == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(clientPreAdvice);
            }
        }
        [HttpPost]
        public ActionResult Edit(ClientPreAdvice clientPreAdvice, string Id)
        {
            ClientPreAdvice clientAdviceToEdit = context.Find(Id);

            if (clientAdviceToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    return View(clientPreAdvice);
                }

                clientAdviceToEdit.Client_Description = clientPreAdvice.Client_Description;
                clientAdviceToEdit.SizePerItem = clientPreAdvice.SizePerItem;
                clientAdviceToEdit.NumberOfItems = clientPreAdvice.NumberOfItems;
                clientAdviceToEdit.WeightOfItems = clientPreAdvice.WeightOfItems;
                clientAdviceToEdit.Customer_CellNum = clientPreAdvice.Customer_CellNum;
                clientAdviceToEdit.Customer_Email = clientPreAdvice.Customer_Email;
                clientAdviceToEdit.Customer_Address = clientPreAdvice.Customer_Address;
                clientAdviceToEdit.Customer_Name = clientPreAdvice.Customer_Name;
                clientAdviceToEdit.Customer_Surname = clientPreAdvice.Customer_Surname;
                clientAdviceToEdit.Country = clientPreAdvice.Country;
                clientAdviceToEdit.ContainerType = clientAdviceToEdit.ContainerType;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            ClientPreAdvice clientAdviceToDelete = context.Find(Id);

            if (clientAdviceToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(clientAdviceToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ClientPreAdvice clientAdviceToDelete = context.Find(Id);

            if (clientAdviceToDelete == null)
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