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

        public List<TblDeparment> GetAllDepartments()
        {
            var departments = _context.TblDeparments.ToList();
            return departments.Count > 0 ? departments : null;
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
