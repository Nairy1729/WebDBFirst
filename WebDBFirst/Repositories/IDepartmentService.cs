using WebDBFirst.Models;

namespace WebDBFirst.Repositories
{
    public interface IDepartmentService
    {
        List<DepartmentDto> GetAllDepartments();
        DepartmentDto GetDepartmentById(int id);
        int AddNewDepartment(DepartmentDto departmentDto);
        string UpdateDepartment(DepartmentDto departmentDto);
        string DeleteDepartment(int id);
    }
}
