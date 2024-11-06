using WebDBFirst.Models;

namespace WebDBFirst.Repositories
{
    public interface IDepartmentService
    {
        List<TblDeparment> GetAllDepartments();
        TblDeparment GetDepartmentById(int id);
        int AddNewDepartment(TblDeparment department);
        string UpdateDepartment(TblDeparment department);
        string DeleteDepartment(int id);
    }
}
