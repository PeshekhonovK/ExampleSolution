using System;
using Example.Domain;
using System.Collections.Generic;

namespace Example.BLL
{
    public interface IEmployeeBLL
    {
        /// <summary>
        /// Creates new Employee
        /// </summary>
        Employee Register(string lastName, string firstName, string middleName, Department department, decimal salary);

        /// <summary>
        /// Sets Employee OnBoard date to current
        /// </summary>
        void OnBoard(Employee employee);

        /// <summary>
        /// Moves employee to new department
        /// </summary>
        void Move(Employee employee, Department target);

        ICollection<Employee> GetEmployeesByDepartment(Department department);
        Employee GetById(Guid id);
    }
}