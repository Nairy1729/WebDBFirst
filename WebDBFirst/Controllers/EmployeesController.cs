using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebDBFirst.Models;
using WebDBFirst.Repositories;

namespace WebDBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<EmployeeDto> employees = _service.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            EmployeeDto employee = _service.GetEmployeeById(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with ID {id} not found.");
        }

        [HttpPost]
        public IActionResult Post(EmployeeDto employeeDto)
        {
            int result = _service.AddNewEmployee(employeeDto);
            if (result > 0)
            {
                return CreatedAtAction(nameof(GetEmployeeById), new { id = result }, employeeDto);
            }
            return BadRequest("Failed to create employee.");
        }

        [HttpPut]
        public IActionResult Put(EmployeeDto employeeDto)
        {
            string result = _service.UpdateEmployee(employeeDto);
            if (result.Contains("successfully"))
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string result = _service.DeleteEmployee(id);
            if (result.Contains("removed"))
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
