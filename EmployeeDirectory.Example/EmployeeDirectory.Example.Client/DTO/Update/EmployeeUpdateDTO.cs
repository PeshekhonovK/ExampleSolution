using EmployeeDirectory.Example.Client.DTO.Create;

namespace EmployeeDirectory.Example.Client.DTO.Update
{
    public class EmployeeUpdateDTO : EmployeeCreateDTO
    {
        public int Id { get; set; }
    }
}