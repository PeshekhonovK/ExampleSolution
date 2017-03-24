using System;

namespace ExampleSolution.WPF.Models
{
    public class Employee
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual decimal Salary { get; set; }
        public virtual Guid DepartmentId { get; set; }
    }
}
