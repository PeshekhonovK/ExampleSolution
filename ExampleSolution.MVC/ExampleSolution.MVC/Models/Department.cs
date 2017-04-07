using ExampleSolution.MVC.ExampleService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExampleSolution.MVC.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public Department MapFrom(DepartmentDTO dto)
        {
            this.Id = dto.Id;
            this.Name = dto.Name;
            this.Employees = dto.Employees.Select(x => new Employee().MapFrom(x)).ToList();

            return this;
        }

        public DepartmentDTO ToDTO()
        {
            return new DepartmentDTO
            {
                Id = this.Id,
                Name = this.Name,
                Employees = this.Employees.Select(x => x.ToDTO()).ToArray()
            };
        }
    }
}