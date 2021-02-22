using Core.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Entity
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public double HourlySalary { get; set; }
        public double MonthlySalary { get; set; }

        public Employee()
        {
        }
        public Employee(IEmployeeDTO DTO)
        {
            ID = DTO.ID;
            Name = DTO.Name;
            ContractTypeName = DTO.ContractTypeName;
            RoleId = DTO.RoleId;
            RoleName = DTO.RoleName;
            RoleDescription = DTO.RoleDescription;
            HourlySalary = DTO.HourlySalary;
            MonthlySalary = DTO.MonthlySalary;
        }

    }
}
