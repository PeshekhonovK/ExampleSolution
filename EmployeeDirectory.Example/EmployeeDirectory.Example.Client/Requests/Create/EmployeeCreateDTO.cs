using System.ComponentModel.DataAnnotations;

namespace EmployeeDirectory.Example.Client.Requests.Create
{
    public class EmployeeCreateDTO
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public int? DepartmentId { get; set; }
    }
}