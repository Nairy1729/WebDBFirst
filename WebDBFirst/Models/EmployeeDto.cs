﻿namespace WebDBFirst.Models
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string? Designation { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public string DepartmentName { get; set; }
    }
}
