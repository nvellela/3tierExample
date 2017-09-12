using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3Layers1ProjectExample.Application.BusinessLogicLayer.Interfaces;
using WebApplication3Layers1ProjectExample.Application.BusinessLogicLayer.Models;
using WebApplication3Layers1ProjectExample.Application.BusinessLogicLayer.Services;
using WebApplication3Layers1ProjectExample.Models;

namespace WebApplication3Layers1ProjectExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //public HomeController()
        //{
        //    _employeeService = new EmployeeService();
        //}

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

        public ActionResult EmployeeList()
        {
            var employeeBModels = _employeeService.FetchAll();

            var vmList = new List<EmployeeViewModel>();
            foreach (var item in employeeBModels)
            {
                var vmEmployee = new EmployeeViewModel();

                vmEmployee.Id = item.Id;
                vmEmployee.Name = item.Name;
                vmEmployee.Salary = item.Salary; //.ToString();
                vmEmployee.IsRetired = item.IsRetired;

                if (item.Salary > 5)
                {
                    vmEmployee.SalaryColor = "green";
                }
                else
                {
                    vmEmployee.SalaryColor = "red";
                }
                vmList.Add(vmEmployee);
            }

            return View(vmList);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                //add to business layer
                var emplyeeBModel = new EmployeeModel();
                emplyeeBModel.Name = model.Name;
                emplyeeBModel.Salary = model.Salary;
                emplyeeBModel.IsRetired = model.IsRetired;
                _employeeService.Add(emplyeeBModel);

                return RedirectToAction("EmployeeList");
            }

            return View(model);
        }
    }
}