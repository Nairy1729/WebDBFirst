namespace WebDBFirst.Models
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DepartmentHead { get; set; }
        public List<EmployeeDto> Employees { get; set; }
    }
}
