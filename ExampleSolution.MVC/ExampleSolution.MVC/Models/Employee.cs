using ExampleSolution.MVC.ExampleService;
using System;

namespace ExampleSolution.MVC.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public decimal Salary { get; set; }

        public virtual Employee MapFrom(EmployeeDTO dto)
        {
            this.Id = dto.Id;
            this.FirstName = dto.FirstName;
            this.LastName = dto.LastName;
            this.MiddleName = dto.MiddleName;
            this.Salary = dto.Salary;

            return this;
        }

        public EmployeeDTO ToDTO()
        {
            return new EmployeeDTO
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                MiddleName = this.MiddleName,
                Salary = this.Salary
            };
        }
    }
}