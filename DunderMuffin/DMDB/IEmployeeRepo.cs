using System.Collections.Generic;
using DMDB.Models;

namespace DMDB
{
    /// <summary>
    /// Data access interface for DunderMuffin employees
    /// </summary>
    public interface IEmployeeRepo
    {
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByEmail(string email);
        List<Employee> GetAllEmployees();
    }
}