﻿using Core.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class EmployeeDTO : IEmployeeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public double HourlySalary { get; set; }
        public double MonthlySalary { get; set; }
    }
}
