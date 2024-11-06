using Microsoft.EntityFrameworkCore;
using WebDBFirst.Models;

namespace WebDBFirst.Repositories
{
    public class EmployeeService : IEmployeeService
    {
        private readonly API_CF_DemoContext _context;

        public EmployeeService(API_CF_DemoContext context)
        {
            _context = context;
        }

        public List<TblEmployee> GetAllEmployees()
        {
            var employees = _context.TblEmployees.ToList();
            return employees.Count > 0 ? employees : null;
        }

        public TblEmployee GetEmployeeById(int id)
        {
            if (id != 0)
            {
                return _context.TblEmployees.FirstOrDefault(e => e.EmployeeId == id);
            }
            return null;
        }

        public int AddNewEmployee(TblEmployee employee)
        {
            try
            {
                if (employee != null)
                {
                    _context.TblEmployees.Add(employee);
                    _context.SaveChanges();
                    return employee.EmployeeId;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string DeleteEmployee(int id)
        {
            if (id != 0)
            {
                var employee = _context.TblEmployees.FirstOrDefault(e => e.EmployeeId == id);
                if (employee != null)
                {
                    _context.TblEmployees.Remove(employee);
                    _context.SaveChanges();
                    return $"The employee with ID {id} was removed successfully.";
                }
                return "Employee not found.";
            }
            return "ID should not be zero.";
        }

        public string UpdateEmployee(TblEmployee employee)
        {
            var existingEmployee = _context.TblEmployees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Gender = employee.Gender;
                existingEmployee.Designation = employee.Designation;
                existingEmployee.Email = employee.Email;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.DepartmentId = employee.DepartmentId;

                _context.Entry(existingEmployee).State = EntityState.Modified;
                _context.SaveChanges();
                return "Employee updated successfully.";
            }
            return "Employee not found.";
        }
    }
}
