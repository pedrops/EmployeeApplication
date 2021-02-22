using Core.Interfaces.DTO;
using Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.Factory
{
    public interface IEmployeeFactory
    {
        Employee Build(IEmployeeDTO employeeDTO);
        List<Employee> GetEmployeeList(List<IEmployeeDTO> employeeListDTO);
        double GetAnualSalary(Employee employee);
    }
}
