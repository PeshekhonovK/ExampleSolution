using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.Domain
{
    [Table("Employees")]
    public class EmployeeEntity
    {
        [Key]
        public virtual Guid Id { get; set; }

        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }

        public virtual decimal Salary { get; set; }
        public virtual double VacationDays { get; set; }

        public virtual DateTime? OnBoardDate { get; set; }

        public virtual DepartmentEntity Department { get; set; }

        public EmployeeEntity MapToEntity(Employee employee, DepartmentEntity department)
        {
            this.Id = employee.Id;
            this.FirstName = employee.FirstName;
            this.LastName = employee.LastName;
            this.MiddleName = employee.MiddleName;
            this.OnBoardDate = employee.OnBoardDate;
            this.Salary = employee.Salary;
            this.VacationDays = employee.VacationDays;
            this.Department = department;

            return this;
        }

        public Employee MapToModel(Department department)
        {
            var employee = new Employee(this.LastName, this.FirstName, this.MiddleName, this.Salary, this.VacationDays, this.OnBoardDate) { Id = this.Id };
            employee.Department = department;

            return employee;
        }
    }
}
