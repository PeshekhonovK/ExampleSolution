using ExampleSolution.WPF.DataAccess.Interfaces;
using ExampleSolution.WPF.ExampleService;
using ExampleSolution.WPF.Models;
using System;
using System.Collections.Generic;

namespace ExampleSolution.WPF.DataAccess
{
    public class EmployeeDataAccess : IDataAccess<Employee>
    {
        public ICollection<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public void Save(Employee data)
        {
            using (var service = new ExampleServiceClient())
            {
                if (data.Id == Guid.Empty)
                {
                    service.CreateNewEmployee(data.FirstName, data.MiddleName, data.LastName, data.Salary, data.DepartmentId);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
