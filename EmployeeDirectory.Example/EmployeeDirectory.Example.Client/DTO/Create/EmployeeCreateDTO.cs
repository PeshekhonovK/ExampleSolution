using EmployeeDirectory.Example.Client.DTO.Read;

namespace EmployeeDirectory.Example.Client.DTO.Create
{
    public class EmployeeCreateDTO
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public int? DepartmentId { get; set; }
    }
}