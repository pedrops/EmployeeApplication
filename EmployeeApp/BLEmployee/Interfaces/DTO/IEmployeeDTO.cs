using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.DTO
{
    public interface IEmployeeDTO
    {
        int ID { get; set; }
        string Name { get; set; }
        string ContractTypeName { get; set; }
        int RoleId { get; set; }
        string RoleName { get; set; }
        string RoleDescription { get; set; }
        double HourlySalary { get; set; }
        double MonthlySalary { get; set; }
    }
}
