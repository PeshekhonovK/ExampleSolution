using Example.Domain;
using System;
using System.Runtime.Serialization;

namespace Example.DTO
{
    [DataContract]
    public class EmployeeDTO
    {
        [DataMember]
        public Guid Id { get; set; } = Guid.Empty;

        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public decimal Salary { get; set; }
        [DataMember]
        public double VacationDays { get; set; }

        [DataMember]
        public DateTime? OnBoardDate { get; set; }

        public EmployeeDTO MapFromModel(Employee employee)
        {
            this.Id = employee.Id;
            this.FirstName = employee.FirstName;
            this.LastName = employee.LastName;
            this.MiddleName = employee.MiddleName;
            this.OnBoardDate = employee.OnBoardDate;
            this.Salary = employee.Salary;
            this.VacationDays = employee.VacationDays;

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
