using Domain.Models;
using Domain.ViewModels;
using System.Collections.Generic;

namespace Service
{
    public interface IEmployeeService
    {
        // Get All Records
        List<Domain.ViewModels.GetAllEmployeeData> GetAllEmployeeRecords();

        Task<bool> AddEmployee(EmployeeViewModel employee);

        Task<bool> UpdateEmployee(EmployeeViewModel employee);
     
        Task<bool> DeleteEmployeeRecord(int id);

       
    }
}
