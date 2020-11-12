using DMDB;
using DMDB.Models;
using System.Collections.Generic;

namespace DMLib
{
    public class EmployeeServices
    {
        /// <summary>
        /// These Are The Methods That Connect With The DBRepo and Allow Us To Use Employee Related Business Logic Like Adding Updating Deleting Or Getting Users
        /// </summary>
        private IEmployeeRepo repo;

        public EmployeeServices(IEmployeeRepo repo) 
        {
            this.repo = repo;
        }
        public void AddEmployee(Employee employee)
        {
            repo.AddEmployee(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            repo.UpdateEmployee(employee);
        }
        public void DeleteEmployee(Employee employee)
        {
            repo.DeleteEmployee(employee);
        }
        public Employee GetEmployeeById(int id)
        {
            Employee employee = repo.GetEmployeeById(id);
            return employee;
        }
        public Employee GetEmployeeByEmail(string email)
        {
            Employee employee = repo.GetEmployeeByEmail(email);
            return employee;
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = repo.GetAllEmployees();
            return employees;
        }
    }
}