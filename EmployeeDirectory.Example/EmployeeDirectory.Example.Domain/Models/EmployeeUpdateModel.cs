using EmployeeDirectory.Example.Domain.Contracts;

namespace EmployeeDirectory.Example.Domain.Models
{
    public class EmployeeUpdateModel : IEmployeeIdentity, IDepartmentContainer
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public int? DepartmentId { get; set; }
    }
}