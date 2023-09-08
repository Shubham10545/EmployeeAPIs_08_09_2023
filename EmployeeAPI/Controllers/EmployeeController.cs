using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using System.Diagnostics.Eventing.Reader;
using static System.Net.Mime.MediaTypeNames;

namespace EmployeeAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employee;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public EmployeeController(IEmployeeService employee, IWebHostEnvironment webHostEnvironment)
        {
            _employee = employee;
            _webHostEnvironment = webHostEnvironment;

        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public IActionResult GetAllEmployeeRecords()
        {
            var response = this._employee.GetAllEmployeeRecords();
            return Ok(response);
        }

        private async Task<IActionResult> SaveFileAndExecuteAction(EmployeeViewModel request, Func<EmployeeViewModel, Task<IActionResult>> action)
        {
            if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\"))
            {
                Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\");
            }

            if (request.Files == null || request.Files.Length == 0)
            {
                // Handle the case where 'request.Files' is null or empty, perhaps by returning a BadRequest response.
                return BadRequest("No file uploaded.");
            }

            using (FileStream filestream = System.IO.File.Create((_webHostEnvironment.WebRootPath + "\\Images\\" + request.Files.FileName)))
            {
                request.Files.CopyTo(filestream);
                filestream.Flush();

                return await action(request);
            }
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployeeRecords([FromForm] EmployeeViewModel request)
        {
            return await SaveFileAndExecuteAction(request, async (employeeRequest) =>
            {
                return Ok(await _employee.AddEmployee(employeeRequest));
            });
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployeeRecords([FromForm] EmployeeViewModel request)
        {
            return await SaveFileAndExecuteAction(request, async (employeeRequest) =>
            {
                return Ok(await _employee.UpdateEmployee(employeeRequest));
            });
        }


        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployeeRecord(int id)
        {
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid id. Id must be a positive integer.");
                }

                var result = await this._employee.DeleteEmployeeRecord(id);

                if (result)
                {
                    return Ok("Employee deleted successfully.");
                }
                else
                {
                    return NotFound("Employee not found.");
                }
            }

        }
    }
}
