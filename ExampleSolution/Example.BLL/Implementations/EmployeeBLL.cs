using Example.DAL;
using Example.Domain;
using System;
using System.Collections.Generic;

namespace Example.BLL
{
    public class EmployeeBLL : IEmployeeBLL
    {
        private readonly IRepository repository;

        public EmployeeBLL(IRepository repository)
        {
            this.repository = repository;
        }

        public Employee Register(string lastName, string firstName, string middleName, Department department, decimal salary)
        {
            var newEmployee = new Employee(lastName, firstName, middleName, salary, 0, null);
            newEmployee.Department = department;
            var savedEmployee = this.repository.Save(newEmployee);

            return savedEmployee;
        }

        public void OnBoard(Employee employee)
        {
            employee.OnBoardDate = DateTime.Today;

            this.repository.Save(employee);
        }

        public void Move(Employee employee, Department target)
        {
            employee.Department = target;

            this.repository.Save(employee);
        }

        public ICollection<Employee> GetEmployeesByDepartment(Department department)
        {
            return this.repository.GetDepartmentById(department.Id).Employees;
        }

        public Employee GetById(Guid id)
        {
            return this.repository.GetEmployeeById(id);
        }
    }
}
