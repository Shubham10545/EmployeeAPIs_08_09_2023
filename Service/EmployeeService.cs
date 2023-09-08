using Domain.Models;
using Domain.ViewModels;
using Repository;
using System.Linq.Expressions;

namespace Service
{
    public class EmployeeService : IEmployeeService

    {
        private readonly AppDbContext _appDbContext;
        private readonly IRepository<Employee> _repository;

        public EmployeeService(Repository.AppDbContext dbContext, IRepository<Employee> repository)
        {
            this._appDbContext = dbContext;
            this._repository = repository;
        }

        public List<GetAllEmployeeData> GetAllEmployeeRecords()
        {
            return this._repository.GetAll();
        }

        public async Task<bool> DeleteEmployeeRecord(int id)
        {
            Employee employeeData = await _repository.Get(id);
            return await _repository.Delete(employeeData);
          
        }

        public Task<bool> AddEmployee(EmployeeViewModel employee)
        {
            DateTime minAllowedDate = DateTime.Today.AddYears(-18);

            if (employee.BirthDate > minAllowedDate)
            {
                throw new ArgumentException("Birth date must be at least 18 years ago.");

            }
            else
            {

                Employee employeeData = new()
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Gender = employee.Gender,
                    MaritalStatus = employee.MaritalStatus,
                    BirthDate = employee.BirthDate,
                    Hobbies = employee.Hobbies,
                    Salary = employee.Salary,
                    Address = employee.Address,
                    CountryId = employee.CountryId,
                    StateId = employee.StateId,
                    CityId = employee.CityId,
                    ZipCode = employee.ZipCode,
                    Password = employee.Password,
                    ImageName = employee.Files?.FileName,
                };
                return _repository.Insert(employeeData);
            }
        }
        async Task<bool> IEmployeeService.UpdateEmployee(EmployeeViewModel employee)
        {
            DateTime minAllowedDate = DateTime.Today.AddYears(-18);

            if (employee.BirthDate > minAllowedDate)
            {
                throw new ArgumentException("Birth date must be at least 18 years ago.");

            }
            else
            {
                var employeevalue = _appDbContext.Employee.Find(employee.Id);
                if (employeevalue != null)
                {
                    employeevalue.FirstName = employee.FirstName;
                    employeevalue.LastName = employee.LastName;
                    employeevalue.Email = employee.Email;
                    employeevalue.Gender = employee.Gender;
                    employeevalue.Hobbies = employee.Hobbies;
                    employeevalue.MaritalStatus = employee.MaritalStatus;
                    employeevalue.BirthDate = employee.BirthDate;
                    employeevalue.Salary = employee.Salary;
                    employeevalue.Address = employee.Address;
                    employeevalue.CityId = employee.CityId;
                    employeevalue.StateId = employee.StateId;
                    employeevalue.CountryId = employee.CountryId;
                    employeevalue.ZipCode = employee.ZipCode;
                    employeevalue.Password = employee.Password;
                    employeevalue.ImageName = employee.Files?.FileName;

                    var result = await _repository.Update(employeevalue);
                    return result;
                }
                else
                {
                    throw new ArgumentException("Employee not found.");
                }
            }

        }
    }
}