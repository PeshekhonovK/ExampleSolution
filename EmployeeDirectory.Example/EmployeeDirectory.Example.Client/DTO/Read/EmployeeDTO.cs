namespace EmployeeDirectory.Example.Client.DTO.Read
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public DepartmentDTO Department { get; set; }
        
        public int VacationDaysLeft { get; set; }
        
        public decimal Salary { get; set; }
    }
}