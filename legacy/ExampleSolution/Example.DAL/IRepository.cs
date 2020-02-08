using Example.Domain;
using System;
using System.Collections.Generic;

namespace Example.DAL
{
    public interface IRepository
    {
        Employee GetEmployeeById(Guid id);

        Employee Save(Employee employee);

        ICollection<Employee> Save(params Employee[] employee);

        Department GetDepartmentById(Guid id);

        Department Save(Department department);

        ICollection<Department> Save(params Department[] department);

        ICollection<Department> GetAllDepartments();
    }
}