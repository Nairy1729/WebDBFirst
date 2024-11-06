using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebDBFirst.Models;
using WebDBFirst.Repositories;

namespace WebDBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentsController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<DepartmentDto> departments = _service.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            DepartmentDto department = _service.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound($"Department with ID {id} not found.");
            }
            return Ok(department);
        }

        [HttpPost]
        public IActionResult Post(DepartmentDto departmentDto)
        {
            int result = _service.AddNewDepartment(departmentDto);
            if (result > 0)
            {
                return CreatedAtAction(nameof(GetDepartmentById), new { id = result }, departmentDto);
            }
            return BadRequest("Error creating department.");
        }

        [HttpPut]
        public IActionResult Put(DepartmentDto departmentDto)
        {
            string result = _service.UpdateDepartment(departmentDto);
            if (result.Contains("success"))
            {
                return Ok(result);
            }
            return BadRequest("Error updating department.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string result = _service.DeleteDepartment(id);
            if (result.Contains("removed"))
            {
                return Ok(result);
            }
            return NotFound("Error deleting department or department not found.");
        }
    }
}
