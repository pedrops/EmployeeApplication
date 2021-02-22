using Core.Interfaces.Service;
using EmployeeApp.Facade;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IEmployeeClientService employeeClientService;
        public EmployeeController(IEmployeeClientService _employeeClientService)
        {
            employeeClientService = _employeeClientService;
        }

        // GET: Employee
        public ActionResult Index()
        {
            EmployeeFacade employeeFacade = new EmployeeFacade(employeeClientService);
            var employeeList = employeeFacade.GetEmployeesFromAPI();
            return View(employeeList);
        }

        // POST: Employee
        [HttpPost]
        public IActionResult Index(string id)
        {
            try
            {
                string sentId = id ?? string.Empty;
                EmployeeFacade employeeFacade = new EmployeeFacade(employeeClientService);
                if (ModelState.IsValid)
                {
                    // This validation is included since textbox accepts numeric and empty values
                    Regex regex = new Regex(@"^\d+$");

                    if (string.IsNullOrWhiteSpace(sentId) || regex.Match(sentId).Success)
                    {
                        // Calling Facade before Bussiness Logic Layer to orchestate services
                        var employeeList = employeeFacade.GetEmployeesFromAPI(string.IsNullOrWhiteSpace(sentId) ? 0 : int.Parse(sentId));
                        ViewBag.Warning = employeeList.Count() + " Result(s)...";
                        return View(employeeList);
                    }
                    ViewBag.Warning = "Wrong Value";
                }
                return View(employeeFacade.GetEmptyEmployeesList());
            }
            catch (Exception ex) 
            {                
                ex.Data.Add("EmployeeController", "HttpPost Index()");
                //Log Exception from inferior layers
                return View("Error");
            }
        }
    }
}