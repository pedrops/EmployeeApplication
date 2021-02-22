using Core.Interfaces.Service;
using EmployeeApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeApp.Facade
{
    public class EmployeeFacade
    {
        IEmployeeClientService employeeClientService;
        public EmployeeFacade(IEmployeeClientService _employeeClientService)
        {
            employeeClientService = _employeeClientService;
        }


        /// <summary>
        /// Getting Employees from API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<EmployeeModel> GetEmployeesFromAPI(int id = 0)
        {
            try
            {
                var EmployeeModelList = new List<EmployeeModel>();
                var EmployeeList = id == 0 ?
                        employeeClientService.GetEmployeeList() :
                        employeeClientService.GetEmployeeList().Where(x => x.ID == id).ToList();
                foreach (var employeeListItem in EmployeeList)
                {
                    double anualSalary = employeeClientService.GetAnualSalary(employeeListItem);
                    EmployeeModel employeeModel = new EmployeeModel(employeeListItem, anualSalary);
                    EmployeeModelList.Add(employeeModel);
                }
                return EmployeeModelList;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Getting Employees from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<EmployeeModel> GetEmployeesFromDB(int id = 0)
        {
            var EmployeeModelList = new List<EmployeeModel>();
            return EmployeeModelList;
        }

        public List<EmployeeModel> GetEmptyEmployeesList(int id = 0)
        {
            return new List<EmployeeModel>();
        }
    }
}
