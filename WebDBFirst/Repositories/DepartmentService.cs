using Microsoft.EntityFrameworkCore;
using WebDBFirst.Models;

namespace WebDBFirst.Repositories
{
    public class DepartmentService : IDepartmentService
    {
        private readonly API_CF_DemoContext _context;

        public DepartmentService(API_CF_DemoContext context)
        {
            _context = context;
        }

        public List<DepartmentDto> GetAllDepartments()
        {
            var departments = _context.TblDeparments
                .Select(d => new DepartmentDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    DepartmentHead = d.DepartmentHead,
                    Employees = d.TblEmployees.Select(e => new EmployeeDto
                    {
                        EmployeeId = e.EmployeeId,
                        Name = e.Name,
                        Gender = e.Gender,
                        Designation = e.Designation,
                        Email = e.Email,
                        Salary = e.Salary,
                        DepartmentName = e.Department.Name
                    }).ToList()
                })
                .ToList();

            return departments;
        }


        public int AddNewDepartment(TblDeparment department)
        {
            try
            {
                if (department != null)
                {
                    _context.TblDeparments.Add(department);
                    _context.SaveChanges();
                    return department.Id;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string DeleteDepartment(int id)
        {
            if (id != 0)
            {
                var department = _context.TblDeparments.FirstOrDefault(x => x.Id == id);
                if (department != null)
                {
                    _context.TblDeparments.Remove(department);
                    _context.SaveChanges();
                    return $"The department with ID {id} was removed.";
                }
                return "Department not found.";
            }
            return "ID should not be zero.";
        }

        public TblDeparment GetDepartmentById(int id)
        {
            if (id != 0)
            {
                return _context.TblDeparments.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }

        public string UpdateDepartment(TblDeparment department)
        {
            var existingDepartment = _context.TblDeparments.FirstOrDefault(x => x.Id == department.Id);
            if (existingDepartment != null)
            {
                existingDepartment.Name = department.Name;
                existingDepartment.DepartmentHead = department.DepartmentHead;

                _context.Entry(existingDepartment).State = EntityState.Modified;
                _context.SaveChanges();
                return "Department updated successfully.";
            }
            return "Department not found.";
        }
    }
}
