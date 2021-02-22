using Core.Factory;
using Core.Interfaces.DTO;
using Core.Model.Entity;
using Data.DTO;
using NUnit.Framework;
using System.Collections.Generic;


namespace UnitTest
{

    public class FactoryUnitTests
    {
        EmployeeFactory employeeFactory;
        Employee employee;
        EmployeeDTO employeeDTO;
        

        [Test]
        public void GetAnualSalary_HourlySalary_MatchSalaries()
        {
            var anualSalaryByHour = 120 * employee.HourlySalary * 12;
            employee.ContractTypeName = "HourlySalaryEmployee";
            Assert.AreEqual(employeeFactory.GetAnualSalary(employee), anualSalaryByHour);
        }

        [Test]
        public void GetAnualSalary_MonthlySalary_MatchSalaries()
        {
            var anualSalaryByMonth = employee.MonthlySalary * 12;
            employee.ContractTypeName = "MonthlySalaryEmployee";
            Assert.AreEqual(employeeFactory.GetAnualSalary(employee), anualSalaryByMonth);
        }

        /// <summary>
        /// This section tests the factory conversion from one object to another 
        /// </summary>
        [Test]
        public void GetEmployeeList_EmployeeDTOList_EmployeeEntityTypeMatch()
        {
            var EmployeeDTOList = new List<IEmployeeDTO> {
                employeeDTO
            };
            var employeeList = employeeFactory.GetEmployeeList(EmployeeDTOList);
            Assert.AreEqual(employeeList.GetType(), typeof(List<Employee>));
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            employeeFactory = new EmployeeFactory();
            employee = employeeFactory.Create();
            employee.ID = 1;
            employee.Name = "John Smith";
            employee.RoleId = 1;
            employee.RoleName = "Administrator";
            employee.RoleDescription = "General Administrator";
            employee.HourlySalary = 20;
            employee.MonthlySalary = 4000;

            employeeDTO = new EmployeeDTO
            {
                ID = 1,
                Name = "John Smith",
                RoleId = 1,
                RoleName = "Administrator",
                RoleDescription = "General Administrator",
                HourlySalary = 20,
                MonthlySalary = 4000
            };
        }
    }
}
