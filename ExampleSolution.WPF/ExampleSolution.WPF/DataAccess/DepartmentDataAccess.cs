using ExampleSolution.WPF.DataAccess.Interfaces;
using ExampleSolution.WPF.ExampleService;
using ExampleSolution.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExampleSolution.WPF.DataAccess
{
    public class DepartmentDataAccess : IDataAccess<Department>
    {
        public ICollection<Department> Get()
        {
            using (var service = new ExampleServiceClient())
            {
                return service.GetDepartments().Select(x => new Department
                {
                    Id = x.Id,
                    Name = x.Name,
                    Employees = x.Employees.Select(e => new Employee
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        MiddleName = e.MiddleName,
                        LastName = e.LastName,
                    }).ToList()
                }).ToArray();
            }
        }

        public void Save(Department data)
        {
            using (var service = new ExampleServiceClient())
            {
                if (data.Id == Guid.Empty)
                {
                    service.CreateNewDepartment(data.Name);
                }
                else
                {
                    service.UpdateDepartment(new DepartmentDTO
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Employees = data.Employees.Select(x => new EmployeeDTO
                        {
                            FirstName = x.FirstName,
                            MiddleName = x.MiddleName,
                            LastName = x.LastName,
                            Salary = x.Salary,
                            Id = x.Id
                        }).ToArray()
                    });
                }
            }
        }
    }
}
