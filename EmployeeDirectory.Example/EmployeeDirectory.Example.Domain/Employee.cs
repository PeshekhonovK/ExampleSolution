using EmployeeDirectory.Example.Domain.Contracts;

namespace EmployeeDirectory.Example.Domain
{
    public class Employee : IDepartmentContainer
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public Department Department { get; set; }
        
        public int VacationDaysLeft { get; set; }
        
        public decimal Salary { get; set; }
        
        int? IDepartmentContainer.DepartmentId => this.Department.Id;
    }
}