using System;

namespace Example.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string LastName { get; }
        public string FirstName { get; }
        public string MiddleName { get; }

        public decimal Salary { get; set; }
        public double VacationDays { get; }

        public Department Department { get; set; }

        public DateTime? OnBoardDate { get; set; }

        public Employee(string lastName, string firstName, string middleName, decimal salary, double vacationDays, DateTime? onBoardDate)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.MiddleName = middleName;

            this.Salary = salary;

            this.VacationDays = vacationDays;
            this.OnBoardDate = onBoardDate;
        }
    }
}
