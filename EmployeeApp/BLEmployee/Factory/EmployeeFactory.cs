using Core.Interfaces.DTO;
using Core.Interfaces.Factory;
using Core.Model.Entity;
using Core.Model.Enum;
using System;
using System.Collections.Generic;

namespace Core.Factory
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public Employee Create()
        {
            return new Employee();
        }

        public Employee Build(IEmployeeDTO employeeDTO)
        {
            try
            {
                return new Employee(employeeDTO);
            }
            catch (Exception ex)
            {
                ex.Data.Add("EmployeeFactory", "Build()");
                throw ex;
            }
        }

        public double GetAnualSalary(Employee employee)
        {
            try
            {
                if (employee.ContractTypeName == ContractTypeDictionary.hourly)
                {
                    return 12 * employee.HourlySalary * 120;
                }
                else if (employee.ContractTypeName == ContractTypeDictionary.monthly)
                {
                    return 12 * employee.MonthlySalary;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                ex.Data.Add("EmployeeFactory", "GetAnualSalary()");
                throw ex;
            }
        }

        public List<Employee> GetEmployeeList(List<IEmployeeDTO> employeeListDTO)
        {
            try
            {
                var result = new List<Employee>();
                foreach (var item in employeeListDTO)
                {
                    result.Add(Build(item));
                }
                return result;
            }
            catch (Exception ex)
            {
                ex.Data.Add("EmployeeFactory", "GetEmployeeList()");
                throw ex;
            }
        }
    }
}
