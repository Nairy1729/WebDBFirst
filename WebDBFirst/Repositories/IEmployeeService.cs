﻿using WebDBFirst.Models;

namespace WebDBFirst.Repositories
{
    public interface IEmployeeService
    {
        List<TblEmployee> GetAllEmployees();
        TblEmployee GetEmployeeById(int id);
        int AddNewEmployee(TblEmployee employee);
        string DeleteEmployee(int id);
        string UpdateEmployee(TblEmployee employee);
    }
}