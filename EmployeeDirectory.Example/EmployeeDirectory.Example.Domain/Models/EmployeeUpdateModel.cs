namespace EmployeeDirectory.Example.Domain.Models
{
    public class EmployeeUpdateModel
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public int? DepartmentId { get; set; }
    }
}