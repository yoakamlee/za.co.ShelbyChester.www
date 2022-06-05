using ShelbyChester.Core.Contracts;
using ShelbyChester.Core.Models;
using ShelbyChester.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShelbyChester.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        IRepo<Employee> employeeContext;
        IRepo<ContainerRent> rentContext;
        public EmployeeController(IRepo<Employee> EmployeeContext, IRepo<ContainerRent> RentContext)
        {
            employeeContext = EmployeeContext;
            rentContext = RentContext;
        }
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> employees = employeeContext.Collection().ToList();
            return View(employees);
        }

        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }
        [HttpPost]
        public ActionResult Create(Employee employee, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            else
            {
                if (file != null)
                {
                    employee.Image = employee.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//EmployeeImage//") + employee.Image);
                }

                employeeContext.Insert(employee);
                employeeContext.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Employee employee = employeeContext.Find(Id);

            if (employee == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(employee);
            }
        }
        [HttpPost]
        public ActionResult Edit(Employee employee, string Id, HttpPostedFileBase file)
        {
            Employee employeeToEdit = employeeContext.Find(Id);

            if (employeeToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(employeeToEdit);
                }
                if (file != null)
                {
                    employeeToEdit.Image = employee.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ContainerType//") + employeeToEdit.Image);
                }

                employeeToEdit.EmployeeName = employee.EmployeeName;
                employeeToEdit.EmployeeGender = employee.EmployeeGender;
                employeeToEdit.EmployeeAddress = employee.EmployeeAddress;
                employeeToEdit.EmployeePhone = employee.EmployeePhone;
                employeeToEdit.Image = employee.Image;

                employeeContext.Commit();

                return RedirectToAction("Index");
            }


        }
        public ActionResult Delete(string Id)
        {
            Employee employeeToDelete = employeeContext.Find(Id);

            if (employeeToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(employeeToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Employee employeeToDelete = employeeContext.Find(Id);

            if (employeeToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                employeeContext.Delete(Id);
                employeeContext.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Assign(string Id)
        {
            EmployeeViewModel viewModel = new EmployeeViewModel();

            viewModel.Employee = employeeContext.Find(Id);
            viewModel.ContainerRents = rentContext.Collection();

            if (viewModel == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(viewModel);
            }
        }
    }
}