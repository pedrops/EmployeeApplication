using Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.Service
{
    public interface IEmployeeClientService
    {
        List<Employee> GetEmployeeList();
        double GetAnualSalary(Employee employee);
    }
}
