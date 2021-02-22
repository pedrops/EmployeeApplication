using Core.Interfaces.DTO;
using Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces.DL
{
    public interface IEmployeeClientRepository
    {
        List<IEmployeeDTO> GetEmployeeList();        
    }
}
