using Core.Model.Entity;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Display(Name = "Contract Type")]
        public string ContractTypeName { get; set; }

        [Display(Name = "Role Id")]
        public int RoleId { get; set; }

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        [Display(Name = "Role Description")]
        public string RoleDescription { get; set; }

        public double HourlySalary { get; set; }
        public double MonthlySalary { get; set; }

        [Display(Name = "Anual Salary")]
        [DataType(dataType: DataType.Currency)]
        public double AnualSalary { get; set; }
        

        public EmployeeModel(Employee employee, double anualSalary)
        {
            ID = employee.ID;
            Name = employee.Name;
            ContractTypeName = employee.ContractTypeName;
            RoleId = employee.RoleId;
            RoleName = employee.RoleName;
            RoleDescription = employee.RoleDescription;
            HourlySalary = employee.HourlySalary;
            MonthlySalary = employee.MonthlySalary;
            AnualSalary = anualSalary;
        }

    }
}
