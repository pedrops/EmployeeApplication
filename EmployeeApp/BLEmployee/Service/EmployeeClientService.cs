using Core.Interfaces.DL;
using Core.Interfaces.Factory;
using Core.Interfaces.Service;
using Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public class EmployeeClientService : IEmployeeClientService
    {
        private IEmployeeFactory EmployeeFact;
        private IEmployeeClientRepository EmployeeClientRepo;
        public EmployeeClientService(IEmployeeFactory _EmployeeFact, IEmployeeClientRepository _EmployeeClientRepo)
        {
            EmployeeFact = _EmployeeFact;
            EmployeeClientRepo = _EmployeeClientRepo;
        }

        public double GetAnualSalary(Employee employee)
        {
            try
            {
                return EmployeeFact.GetAnualSalary(employee);
            }
            catch (Exception ex)
            {
                ex.Data.Add("EmployeeClientService", "GetAnualSalary()");
                throw ex;
            }
            
        }

        public List<Employee> GetEmployeeList()
        {
            try
            {
                return EmployeeFact.GetEmployeeList(EmployeeClientRepo.GetEmployeeList());
            }
            catch (Exception ex)
            {
                ex.Data.Add("EmployeeClientService", "GetEmployeeList()");
                throw ex;
            }
        }

    }
}
